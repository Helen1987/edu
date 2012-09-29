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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Activities;
using HRApplicationServices.Data;

namespace HRApplicationServices
{
    public partial class HireApproval : System.Web.UI.Page
    {
        Applicant applicant;
        int appID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetApplicant();
            }
        }

        private void SendHumanScreenComplete(bool hire)
        {
            // TODO: Implement this method
        }

        private void GetApplicant()
        {
            appID = GetAppIDFromRequest();

            if (appID == -1)
            {
                string s = GetRedirectString("HRMessage.aspx?MsgID=ErrInvalidAppID");
                Response.Redirect(s, true);
            }
            else
            {
                using (HRApplicationDataEntities ctx = new HRApplicationDataEntities())
                {
                    var query = from a in ctx.Applicants
                                where a.ApplicationID == appID
                                select a;

                    applicant = query.FirstOrDefault();

                    if (applicant == null)
                        Response.Redirect(GetRedirectString("HRMessage.aspx?MsgID=ErrUnknownAppID"), true);
                    else
                    {
                        this.LabelAppID.Text = appID.ToString();
                        this.LabelName.Text = applicant.ApplicantName;
                        this.LabelEducation.Text = applicant.Education;
                        this.LabelReferences.Text = applicant.NumberOfReferences.ToString();
                        this.LabelRequestID.Text = applicant.RequestID.ToString();
                    }
                }
            }
        }

        protected void ButtonHire_Click(object sender, EventArgs e)
        {
            SendHumanScreenComplete(true);

            // Redirect to message page
            Response.Redirect(
                GetRedirectString(
                "HRMessage.aspx?MsgID=AppIDStatusUpdated&AppID={0}&Status={1}",
                LabelAppID.Text, "Hire"),
                true);
        }

        protected void ButtonNoHire_Click(object sender, EventArgs e)
        {
            SendHumanScreenComplete(false);

            // Redirect to message page
            Response.Redirect(
                GetRedirectString(
                "HRMessage.aspx?MsgID=AppIDStatusUpdated&AppID={0}&Status={1}",
                LabelAppID.Text, "Hire"),
                true);
        }

        private string GetRedirectString(string UriFormat, params object[] args)
        {
            return Server.UrlPathEncode(string.Format(UriFormat, args));
        }
        private int GetAppIDFromRequest()
        {
            string appIDArg = Request.QueryString["AppID"];

            if (!string.IsNullOrEmpty(appIDArg))
            {
                try
                {
                    return Convert.ToInt32(appIDArg);
                }
                catch (FormatException)
                {
                    return -1;
                }
            }
            else
                return -1;
        }
    }
}