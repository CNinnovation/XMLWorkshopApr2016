<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:key name="deptkey" match="department" use="@code"/>

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
			<tr>
				<td><b>Product Code</b></td>
				<td><b>Department</b></td>
				<td><b>Dept Manager</b></td>
				<td><b>Buyer</b></td>
				<td><b>Description</b></td>
				<td><b>Price</b></td>
				<td><b>Supplier</b></td>
			</tr>
			<xsl:for-each select="product">
				<tr>
					<td><xsl:value-of select="@code"/></td>
					<td><xsl:value-of select="key('deptkey',department)/name"/></td>

					<td><xsl:value-of select="key('deptkey',department)/manager"/></td>
					<td><xsl:value-of select="key('deptkey',department)/buyer"/></td>
					<td><xsl:value-of select="description"/>	</td>
					<td><xsl:value-of select="price"/></td>
		
					<td><xsl:value-of select="supplier"/></td>
				</tr>
			</xsl:for-each>
				

		</table>
</xsl:template>

</xsl:stylesheet>