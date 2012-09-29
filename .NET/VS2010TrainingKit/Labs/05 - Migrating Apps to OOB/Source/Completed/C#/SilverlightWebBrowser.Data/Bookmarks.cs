// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;

namespace SilverlightWebBrowser.Data
{
    public class Bookmarks : ObservableObject
    {
        private ObservableCollection<Site> sites;
        public ObservableCollection<Site> Sites
        {
            get { return sites; }
            set
            {
                sites = value;
                OnPropertyChanged("Sites");
            }
        }

        public Bookmarks()
        {
            Sites = new ObservableCollection<Site>()
                        {
                            new Site(){Date = new DateTime(2010,10,21,17,05,17), Icon="/Images/blogger.png", Title="Blogger", Uri="http://blogger.com"},
                            new Site(){Date = new DateTime(2010,10,21,16,05,17), Icon="/Images/delicious.png", Title="Delicious", Uri="http://delicio.us"},
                            new Site(){Date = new DateTime(2010,10,21,15,05,17), Icon="/Images/deviantart.png", Title="Deviant Art", Uri="http://deviantart.com"},
                            new Site(){Date = new DateTime(2010,10,21,14,05,17), Icon="/Images/digg.png", Title="Digg", Uri="http://digg.com"},
                            new Site(){Date = new DateTime(2010,10,21,13,05,17), Icon="/Images/facebook.png", Title="Facebook", Uri="http://facebook.com"},
                            new Site(){Date = new DateTime(2010,10,21,12,05,17), Icon="/Images/flickr.png", Title="Flickr", Uri="http://www.flickr.com/"},
                            new Site(){Date = new DateTime(2010,10,21,18,05,17), Icon="/Images/linkedin.png", Title="LinkedIn", Uri="http://linkedin.com"},
                            new Site(){Date = new DateTime(2010,10,21,17,05,17), Icon="/Images/reddit.png", Title="Reddit", Uri="http://reddit.com"},
                            new Site(){Date = new DateTime(2010,10,21,16,05,17), Icon="/Images/skype.png", Title="Skype", Uri="http://skype.com"},
                            new Site(){Date = new DateTime(2010,10,21,15,05,17), Icon="/Images/twitter.png", Title="Twitter", Uri="http://twitter.com"},
                            new Site(){Date = new DateTime(2010,10,21,14,05,17), Icon="/Images/vimeo.png", Title="Vimeo", Uri="http://vimeo.com"},
                            new Site(){Date = new DateTime(2010,10,21,13,05,17), Icon="/Images/wordpress.png", Title="Wordpress", Uri="http://wordpress.com"},
                            new Site(){Date = new DateTime(2010,10,21,12,05,17), Icon="/Images/youtube.png", Title="YouTube", Uri="http://www.youtube.com/"},
                            new Site(){Date = new DateTime(2010,10,21,17,05,17), Icon="/Images/42_64x64.png", Title="Maps", Uri="http://maps.bing.com"},
                            new Site(){Date = new DateTime(2010,10,21,16,05,17), Icon="/Images/44_64x64.png", Title="Twitter", Uri="http://twitter.com"},
                            new Site(){Date = new DateTime(2010,10,21,15,05,17), Icon="/Images/45_64x64.png", Title="Search", Uri="http://bing.com"},
                            new Site(){Date = new DateTime(2010,10,21,14,05,17), Icon="/Images/54_64x64.png", Title="Weather", Uri="http://weather.com"},
                            new Site(){Date = new DateTime(2010,10,21,13,05,17), Icon="/Images/44_64x64.png", Title="Amazon", Uri="http://amazon.com"},
                            new Site(){Date = new DateTime(2010,10,21,12,05,17), Icon="/Images/9_64x64.png", Title="BBC", Uri="http://www.bbc.co.uk/"},
                            new Site(){Date = new DateTime(2010,10,21,18,05,17), Icon="/Images/39_64x64.png", Title="Mail", Uri="http://en.wikipedia.org/wiki/Email"}

                        };
        }
    }
}