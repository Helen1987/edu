using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Web.Services3.Security.Tokens;

namespace AuthenticationComponent
{
	public class CustomAuthenticator : UsernameTokenManager
	{
		// This method returns the password for the provided username
		// WSE will determine if they match
		protected override string AuthenticateToken(UsernameToken token)
		{
			string username = token.Username;

			// In real site, would query database or check XML file...
			if (username == "dan")
			{
				return "secret";
			}
			else if (username == "jenny")
			{
				return "opensesame";
			}
			else
			{
				return "";
			}
		}
	}
}
