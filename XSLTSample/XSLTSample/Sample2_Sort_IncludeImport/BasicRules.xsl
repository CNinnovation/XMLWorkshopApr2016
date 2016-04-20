<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="html"/>
  
  <xsl:template match="/">
      <xsl:apply-templates select="employee" />
  </xsl:template>

  <xsl:template match="employee">
    <tr valign="top">
      <td align="left">
        <xsl:apply-templates select="name"/>
      </td>
      <td align="left">
        <xsl:apply-templates select="region"/>
      </td>
      <td align="right">
        <xsl:apply-templates select="salary"/>
      </td>
      <td align="right">
        <xsl:apply-templates select="vacation"/>
      </td>
    </tr>
  </xsl:template>

  <xsl:template match="name">
    <xsl:value-of select="surname"/>, <xsl:value-of select="firstname"/>
  </xsl:template>

  <xsl:template match="region">
    <xsl:value-of select="city"/> [<xsl:value-of select="state"/>]
  </xsl:template>

  <xsl:template match="salary">
    $ <xsl:value-of select="format-number(basic * (1 + bonus), '#,000.00')"/>
  </xsl:template>

  <xsl:template match="vacation">
    <xsl:value-of select="format-number(allowed - taken, '#00')"/>
  </xsl:template>

</xsl:stylesheet>
