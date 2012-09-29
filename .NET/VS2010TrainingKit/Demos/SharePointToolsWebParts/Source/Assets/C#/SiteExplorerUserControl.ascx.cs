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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace MetroWebParts.SiteExplorer
{
    public partial class SiteExplorerUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        const string SITE_IMG = @"\_layouts\images\FPWEB16.GIF";
        const string FOLDER_IMG = @"\_layouts\images\FOLDER16.GIF";
        const string GHOSTED_FILE_IMG = @"\_layouts\images\NEWDOC.GIF";
        const string UNGHOSTED_FILE_IMG = @"\_layouts\images\RAT16.GIF";

        protected override void OnPreRender(EventArgs e)
        {
            treeSiteFiles.Nodes.Clear();
            SPWeb site = SPContext.Current.Web;
            SPFolder rootFolder = site.RootFolder;
            TreeNode rootNode = new TreeNode(site.Url, site.Url, SITE_IMG);
            LoadFolderNodes(rootFolder, rootNode);
            treeSiteFiles.Nodes.Add(rootNode);
            treeSiteFiles.ExpandDepth = 1;
        }

        protected void LoadFolderNodes(SPFolder folder, TreeNode folderNode)
        {
            foreach (SPFolder childFolder in folder.SubFolders)
            {
                TreeNode childFolderNode = new TreeNode(childFolder.Name, childFolder.Name, FOLDER_IMG);
                childFolderNode.NavigateUrl = SPContext.Current.Site.MakeFullUrl(childFolder.Url);
                LoadFolderNodes(childFolder, childFolderNode);
                folderNode.ChildNodes.Add(childFolderNode);
            }

            foreach (SPFile file in folder.Files)
            {
                TreeNode fileNode;
                if (file.CustomizedPageStatus == SPCustomizedPageStatus.Uncustomized)
                {
                    fileNode = new TreeNode(file.Name, file.Name, GHOSTED_FILE_IMG);
                }
                else
                {
                    fileNode = new TreeNode(file.Name, file.Name, UNGHOSTED_FILE_IMG);
                }

                fileNode.NavigateUrl = SPContext.Current.Site.MakeFullUrl(file.Url);
                folderNode.ChildNodes.Add(fileNode);
            }
        }
    }
}
