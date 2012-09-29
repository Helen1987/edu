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

Imports System.Collections.Generic

Public Class Employee
    Public Property FirstName As String

    Public Property LastName As String

    Public Property Address As String

    Public Property HireDate As DateTime

    Public Property EmployeeID As Integer
End Class

Public Class EmployeeList
    Inherits List(Of Employee)
    Public Sub New()
        Add(New Employee With {.EmployeeID = 1, .FirstName = "Jay", .LastName = "Adams", .HireDate = DateTime.Parse("2007/1/1")})
        Add(New Employee With {.EmployeeID = 2, .FirstName = "Adam", .LastName = "Barr", .HireDate = DateTime.Parse("2006/3/15")})
        Add(New Employee With {.EmployeeID = 3, .FirstName = "Karen", .LastName = "Berge", .HireDate = DateTime.Parse("2005/6/17")})
        Add(New Employee With {.EmployeeID = 4, .FirstName = "Scott", .LastName = "Bishop", .HireDate = DateTime.Parse("2000/3/19")})
        Add(New Employee With {.EmployeeID = 5, .FirstName = "Jo", .LastName = "Brown", .HireDate = DateTime.Parse("2003/7/17")})
        Add(New Employee With {.EmployeeID = 6, .FirstName = "David", .LastName = "Campbell", .HireDate = DateTime.Parse("2005/9/13")})
        Add(New Employee With {.EmployeeID = 7, .FirstName = "Rob", .LastName = "Caron", .HireDate = DateTime.Parse("2002/12/3")})
        Add(New Employee With {.EmployeeID = 8, .FirstName = "Jane", .LastName = "Clayton", .HireDate = DateTime.Parse("2008/7/1")})
        Add(New Employee With {.EmployeeID = 9, .FirstName = "Pat", .LastName = "Coleman", .HireDate = DateTime.Parse("2008/1/7")})
        Add(New Employee With {.EmployeeID = 10, .FirstName = "Aaron", .LastName = "Con", .HireDate = DateTime.Parse("2001/11/1")})
        Add(New Employee With {.EmployeeID = 11, .FirstName = "Don", .LastName = "Hall", .HireDate = DateTime.Parse("2006/4/21")})
        Add(New Employee With {.EmployeeID = 12, .FirstName = "Joe", .LastName = "Howard", .HireDate = DateTime.Parse("2006/7/19")})
        Add(New Employee With {.EmployeeID = 13, .FirstName = "Jim", .LastName = "Kim", .HireDate = DateTime.Parse("2001/3/9")})
        Add(New Employee With {.EmployeeID = 14, .FirstName = "Eric", .LastName = "Lang", .HireDate = DateTime.Parse("2005/7/15")})
        Add(New Employee With {.EmployeeID = 15, .FirstName = "Jose", .LastName = "Lugo", .HireDate = DateTime.Parse("2003/8/6")})
        Add(New Employee With {.EmployeeID = 16, .FirstName = "Nikki", .LastName = "McCormick", .HireDate = DateTime.Parse("2005/5/18")})
        Add(New Employee With {.EmployeeID = 17, .FirstName = "Susan", .LastName = "Metters", .HireDate = DateTime.Parse("2002/8/5")})
        Add(New Employee With {.EmployeeID = 18, .FirstName = "Linda", .LastName = "MIctchell", .HireDate = DateTime.Parse("2006/10/1")})
        Add(New Employee With {.EmployeeID = 19, .FirstName = "Kim", .LastName = "Ralls", .HireDate = DateTime.Parse("2002/12/7")})
        Add(New Employee With {.EmployeeID = 20, .FirstName = "Jeff", .LastName = "Smith", .HireDate = DateTime.Parse("2001/3/30")})
    End Sub
End Class

Public Class EmployeeHierarchy
    Inherits Tree(Of Employee)
    Public Sub New()
        'root
        Data = New Employee With {.EmployeeID = 1, .FirstName = "Jay", .LastName = "Adams", .HireDate = DateTime.Parse("2007/1/1")}

        '1st level
        Left = New Tree(Of Employee)()
        Right = New Tree(Of Employee)()
        Left.Data = New Employee With {.EmployeeID = 2, .FirstName = "Adam", .LastName = "Barr", .HireDate = DateTime.Parse("2006/3/15")}
        Right.Data = New Employee With {.EmployeeID = 17, .FirstName = "Karen", .LastName = "Berge", .HireDate = DateTime.Parse("2005/6/17")}

        '2nd level
        'left
        Left.Left = New Tree(Of Employee)()
        Left.Right = New Tree(Of Employee)()
        Left.Left.Data = New Employee With {.EmployeeID = 3, .FirstName = "Scott", .LastName = "Bishop", .HireDate = DateTime.Parse("2000/3/19")}
        Left.Right.Data = New Employee With {.EmployeeID = 14, .FirstName = "Jo", .LastName = "Brown", .HireDate = DateTime.Parse("2003/7/17")}

        'right
        Right.Left = New Tree(Of Employee)()
        Right.Right = New Tree(Of Employee)()
        Right.Left.Data = New Employee With {.EmployeeID = 18, .FirstName = "David", .LastName = "Campbell", .HireDate = DateTime.Parse("2005/9/13")}
        Right.Right.Data = New Employee With {.EmployeeID = 19, .FirstName = "Rob", .LastName = "Caron", .HireDate = DateTime.Parse("2002/12/3")}

        '3rd level
        'left
        'left.left
        Left.Left.Left = New Tree(Of Employee)()
        Left.Left.Right = New Tree(Of Employee)()
        Left.Left.Left.Data = New Employee With {.EmployeeID = 4, .FirstName = "Jane", .LastName = "Clayton", .HireDate = DateTime.Parse("2008/7/1")}
        Left.Left.Right.Data = New Employee With {.EmployeeID = 7, .FirstName = "Pat", .LastName = "Coleman", .HireDate = DateTime.Parse("2008/1/7")}
        'left.right
        Left.Right.Left = New Tree(Of Employee)()
        Left.Right.Right = New Tree(Of Employee)()
        Left.Right.Left.Data = New Employee With {.EmployeeID = 15, .FirstName = "Aaron", .LastName = "Con", .HireDate = DateTime.Parse("2001/11/1")}
        Left.Right.Right.Data = New Employee With {.EmployeeID = 16, .FirstName = "Don", .LastName = "Hall", .HireDate = DateTime.Parse("2006/4/21")}

        '4th level
        'left.left.left
        Left.Left.Left.Left = New Tree(Of Employee)()
        Left.Left.Left.Right = New Tree(Of Employee)()
        Left.Left.Left.Left.Data = New Employee With {.EmployeeID = 5, .FirstName = "Joe", .LastName = "Howard", .HireDate = DateTime.Parse("2006/7/19")}
        Left.Left.Left.Right.Data = New Employee With {.EmployeeID = 6, .FirstName = "Jim", .LastName = "Kim", .HireDate = DateTime.Parse("2001/3/9")}
        'left.left.right
        Left.Left.Right.Left = New Tree(Of Employee)()
        Left.Left.Right.Right = New Tree(Of Employee)()
        Left.Left.Right.Left.Data = New Employee With {.EmployeeID = 8, .FirstName = "Eric", .LastName = "Lang", .HireDate = DateTime.Parse("2005/7/15")}
        Left.Left.Right.Right.Data = New Employee With {.EmployeeID = 11, .FirstName = "Jose", .LastName = "Lugo", .HireDate = DateTime.Parse("2003/8/6")}

        Left.Left.Right.Left.Left = New Tree(Of Employee)()
        Left.Left.Right.Left.Right = New Tree(Of Employee)()
        Left.Left.Right.Left.Left.Data = New Employee With {.EmployeeID = 9, .FirstName = "Nikki", .LastName = "McCormick", .HireDate = DateTime.Parse("2005/5/18")}
        Left.Left.Right.Left.Right.Data = New Employee With {.EmployeeID = 10, .FirstName = "Susan", .LastName = "Metters", .HireDate = DateTime.Parse("2002/8/5")}
        Left.Left.Right.Right.Left = New Tree(Of Employee)()
        Left.Left.Right.Right.Right = New Tree(Of Employee)()
        Left.Left.Right.Right.Left.Data = New Employee With {.EmployeeID = 12, .FirstName = "Linda", .LastName = "MIctchell", .HireDate = DateTime.Parse("2006/10/1")}
        Left.Left.Right.Right.Right.Data = New Employee With {.EmployeeID = 13, .FirstName = "Kim", .LastName = "Ralls", .HireDate = DateTime.Parse("2002/12/7")}
    End Sub
End Class

Public Class Tree(Of T)
    Public Data As T
    Public Left As Tree(Of T), Right As Tree(Of T)
End Class

Public NotInheritable Class PayrollServices
    Private Sub New()
    End Sub
    Public Shared Function GetPayrollDeduction(ByVal employee As Employee) As Decimal
        Console.WriteLine("Executing GetPayrollDeduction for employee {0}", employee.EmployeeID)

        Dim rand = New Random(DateTime.Now.Millisecond)
        Dim delay = rand.Next(1, 5)
        Dim count = 0
        Dim process = True

        Do While process
            System.Threading.Thread.Sleep(1000)
            count += 1
            If count >= delay Then
                process = False
            End If
        Loop

        Return delay
    End Function

    Public Shared Function GetEmployeeInfo(ByVal employee As Employee) As String
        Console.WriteLine("Executing GetPayrollDeduction for employee {0}", employee.EmployeeID)

        'Random rand = new Random(System.DateTime.Now.Millisecond);
        Const delay As Integer = 5
        Dim count = 0
        Dim process = True

        Do While process
            System.Threading.Thread.Sleep(1000)
            count += 1
            If count >= delay Then
                process = False
            End If
        Loop

        Return String.Format("{0} {1}, {2}", employee.EmployeeID, employee.LastName, employee.FirstName)
    End Function
End Class
