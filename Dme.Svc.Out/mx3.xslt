<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>
  
  <xsl:template match="Order">
    <xsl:element name="Файл" namespace="http://purl.oclc.org/dsdl/schematron">
      <xsl:attribute name="ВерсПрог">ru.santens.1.1</xsl:attribute>
      <xsl:attribute name="ВерсияФормата">3.01</xsl:attribute>
      <xsl:attribute name="Формат">ЭДОМХ3</xsl:attribute>
      <xsl:attribute name="Имя">MX3-<xsl:value-of select="@OrderID"/></xsl:attribute>
      <xsl:attribute name="КодФормы">СантенсСервис</xsl:attribute>
      <xsl:element name="Документ">
        <xsl:attribute name="Дата">
          <xsl:value-of select="@DT"/>
        </xsl:attribute>
        <xsl:attribute name="Номер">
          <xsl:value-of select="@OrderID"/>
        </xsl:attribute>
        <!-- Шапка документа -->
        <xsl:call-template name="Основание" />
        <xsl:call-template name="Отправитель" />
        <xsl:call-template name="Получатель" />
        <!-- Таблица -->
        <xsl:call-template name="ТаблДок" />
        <!-- Параметры документа-->
        <xsl:call-template name="Параметр">
          <xsl:with-param name="Имя" select="'Склад'" />
          <xsl:with-param name="Значение" select="'Обособленное подразделение ЗАО  &quot;САНТЭНС СЕРВИС&quot; в Домодедово , Московская обл., Домодедовский район, мкрн. Белые Столбы, Склады 104'" />
        </xsl:call-template>
        <xsl:call-template name="Параметр">
          <xsl:with-param name="Имя" select="'СрокХранения'" />
          <xsl:with-param name="Значение" select="'до востребования'" />
        </xsl:call-template>
        <xsl:call-template name="Параметр">
          <xsl:with-param name="Имя" select="'Тип'" />
          <xsl:with-param name="Значение" select="OrderType/@Name" />
        </xsl:call-template>
      </xsl:element>
    </xsl:element>
  </xsl:template>

  <xsl:template name="Основание">
    <xsl:element name="Основание">
      <xsl:attribute name="Номер"><xsl:value-of select="@CustOrderID"/></xsl:attribute>
      <xsl:attribute name="Дата"><xsl:value-of select="@CustOrderDT"/></xsl:attribute>
    </xsl:element>
  </xsl:template>

  <xsl:template name="Отправитель">
    <Отправитель Название="ЗАО &quot;САНТЭНС СЕРВИС&quot;">
      <Адрес>
        <АдрИно КодСтр="643" АдрТекст="121609, Россия, Москва, Осенний бульвар, 23, бизнес-центр «Крылатский», 11 этаж" />
      </Адрес>
      <СвЮЛ Название="ЗАО &quot;САНТЭНС СЕРВИС&quot;" ИНН="7729502499" КПП="772901001" ОКПО="73076011  " />
    </Отправитель>  
  </xsl:template>

  <xsl:template name="Получатель">
    <xsl:element name="Получатель">
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
      <xsl:element name="Адрес">
        <xsl:element name="АдрИно">
          <xsl:attribute name="КодСтр">643</xsl:attribute>
          <xsl:attribute name="АдрТекст">
            <xsl:value-of select="Customer/@Addr"/>
          </xsl:attribute>
        </xsl:element>
      </xsl:element>
    </xsl:element>
  </xsl:template>

  <xsl:template name="ТаблДок">
    <xsl:element name="ТаблДок">
      <xsl:apply-templates select="OrderFactRow" />
      <xsl:call-template name="ИтогТабл" />
    </xsl:element>
  </xsl:template>
  
  <!-- Строка таблицы -->
  <xsl:template match="OrderFactRow">
    <xsl:element name="СтрТабл">
      <xsl:attribute name="ПорНомер">
        <xsl:value-of select="position()"/>
      </xsl:attribute>
      <xsl:attribute name="Название">
        <xsl:value-of select="Partm/@partdsc"/>
        /<xsl:value-of select="Partm/@partdsc2"/>/
      </xsl:attribute>
      <xsl:attribute name="Кол_во">
        <xsl:value-of select="@Qty"/>
      </xsl:attribute>
      <xsl:attribute name="ЕдИзм">шт</xsl:attribute>
      <xsl:attribute name="ОКЕИ">796</xsl:attribute>
      <xsl:attribute name="Код">
        <xsl:value-of select="@PartID"/>
      </xsl:attribute>
      <xsl:attribute name="Цена">
        <xsl:value-of select="@Price"/>
      </xsl:attribute>
      <xsl:attribute name="Сумма">
        <xsl:value-of select="@Amount"/>
      </xsl:attribute>
      <xsl:attribute name="Описание">
        <xsl:value-of select="@BatchNo"/>
      </xsl:attribute>
      
      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'ОригПорНомер'" />
        <xsl:with-param name="Значение" select="@RowNo" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'Качество'" />
        <xsl:with-param name="Значение" select="@InvQual" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'Маркер'" />
        <xsl:with-param name="Значение" select="@SpecInvID" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'Серия'" />
        <xsl:with-param name="Значение" select="@BatchNo" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'СрокГодности'" />
        <xsl:with-param name="Значение" select="@ExpireDT" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'ШтрихКод'" />
        <xsl:with-param name="Значение" select="Partm/@eanid" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'МинЗаказ'" />
        <xsl:with-param name="Значение" select="Partm/@minorder" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'КратнЗаказ'" />
        <xsl:with-param name="Значение" select="Partm/@mulorder" />
      </xsl:call-template>

      <xsl:variable name="specaccount">
        <xsl:choose>
          <xsl:when test="Partm/@specaccount = 'False'">
            0
          </xsl:when>
          <xsl:otherwise>
            1
          </xsl:otherwise>
        </xsl:choose>
      </xsl:variable>

      <xsl:variable name="glass">
        <xsl:choose>
          <xsl:when test="Partm/@glass = 'False'">
            0
          </xsl:when>
          <xsl:otherwise>
            1
          </xsl:otherwise>
        </xsl:choose>
      </xsl:variable>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'Пку'" />
        <xsl:with-param name="Значение" select="$specaccount" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'Стекло'" />
        <xsl:with-param name="Значение" select="$glass" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'КлассОпасн'" />
        <xsl:with-param name="Значение" select="Partm/@hazcl" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'ТемпРежим'" />
        <xsl:with-param name="Значение" select="Partm/@tempcl" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'КодАВЕ'" />
        <xsl:with-param name="Значение" select="Partm/@id1" />
      </xsl:call-template>

      <xsl:call-template name="Характеристика">
        <xsl:with-param name="Имя" select="'КодНалСт'" />
        <xsl:with-param name="Значение" select="Partm/@id2" />
      </xsl:call-template>

    </xsl:element>
  </xsl:template>

  <xsl:template name="Характеристика">
    <xsl:param name="Имя" />
    <xsl:param name="Значение" />
    <xsl:element name="Характеристика">
      <xsl:attribute name="Имя">
        <xsl:value-of select="$Имя"/>
      </xsl:attribute>
      <xsl:attribute name="Значение">
        <xsl:value-of select="$Значение"/>
      </xsl:attribute>
    </xsl:element>
  </xsl:template>

  <xsl:template name="ИтогТабл">
    <xsl:element name="ИтогТабл">
      <xsl:attribute name="Сумма">
        <xsl:value-of select="sum(msxsl:node-set(OrderFactRow)/@Amount)"/>
      </xsl:attribute>
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
