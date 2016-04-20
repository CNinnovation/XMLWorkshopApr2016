<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

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
			<td><font size="5"><b>Code</b></font></td>
			<td><font size="5"><b>Description</b></font></td>
			<td><font size="5"><b>Price</b></font></td>
		</tr>
		<xsl:call-template name="createtable"/>
	</table>
</xsl:template>

<xsl:template name="createtable">
	<tr>
		<td><xsl:value-of select="product/@code"/></td>
		<td><xsl:value-of select="product/description"/></td>
		<xsl:call-template name="addcurrency"/>
	</tr>
</xsl:template>

<xsl:template name="addcurrency">
	<td><xsl:value-of select="product/price"/> US dollars</td>
</xsl:template>



</xsl:stylesheet>