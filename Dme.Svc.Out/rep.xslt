<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

  <xsl:template match="Order">
    <xsl:element name="Файл" namespace="http://purl.oclc.org/dsdl/schematron">
      <xsl:attribute name="ВерсПрог">ru.santens.1.1</xsl:attribute>
      <xsl:attribute name="ВерсияФормата">3.03</xsl:attribute>
      <xsl:attribute name="Формат">АктРасхождение</xsl:attribute>
      <xsl:attribute name="Имя">
        АКТ-<xsl:value-of select="@OrderID"/>
      </xsl:attribute>
      <xsl:attribute name="КодФормы">Акт о расхождении Сантэнс Сервис</xsl:attribute>
      <xsl:element name="Документ">
        <xsl:attribute name="Дата">
          <xsl:value-of select="@DT"/>
        </xsl:attribute>
        <xsl:attribute name="Номер">
          <xsl:value-of select="@OrderID"/>
        </xsl:attribute>
        <xsl:attribute name="Название">Акт расхождений по заказу №<xsl:value-of select="@CustOrderID"/> от <xsl:value-of select="@CustOrderDT"/></xsl:attribute>
        <!-- Шапка документа -->
        <xsl:call-template name="Основание" />
        <xsl:element name="Стороны">
          <xsl:call-template name="Грузоотправитель" />
          <xsl:call-template name="Грузополучатель" />
        </xsl:element>
        <!-- Таблица -->
        <xsl:call-template name="СписокСтрОтклонения" />
      </xsl:element>
    </xsl:element>
  </xsl:template>

  <xsl:template name="Основание">
    <xsl:element name="СписокОснование">
      <xsl:element name="Основание">
        <xsl:attribute name="Номер">
          <xsl:value-of select="@CustOrderID"/>
        </xsl:attribute>
        <xsl:attribute name="Дата">
          <xsl:value-of select="@CustOrderDT"/>
        </xsl:attribute>
      </xsl:element>
    </xsl:element>
  </xsl:template>

  <xsl:template name="Грузополучатель">
    <Грузополучатель Название="ЗАО &quot;САНТЭНС СЕРВИС&quot;">
      <СписокАдрес>
        <Адрес>
          <АдрИно АдрТекст="121609, Россия, Москва, Осенний бульвар, 23, бизнес-центр «Крылатский», 11 этаж" />
        </Адрес>
      </СписокАдрес>
      <СвЮЛ Название="ЗАО &quot;САНТЭНС СЕРВИС&quot;" ИНН="7729502499" КПП="772901001" ОКПО="73076011  " />
      <СписокПараметр>
        <Параметр Имя="СтруктурноеПодразделение" Значение="Обособленное подразделение ЗАО &quot;САНТЭНС СЕРВИС&quot; в Домодедово , Московская обл., Домодедовский район, мкрн. Белые Столбы, Склады 104"></Параметр>
      </СписокПараметр>
    </Грузополучатель>
  </xsl:template>

  <xsl:template name="Грузоотправитель">
    <xsl:element name="Грузоотправитель">
      <xsl:attribute name="Название">
        <xsl:value-of select="Customer/@Name"/>
      </xsl:attribute>
      <xsl:element name="СвЮЛ">
        <xsl:attribute name="Название">
          <xsl:value-of select="Customer/@Name"/>
        </xsl:attribute>
        <xsl:attribute name="ИНН">
          <xsl:value-of select="Customer/@INN"/>
        </xsl:attribute>
        <xsl:attribute name="КПП">
          <xsl:value-of select="Customer/@KPP"/>
        </xsl:attribute>
        <xsl:attribute name="ОКПО">
          <xsl:value-of select="Customer/@OKPO"/>
        </xsl:attribute>
      </xsl:element>
      <xsl:element name="СписокАдрес">
        <xsl:element name="Адрес">
          <xsl:element name="АдрИно">
            <xsl:attribute name="АдрТекст">
              <xsl:value-of select="Customer/@Addr"/>
            </xsl:attribute>
          </xsl:element>
        </xsl:element>
      </xsl:element>
    </xsl:element>
  </xsl:template>

  <xsl:template name="СписокСтрОтклонения">
    <xsl:element name="СписокСтрОтклонения">
      <xsl:variable name="factRows" select="msxsl:node-set(OrderFactRow)" />
      <xsl:for-each select="OrderDocRow">
        <xsl:variable name="docQty" select="@Qty" />
        <xsl:variable name="docPrice" select="@Price" />
        <xsl:variable name="docRowNo" select="@RowNo" />
        <xsl:if test="$docRowNo">
          <xsl:variable name="factQty" select="sum($factRows[@RowNo=$docRowNo]/@Qty)" />
          <xsl:if test="$factQty != $docQty">
            <xsl:element name="СтрОтклонения">
              <xsl:attribute name="ПорНомер">
                <xsl:value-of select="$docRowNo"/>
              </xsl:attribute>
              <xsl:attribute name="Название">
                <xsl:value-of select="Partm/@partdsc"/>
                /<xsl:value-of select="Partm/@partdsc2"/>/
              </xsl:attribute>
              <xsl:attribute name="Кол_во">
                <xsl:value-of select="$factQty - $docQty"/>
              </xsl:attribute>
              <xsl:attribute name="ЕдИзм">
                <xsl:value-of select="'шт'"/>
              </xsl:attribute>
              <xsl:attribute name="ОКЕИ">
                <xsl:value-of select="'796'"/>
              </xsl:attribute>
              <xsl:attribute name="Сумма">
                <xsl:value-of select="$docPrice * ($factQty - $docQty)"/>
              </xsl:attribute>
              <xsl:attribute name="Идентификатор">
                <xsl:value-of select="@PartID"/>
              </xsl:attribute>
              <xsl:element name="ПоДокументам">
                <xsl:attribute name="Кол_во">
                  <xsl:value-of select="$docQty"/>
                </xsl:attribute>
                <xsl:attribute name="Цена">
                  <xsl:value-of select="$docPrice"/>
                </xsl:attribute>
                <xsl:attribute name="Сумма">
                  <xsl:value-of select="$docPrice * $docQty"/>
                </xsl:attribute>
              </xsl:element>
              <xsl:element name="ПоФакту">
                <xsl:attribute name="Кол_во">
                  <xsl:value-of select="$factQty"/>
                </xsl:attribute>
                <xsl:attribute name="Цена">
                  <xsl:value-of select="$docPrice"/>
                </xsl:attribute>
                <xsl:attribute name="Сумма">
                  <xsl:value-of select="$docPrice * $factQty"/>
                </xsl:attribute>
              </xsl:element>
              <xsl:element name="СписокПараметр">
                <xsl:call-template name="Параметр">
                  <xsl:with-param name="Имя" select="'КодАВЕ'" />
                  <xsl:with-param name="Значение" select="Partm/@id1" />
                </xsl:call-template>
                <xsl:call-template name="Параметр">
                  <xsl:with-param name="Имя" select="'КодНалСт'" />
                  <xsl:with-param name="Значение" select="Partm/@id2" />
                </xsl:call-template>
              </xsl:element>
            </xsl:element>
          </xsl:if>
        </xsl:if>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>

  <xsl:template name="Параметр">
    <xsl:param name="Имя" />
    <xsl:param name="Значение" />
    <xsl:element name="Параметр">
      <xsl:attribute name="Имя">
        <xsl:value-of select="$Имя"/>
      </xsl:attribute>
      <xsl:attribute name="Значение">
        <xsl:value-of select="$Значение"/>
      </xsl:attribute>
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>
