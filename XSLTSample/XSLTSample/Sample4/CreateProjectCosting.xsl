<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

   <!-- Global parameters, specifying project code and location -->
   <xsl:param name="pcode">1234</xsl:param>
   <xsl:param name="plocation">Redmond</xsl:param>
	
	<xsl:output method="xml" indent="yes"/>

   <xsl:template match="/">

      <!-- create <project-costing> document element        -->
      <!-- add project-code and project-location attributes -->
      <project-costing 
         project-code="{$pcode}" 
         project-location="{$plocation}" 
         xmlns="www.litware.com">

         <!-- process each <employee> element -->
         <xsl:for-each select="employees/employee">
         <xsl:sort select="salary" data-type="number"/>

            <!-- declare a variable to test if employee is local or remote -->
            <xsl:variable name="status">
               <xsl:choose>
                  <xsl:when test="region=$plocation">local-employee</xsl:when>
                  <xsl:otherwise>remote-employee</xsl:otherwise>
               </xsl:choose>
            </xsl:variable>

            <!-- create <local-employee> or <remote-employee> element -->
            <xsl:element name="{$status}">

               <!-- create daily-rate attribute -->
               <xsl:attribute name="daily-rate">
                  <xsl:value-of select="format-number(salary div 240, '#,000.00')" />
               </xsl:attribute>

               <!-- if region is remote, create a location attribute -->
               <xsl:if test="$status='remote-employee'">
                  <xsl:attribute name="location">
                     <xsl:value-of select="region"/>
                  </xsl:attribute>
               </xsl:if>

               <!-- create rank attribute -->
               <xsl:attribute name="rank">
                  <xsl:number value="position()" />
               </xsl:attribute>

               <!-- create <fullname> element -->
               <fullname><xsl:value-of select="name"/></fullname>

            <!-- define the </xsl:element> tag  -->
            </xsl:element>
         </xsl:for-each>

      </project-costing>

   </xsl:template>

</xsl:stylesheet>
