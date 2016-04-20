<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:key name="deptkey" match="department" use="@code"/>
	<xsl:key name="suppkey" match="supplier" use="code"/>

	<xsl:template match="/">
		<HTML>
			<BODY>
				<H1>Catalog</H1>
				<xsl:apply-templates select="//products"/><br/><br/>
				<H1>Departments</H1>
				<xsl:apply-templates select="//departments"/><br/><br/>
				<H1>Suppliers</H1>
				<xsl:apply-templates select="//suppliers"/><br/><br/>
			</BODY>
		</HTML>
	</xsl:template>

	<xsl:template match="products">
		<table border="1" cellpadding="5">
			<tr>
				<td><b>Product Code</b></td>
				<td><b>Department</b></td>
				<td><b>Description</b></td>
				<td><b>	Price</b></td>
				<td><b>	Supplier</b></td>
			</tr>
			<xsl:for-each select="product">
				<tr>
					<td><xsl:value-of select="@code"/></td>
					<td><a href="#{generate-id(key('deptkey',department))}">
						<xsl:value-of select="key('deptkey',department)/name"/></a>
					</td>
					<td><xsl:value-of select="description"/>	</td>
					<td><xsl:value-of select="price"/></td>
					<td><a href="#{generate-id(key('suppkey',supplier))}">
						<xsl:value-of select="key('suppkey',supplier)/name"/></a>
					</td>
				</tr>
			</xsl:for-each>
		</table>
	</xsl:template>

	<xsl:template match="departments">
		<xsl:for-each select="department">
			<b><a name="{generate-id()}"><xsl:value-of select="name"/> Department</a></b><br/>
			Department Code - <xsl:value-of select="@code"/><br/>
			Manager - <xsl:value-of select="manager"/><br/>
			Buyer - <xsl:value-of select="buyer"/><br/><br/>
		</xsl:for-each>
	</xsl:template>

	<xsl:template match="suppliers">
		<xsl:for-each select="supplier">
			<b><a name="{generate-id()}"><xsl:value-of select="name"/></a></b><br/>
			Supplier Code - <xsl:value-of select="code"/><br/>
			Email - <xsl:value-of select="email"/><br/><br/>
		</xsl:for-each>
	</xsl:template>

</xsl:stylesheet>