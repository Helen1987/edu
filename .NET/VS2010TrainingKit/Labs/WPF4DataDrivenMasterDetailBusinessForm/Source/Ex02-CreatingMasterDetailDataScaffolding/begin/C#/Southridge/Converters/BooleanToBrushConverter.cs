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
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Media;
using System.Data;

namespace Southridge.Converters
{
    [ValueConversion(typeof(Boolean),typeof(Brush))]
    public class BooleanToBrushConverter: IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Boolean inputValue;
            DataRowView rowView = value as DataRowView;

            if (rowView != null)
            {
                inputValue = (Boolean)rowView.Row[(string)parameter];
            }
            else
            {
                return null;
            }

            if (inputValue)
            {
                return Brushes.Green;
            }
            else
            {
                 return Brushes.Red;
            }    
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Brush b = value as Brush;
            if (b != null)
            {
                if (b.Equals(Brushes.Red))
                {
                    return false;
                }

                if (b.Equals(Brushes.Green))
                {
                    return true;
                }
            }
            return null;
        }
    }
}