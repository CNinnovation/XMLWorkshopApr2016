<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Produkte</title>
      </head>
      <body>
        <table>
          <xsl:apply-templates select="catalog/product" />
        </table>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="product">
    <tr>
      <td>
        <xsl:value-of select="description"/>
      </td>
      <td>
        <xsl:value-of select="price" />
      </td>
    </tr>
  </xsl:template>
</xsl:stylesheet>
