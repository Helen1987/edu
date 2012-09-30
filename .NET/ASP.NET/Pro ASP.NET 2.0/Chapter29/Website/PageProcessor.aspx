<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageProcessor.aspx.cs" Inherits="PageProcessor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript">
	var iLoopCounter = 1;
	var iMaxLoop = 6;
	var iIntervalId;
	
	function BeginPageLoad()
	{
	    /* Redirect the browser to another page while keeping focus */
		location.href = "<%=PageToLoad %>";
		/* Update progress meter every 1/2 second */
		iIntervalId = window.setInterval("iLoopCounter=UpdateProgressMeter(iLoopCounter,iMaxLoop)", 500);
	}
	function EndPageLoad()
	{
		window.clearInterval(iIntervalId);
		ProgressMeter.innerText = "Page Loaded - Now Transfering";
	}
	function UpdateProgressMeter(iCurrentLoopCounter, iMaximumLoops)
	{
		iCurrentLoopCounter += 1;
		if(iCurrentLoopCounter <= iMaximumLoops)
		 {
			ProgressMeter.innerText += ".";
			return iCurrentLoopCounter
		 }
		else
		 {
			ProgressMeter.innerText = "";
			return 1;
		 }
	}	
		</script>
	</head>
	<body onLoad="javascript:BeginPageLoad();" onUnload="javascript:EndPageLoad();">

    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0" width="99%" height="99%" align="center"
				vAlign="middle">
				<tr>
					<td align="center" vAlign="middle">
						<font color="navy" size="5"><span id="MessageText">Loading Page - Please Wait</span>
							<span id="ProgressMeter" style="WIDTH:25px;TEXT-ALIGN:left"></span></font>
					</td>
				</tr>
			</table>
    </div>
    </form>
</body>
</html>
