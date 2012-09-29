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

namespace HRClient
{
    using System;
    using System.Globalization;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.Windows.Forms;
    using HRClient.Properties;
    using System.Diagnostics;
    using HRClient.SubmitApp;

    public partial class HRForm : Form
    {
        HRClient.SubmitApp.ApplicationServiceClient proxy;
        delegate void SetTextCallback(string text);

        public HRForm()
        {
            this.InitializeComponent();
            SetFieldDefaults();
        }

        public void SetConfirmationText(string text)
        {
            this.Invoke(
                new MethodInvoker(() =>
                    {
                        this.confirmationTitle.Text = text;
                        Debug.WriteLine("*** Setting confirmation text = " + text);
                        this.confirmationPanel.Visible = true;
                        this.confirmationPanel.Update();
                    }));
        }

        private SubmitJobApplicationRequest CreateApplicationRequest()
        {
            return new SubmitJobApplicationRequest()
            {
                Resume = new ApplicantResume()
                {
                    Name = this.txtName.Text,
                    Email = this.txtEmail.Text,
                    Education = this.comboBoxEducation.Text,
                    NumReferences = String.IsNullOrEmpty(txtRefs.Text) ? 0 : Int32.Parse(this.txtRefs.Text.Trim(), CultureInfo.CurrentCulture)
                },
                RequestID = Guid.NewGuid()
            };
        }

        private void SubmitJobApplication()
        {
            ShowConfirmationPanel();
            proxy = new HRClient.SubmitApp.ApplicationServiceClient();
            proxy.BeginSubmitJobApplication(CreateApplicationRequest(), OnStartCompleted, null);
        }

        private void OnStartCompleted(IAsyncResult asr)
        {
            try
            {
                SubmitJobApplicationResponse result = (SubmitJobApplicationResponse)proxy.EndSubmitJobApplication(asr);
                SetConfirmationText(result.ResponseText);
                ShowStartAgainButton();
                proxy.Close();
            }
            catch (CommunicationException)
            {
                ShowExceptionText(Resources.CommException);
                proxy.Abort();
            }
            catch (TimeoutException)
            {
                ShowExceptionText(Resources.TimeoutText);
                proxy.Abort();
            }
            catch (Exception)
            {
                proxy.Abort();
                throw;
            }
        }

        private void ShowExceptionText(string text)
        {
            SetConfirmationText(text);
            ShowStartAgainButton();
        }

        private void ShowStartAgainButton()
        {
            this.Invoke(
                new MethodInvoker(() =>
                {
                    this.buttonStartAgain.Visible = true;
                }));
        }

        private void ShowConfirmationPanel()
        {
            this.confirmationPanel.Visible = true;
            this.buttonStartAgain.Visible = false;
            this.confirmationTitle.Text = Resources.SubmitText;
            this.Update();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SubmitJobApplication();
        }

        private void buttonStartAgain_Click(object sender, EventArgs e)
        {
            SetFieldDefaults();
            this.confirmationPanel.Visible = false;
        }

        private void SetFieldDefaults()
        {
            Random r = new Random();

            if (r.Next() % 2 == 0)
                this.txtName.Text = "John Smith";
            else
                this.txtName.Text = "Jane Smith";
            this.txtRefs.Text = "5";
            this.txtEmail.Text = "jsmith@example.com";
            this.comboBoxEducation.Text = r.Next() % 2 == 0 ? "Bachelors" : "Masters";
        }
    }
}
