<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
		<HTML>
			<HEAD>
				<H1>Catalog</H1>
			</HEAD>
			<BODY>
				<xsl:apply-templates/>
			</BODY>
		</HTML>
	</xsl:template>

	<xsl:template match="catalog">
		<table border="1" cellpadding="5">
			<tr><b>
				<td>Product Code</td>
				<td>Department</td>
				<td>Description</td>
				<td>Price</td>
			</b></tr>
			<xsl:for-each select="product">
				<tr>
					<td><xsl:value-of select="@code"/></td>		
					<td><xsl:value-of select="department"/></td>		
					<td><xsl:value-of select="description"/></td>		
					<td><xsl:value-of select="price"/></td>		
				</tr>
			</xsl:for-each>

			<xsl:for-each select="document('ladies.xml')//product">
				<tr>
					<td><xsl:value-of select="@code"/></td>		
					<td><xsl:value-of select="department"/></td>		
					<td><xsl:value-of select="description"/></td>		
					<td><xsl:value-of select="price"/></td>		
				</tr>
			</xsl:for-each>
	
		</table>
</xsl:template>

</xsl:stylesheet>