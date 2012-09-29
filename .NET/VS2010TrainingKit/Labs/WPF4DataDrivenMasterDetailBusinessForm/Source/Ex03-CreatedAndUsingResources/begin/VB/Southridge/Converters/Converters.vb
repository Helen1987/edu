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

    Public Class Converters
        Public Class StringToBoolConverter
            Implements IValueConverter

            Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
                If (value IsNot Nothing) Then
                    Try
                        Dim b = CBool(value)
                        Return b
                    Catch ex As Exception
                        Return False
                    End Try
                Else
                    Return False
                End If
            End Function

            Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
                If (value IsNot Nothing) Then
                    Dim b As Boolean

                    Try
                        b = CBool(value)
                    Catch ex As Exception
                        Return "False"
                    End Try

                    If (b = True) Then
                        Return "True"
                    Else
                        Return "False"
                    End If
                Else
                    Return "False"
                End If
            End Function
        End Class

        Public Class BoolToVisibilityConverter
            Implements IValueConverter

            Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
                Try
                    Dim b = CBool(value)
                    If (b) Then
                        Return Visibility.Visible
                    Else
                        Return Visibility.Hidden
                    End If
                Catch ex As Exception
                    Return Visibility.Visible
                End Try
            End Function

            Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
                Try
                    Dim v = CType(value, Visibility)
                    If (v = Visibility.Visible) Then
                        Return True
                    Else : Return False
                    End If
                Catch ex As Exception
                    Return Visibility.Visible
                End Try
            End Function
        End Class

        Public Class BoolToOpacityConverter
            Implements IValueConverter

            Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
                Try
                    Dim b = CBool(value)
                    If (b) Then
                        Return 1
                    Else
                        Return 0
                    End If
                Catch ex As Exception
                    Return 1
                End Try
            End Function

            Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
                Throw New NotImplementedException()
            End Function
        End Class

        Public Class ObjectToTypeName
            Implements IValueConverter

            Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
                If (value IsNot Nothing) Then
                    Return value.GetType().Name
                Else
                    Return Nothing
                End If
            End Function

            Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
                Throw New NotImplementedException()
            End Function
        End Class
    End Class
