<?xml version="1.0"?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:template match="/Products">
  <xsl:for-each select="Category">
    <b><xsl:value-of select="@title"/></b><br/>
    <xsl:for-each select="Product">
	    -<xsl:value-of select="@title"/><br/>
    </xsl:for-each>
  </xsl:for-each>
</xsl:template>

</xsl:stylesheet>