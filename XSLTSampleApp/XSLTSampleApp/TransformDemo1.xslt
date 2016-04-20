<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="html" indent="yes"/>


  <xsl:template match="/">
    <products>
      <xsl:apply-templates select="catalog/product" />
    </products>
  </xsl:template>
  <xsl:template match="product">
    <myproduct>
      <xsl:copy-of select="description" />
    </myproduct>
  </xsl:template>

</xsl:stylesheet>
