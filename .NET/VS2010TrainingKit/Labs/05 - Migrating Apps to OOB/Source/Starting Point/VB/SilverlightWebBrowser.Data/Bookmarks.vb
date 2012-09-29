' ----------------------------------------------------------------------------------
' Microsoft Developer & Platform Evangelism
' 
' Copyright (c) Microsoft Corporation. All rights reserved.
' 
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
' OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ----------------------------------------------------------------------------------
' The example companies, organizations, products, domain names,
' e-mail addresses, logos, people, places, and events depicted
' herein are fictitious.  No association with any real company,
' organization, product, domain name, email address, logo, person,
' places, or events is intended or should be inferred.
' ----------------------------------------------------------------------------------

Imports System.Collections.ObjectModel

Namespace SilverlightWebBrowser.Data
	Public Class Bookmarks
		Inherits ObservableObject
'INSTANT VB NOTE: The variable sites was renamed since Visual Basic does not allow class members with the same name:
		Private sites_Renamed As ObservableCollection(Of Site)
		Public Property Sites() As ObservableCollection(Of Site)
			Get
				Return sites_Renamed
			End Get
			Set(ByVal value As ObservableCollection(Of Site))
				sites_Renamed = value
				OnPropertyChanged("Sites")
			End Set
		End Property

		Public Sub New()
            Sites = New ObservableCollection(Of Site)() From {New Site() With {.Date = New DateTime(2010, 10, 21, 17, 5, 17), .Icon = "/Images/blogger.png", .Title = "Blogger", .Uri = "http://blogger.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 16, 5, 17), .Icon = "/Images/delicious.png", .Title = "Delicious", .Uri = "http://delicio.us"}, New Site() With {.Date = New DateTime(2010, 10, 21, 15, 5, 17), .Icon = "/Images/deviantart.png", .Title = "Deviant Art", .Uri = "http://deviantart.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 14, 5, 17), .Icon = "/Images/digg.png", .Title = "Digg", .Uri = "http://digg.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 13, 5, 17), .Icon = "/Images/facebook.png", .Title = "Facebook", .Uri = "http://facebook.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 12, 5, 17), .Icon = "/Images/flickr.png", .Title = "Flickr", .Uri = "http://www.flickr.com/"}, New Site() With {.Date = New DateTime(2010, 10, 21, 18, 5, 17), .Icon = "/Images/linkedin.png", .Title = "LinkedIn", .Uri = "http://linkedin.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 17, 5, 17), .Icon = "/Images/reddit.png", .Title = "Reddit", .Uri = "http://reddit.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 16, 5, 17), .Icon = "/Images/skype.png", .Title = "Skype", .Uri = "http://skype.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 15, 5, 17), .Icon = "/Images/twitter.png", .Title = "Twitter", .Uri = "http://twitter.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 14, 5, 17), .Icon = "/Images/vimeo.png", .Title = "Vimeo", .Uri = "http://vimeo.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 13, 5, 17), .Icon = "/Images/wordpress.png", .Title = "Wordpress", .Uri = "http://wordpress.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 12, 5, 17), .Icon = "/Images/youtube.png", .Title = "YouTube", .Uri = "http://www.youtube.com/"}, New Site() With {.Date = New DateTime(2010, 10, 21, 17, 5, 17), .Icon = "/Images/42_64x64.png", .Title = "Maps", .Uri = "http://maps.bing.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 16, 5, 17), .Icon = "/Images/44_64x64.png", .Title = "Twitter", .Uri = "http://twitter.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 15, 5, 17), .Icon = "/Images/45_64x64.png", .Title = "Search", .Uri = "http://bing.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 14, 5, 17), .Icon = "/Images/54_64x64.png", .Title = "Weather", .Uri = "http://weather.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 13, 5, 17), .Icon = "/Images/44_64x64.png", .Title = "Amazon", .Uri = "http://amazon.com"}, New Site() With {.Date = New DateTime(2010, 10, 21, 12, 5, 17), .Icon = "/Images/9_64x64.png", .Title = "BBC", .Uri = "http://www.bbc.co.uk/"}, New Site() With {.Date = New DateTime(2010, 10, 21, 18, 5, 17), .Icon = "/Images/39_64x64.png", .Title = "Mail", .Uri = "http://en.wikipedia.org/wiki/Email"}}
		End Sub
	End Class
End Namespace