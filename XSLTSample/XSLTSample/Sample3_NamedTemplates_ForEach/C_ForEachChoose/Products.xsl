<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <!--<xsl:param name="country"/>-->
  <xsl:variable name="country" select="'UK'" />

  <xsl:template match="catalog">
    <html>
      <head>
        <h1>Product List</h1>
      </head>
      <body>
        <xsl:call-template name="createheadings"/>
      </body>
    </html>
  </xsl:template>

  <xsl:template name="createheadings">
    <table border="1" width="100%" cellpadding="4">
      <tr align="center">
        <td>
          <font size="5">
            <b>Code</b>
          </font>
        </td>
        <td>
          <font size="5">
            <b>Description</b>
          </font>
        </td>
        <td>
          <font size="5">
            <b>Price</b>
          </font>
        </td>
      </tr>
      <xsl:call-template name="createtable"/>
    </table>
  </xsl:template>

  <xsl:template name="createtable">
    <xsl:for-each select="product">
      <tr>
        <td>
          <xsl:value-of select="@code"/>
        </td>
        <td>
          <xsl:value-of select="description"/>
        </td>
        <xsl:call-template name="addcurrency">
        </xsl:call-template>
      </tr>
    </xsl:for-each>
  </xsl:template>

  <xsl:template name="addcurrency">
    <xsl:choose>
      <xsl:when test="$country='US'">
        <td>
          <xsl:value-of select="price"/> US dollars
        </td>
      </xsl:when>
      <xsl:when test="$country='UK'">
        <td>
          <xsl:value-of select="price"/> UK pounds
        </td>
      </xsl:when>
      <xsl:otherwise>
        <td>
          <xsl:value-of select="price"/>
        </td>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

</xsl:stylesheet>

