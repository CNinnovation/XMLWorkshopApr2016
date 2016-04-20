<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:import href="BasicRules.xsl" />

  <xsl:template match="/">
    <HTML>
    <H1>Sorted by total salary (basic + bonus)</H1>

    <TABLE WIDTH="100%" BORDER="1">
    <THEAD STYLE="COLOR: red; FONT-SIZE: 12pt">
      <TR>
        <TD WIDTH="30%" ALIGN="LEFT" >Name</TD> 
        <TD WIDTH="30%" ALIGN="LEFT" >Region</TD> 
        <TD WIDTH="25%" ALIGN="RIGHT">Total Salary</TD> 
        <TD WIDTH="15%" ALIGN="RIGHT">Vacation Remaining</TD>
      </TR>
    </THEAD>

    <TBODY STYLE="COLOR: blue; FONT-SIZE: 12pt">

      <xsl:apply-templates select="employees/employee">
        <xsl:sort 
            select="salary/basic * (1 + salary/bonus)" 
            data-type="number" />
      </xsl:apply-templates>

    </TBODY>
    </TABLE>
    </HTML>
  </xsl:template>


  <xsl:template match="salary">

    <xsl:apply-imports /> 

    <BR/>
    <I>
    EUR  <xsl:value-of select="format-number(basic, '#,000.00')"/> +
       <xsl:value-of select="format-number(bonus, '#.0#%')"/>
    </I>

  </xsl:template>

</xsl:stylesheet>
