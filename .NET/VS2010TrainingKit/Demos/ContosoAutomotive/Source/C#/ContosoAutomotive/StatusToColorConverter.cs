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

namespace ContosoAutomotive
{
    using System;
    using System.Windows.Data;
    using System.Windows.Media;
    using ContosoAutomotive.Common;

    [ValueConversion(typeof(QueryStatus), typeof(Brush))]
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Brush))
            {
                return null;
            }

            var status = (QueryStatus)value;
            if (status == QueryStatus.Running)
            {
                return Brushes.Yellow;
            }
            else if (status == QueryStatus.Finished)
            {
                return Brushes.LightGreen;
            }
            else
            {
                return Brushes.Gray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(QueryStatus))
            {
                return null;
            }

            var color = (Brush)value;
            if (color == Brushes.Yellow)
            {
                return QueryStatus.Running;
            }
            else if (color == Brushes.LightGreen)
            {
                return QueryStatus.Finished;
            }
            else
            {
                return QueryStatus.NotStarted;
            }
        }
    }
}
