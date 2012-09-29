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
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;

namespace Southridge.Converters
{
    public class Converters
    {
        public class StringToBoolConverter : IValueConverter
        {
            object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null)
                {
                    try
                    {
                        bool b = (bool)value;
                        return b;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null)
                {
                    bool b;

                    try
                    {
                        b = (bool)value;
                    }
                    catch
                    {
                        return "false";
                    }

                    if (b == true)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
                else
                {
                    return "false";
                }
            }
        }

        public class BoolToVisibilityConverter : IValueConverter
        {

            #region IValueConverter Members

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    bool b = (bool)value;
                    if (b) return Visibility.Visible; else return Visibility.Hidden;
                }
                catch
                {
                    return Visibility.Visible;
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    Visibility v = (Visibility)value;
                    if (v == Visibility.Visible) return true; else return false;
                }
                catch
                {
                    return Visibility.Visible;
                }
            }

            #endregion
        }

        public class BoolToOpacityConverter : IValueConverter
        {

            #region IValueConverter Members

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    bool b = (bool)value;
                    if (b) return 1; else return 0;
                }
                catch
                {
                    return 1;
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        public class ObjectToTypeName : IValueConverter
        {

            #region IValueConverter Members

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null)
                {
                    return value.GetType().Name;
                }
                else
                {
                    return null;
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}