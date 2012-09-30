<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
    <body>
      <xsl:apply-templates select="//DVD" />
    </body>
    </html>
  </xsl:template>

  <xsl:template match="DVD">
    <hr/>
    <h3><u><xsl:value-of select="Title" /></u></h3>
    <b>Price: </b> <xsl:value-of select="Price" /><br/>
    <b>Director: </b> <xsl:value-of select="Director" /><br/>
    <xsl:apply-templates select="Starring" />
  </xsl:template>

  <xsl:template match="Starring">
    <b>Starring:</b><br />
    <xsl:apply-templates select="Star" />
  </xsl:template>

  <xsl:template match="*">
    <li><xsl:value-of select="." /></li>
  </xsl:template>

</xsl:stylesheet>