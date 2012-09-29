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
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using CalculatorClient.CalculatorServiceReference;

namespace CalculatorClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Random r = new Random();
            textValue1.Text = (r.NextDouble() * 10).ToString();
            textValue2.Text = (r.NextDouble() * 10).ToString();
        }

        private void btnInvokeService_Click(object sender, RoutedEventArgs e)
        {
            CalculateResults();
        }

        private void CalculateResults()
        {
            CalculatorServiceClient proxy = null;
            try
            {
                double value1 = Convert.ToDouble(textValue1.Text);
                double value2 = Convert.ToDouble(textValue2.Text);

                string endpointName;

                if (ComboBoxServiceConnection.SelectedIndex == 0)
                    endpointName = "CalculatorService";
                else
                {
                    endpointName = "RouterService";
                }

                proxy = new CalculatorServiceClient(endpointName);

                using (OperationContextScope scope =
                    new OperationContextScope(proxy.InnerChannel))
                {

                    AddOptionalRoundingHeader(proxy);

                    labelAddResult.Text = proxy.Add(value1, value2).ToString();
                    labelSubResult.Text = proxy.Subtract(value1, value2).ToString();
                    labelMultResult.Text = proxy.Multiply(value1, value2).ToString();
                    if (value2 != 0.00)
                        labelDivResult.Text = proxy.Divide(value1, value2).ToString();
                    else
                        labelDivResult.Text = "Divide by 0";

                    proxy.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid numeric value, cannot calculate", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (TimeoutException)
            {
                if (proxy != null)
                    proxy.Abort();
                MessageBox.Show("Timeout - cannot connect to service", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (CommunicationException)
            {
                if (proxy != null)
                    proxy.Abort();
                MessageBox.Show("Unable to communicate with the service", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (proxy != null)
                    proxy.Close();
            }
        }

        private void AddOptionalRoundingHeader(
            CalculatorServiceClient proxy)
        {
            // TODO: Implement this method
        }
    }
}
