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

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Linq
Imports System.Xml.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace PlinqMvpDemo
	Partial Public Class Form1
		Inherits Form
        Public Sub New()
            canLoadNames = False
            InitializeComponent()

            ProcessorsToUse.Minimum = 1
            ProcessorsToUse.Maximum = Environment.ProcessorCount
            ProcessorsToUse.Value = Environment.ProcessorCount ' Use all processors.

            LinqYearStartLabel.Text = yearStart.ToString()
            PlinqYearStartLabel.Text = yearStart.ToString()
            LinqYearEndLabel.Text = yearEnd.ToString()
            PlinqYearEndLabel.Text = yearEnd.ToString()
            LinqValueEndLabel.Text = yscaleMax.ToString()
            PlinqValueEndLabel.Text = yscaleMax.ToString()

            InitializeQueries()

            ' Eliminate startup costs from the equation.
            System.Threading.ThreadPool.SetMinThreads(Environment.ProcessorCount, Environment.ProcessorCount)

            ' Now load 250MB of data by default.
            canLoadNames = True
            LoadNames(250)
        End Sub

        Private canLoadNames As Boolean
		Private names As New List(Of PopName)()
        Private info As New QueryInfo()
        Private Shared seqQuery As IEnumerable(Of PopName)
        Private Shared parQuery As ParallelQuery(Of PopName)
        Private Const yearStart As Integer = 1960
        Private Const yearEnd As Integer = 2000
        Private Const yscaleMax As Integer = 1000

        Private Class QueryInfo
            Friend Name As String
            Friend State As String
        End Class


        Private Sub InitializeQueries()
            seqQuery = _
             From n In names _
             Where n.Name.Equals(info.Name, StringComparison.InvariantCultureIgnoreCase) AndAlso n.State = info.State AndAlso n.Year >= yearStart AndAlso n.Year <= yearEnd _
             Order By n.Year Ascending _
             Select n

            parQuery = _
             From n In names.AsParallel().WithDegreeOfParallelism(ProcessorsToUse.Value) _
             Where n.Name.Equals(info.Name, StringComparison.InvariantCultureIgnoreCase) AndAlso n.State = info.State AndAlso n.Year >= yearStart AndAlso n.Year <= yearEnd _
             Order By n.Year Ascending _
             Select n
        End Sub


        Private Sub LoadNames(ByVal mbSize As Single)
            If canLoadNames Then
                Const recordSize As Integer = 32 ' approx. 32 bytes per record.
                Dim count As Integer = CInt(Fix((mbSize * 1024 * 1024) / recordSize))

                Dim oldCursor As Cursor = Cursor.Current
                Cursor.Current = Cursors.WaitCursor

                Try
                    LinqTimeLabel.Visible = False
                    PlinqTimeLabel.Visible = False
                    SpeedupLabel.Visible = False
                    LastSeqRun = 0
                    LastParRun = 0
                    ' Clear the screen.
                    LinqPicture.Image = Nothing
                    PlinqPicture.Image = Nothing
                    Refresh()

                    names.Clear()

                    Console.Write("Loading XML names...")
                    Dim doc As XDocument = XDocument.Load("popnames.xml")
                    Dim root As XElement = doc.Root
                    For Each child As XElement In root.Elements()
                        Dim name As New PopName()
                        name.Name = child.Attribute("Name").Value
                        name.Gender = CType(System.Enum.Parse(GetType(NameGender), child.Attribute("Gender").Value), NameGender)
                        name.State = child.Attribute("State").Value
                        name.Year = Integer.Parse(child.Attribute("Year").Value)
                        name.Rank = Integer.Parse(child.Attribute("Rank").Value)
                        name.Count = Integer.Parse(child.Attribute("Count").Value)
                        names.Add(name)
                        If names.Count = count Then
                            Exit For
                        End If
                    Next child

                    Do While count > names.Count
                        names.AddRange(names)
                    Loop
                    If names.Count > count Then
                        Dim remCount As Integer = names.Count - count
                        names.RemoveRange(names.Count - remCount - 1, remCount)
                    End If

                    ' "Prime" the queries.
                    seqQuery.ToList()
                    parQuery.ToList()

                    'MessageBox.Show(names.Count.ToString());
                Finally
                    Cursor.Current = oldCursor
                End Try
            End If
        End Sub

        Private Const RunMultiplier As Integer = 10
        Private LastSeqRun As Long = 0
        Private LastParRun As Long = 0

        Private Sub DrawResults(ByVal names As List(Of PopName), ByVal g As Graphics, ByVal width As Integer, ByVal height As Integer)
            ' Clear background to be white.
            g.Clear(Color.Black)

            If names.Count > 0 Then
                Dim maxValue As Integer = names.Select(Function(n) n.Count).Max()
                Dim minYear As Integer = names.Select(Function(n) n.Year).Min()
                Dim maxYear As Integer = names.Select(Function(n) n.Year).Max()

                LinqYearStartLabel.Text = minYear.ToString()
                PlinqYearStartLabel.Text = minYear.ToString()
                LinqYearEndLabel.Text = maxYear.ToString()
                PlinqYearEndLabel.Text = maxYear.ToString()
                LinqValueEndLabel.Text = maxValue.ToString()
                PlinqValueEndLabel.Text = maxValue.ToString()

                If minYear <> maxYear Then
                    ' Note: X axis is years, Y axis is the counts per year.
                    ' These are the dimensions everything will be scaled to.
                    Dim per_x As Single = CSng(width) / (maxYear - minYear)
                    Dim per_y As Single = CSng(height) / maxValue

                    'MessageBox.Show(String.Format("count = {0}, xscale = {1}, per_x = {2}",
                    '    names.Count.ToString(), xscale_max, per_x));

                    ' Draw axis lines:
                    Dim paxis As New Pen(Color.FromArgb(64, 64, 64), 1)
                    For i As Single = (height \ 10) To height - 1 Step (height \ 10)
                        g.DrawLine(paxis, 0, i, width, i)
                    Next i
                    Dim xvalues As Integer = (maxYear - minYear)
                    Dim xincrement As Single = CSng(width) / xvalues
                    For i As Single = xincrement To width - 1 Step xincrement
                        g.DrawLine(paxis, i, 0, i, height)
                    Next i

                    'g.DrawLine(paxis, 0, 0, width, height);

                    ' Draw data:
                    Dim p As New Pen(Color.Chartreuse, 4)
                    Dim curr_x As Single = 0.0F
                    Dim curr_y As Single = 0.0F
                    Dim last_x As Single = -1
                    Dim last_y As Single = -1
                    Dim last_year As Integer = -1

                    For Each n As PopName In names
                        If n.Year <> last_year Then
                            If LineRadioButton.Checked Then
                                curr_x = (maxYear - n.Year) * per_x
                                curr_y = height - (n.Count * per_y)
                                If last_x <> -1 AndAlso last_y <> -1 Then
                                    g.DrawLine(p, last_x, last_y, curr_x, curr_y)
                                End If
                                last_x = curr_x
                                last_y = curr_y
                                last_year = n.Year
                            Else
                                curr_x = (maxYear - n.Year) * per_x
                                curr_y = height - (n.Count * per_y)
                                If last_x <> -1 AndAlso last_y <> -1 Then
                                    g.DrawLine(p, curr_x, height, curr_x, curr_y)
                                End If
                                last_x = curr_x
                                last_y = curr_y
                                last_year = n.Year
                            End If
                        End If
                    Next n
                End If
            End If
        End Sub

        Private Sub RunLinqButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RunLinqButton.Click
            Dim oldCursor As Cursor = Cursor.Current
            Cursor.Current = Cursors.WaitCursor

            ' Set query info values based on text box.
            info.Name = NameTextBox.Text.Trim()
            info.State = StateTextBox.Text.Trim()

            Try
                ' Clear the screen.
                LinqPicture.Image = Nothing
                Refresh()

                ' Execute and time the query:
                Dim names As List(Of PopName) = Nothing
                Dim sw As New Stopwatch()

                Dim mre As New System.Threading.ManualResetEvent(False)
                System.Threading.ThreadPool.QueueUserWorkItem(Sub()
                                                                  sw.Start()
                                                                  For i As Integer = 0 To RunMultiplier - 1
                                                                      names = seqQuery.ToList()
                                                                  Next i
                                                                  sw.Stop()
                                                                  LastSeqRun = sw.ElapsedTicks
                                                                  mre.Set()
                                                              End Sub)
                mre.WaitOne()

                ' And draw:
                LinqPicture.Image = New Bitmap(LinqPicture.Width, LinqPicture.Height)
                Dim g As Graphics = Graphics.FromImage(LinqPicture.Image)
                DrawResults(names, g, LinqPicture.Image.Width, LinqPicture.Image.Height)

                ' Note execution time:
                LinqTimeLabel.Text = String.Format("{0:F2} seconds", (sw.ElapsedMilliseconds / 1000.0))
                LinqTimeLabel.Visible = True

                If LastSeqRun <> 0 AndAlso LastParRun <> 0 Then
                    SpeedupLabel.Text = String.Format("{0:F2}x speedup", (CSng(LastSeqRun)) / LastParRun)
                    SpeedupLabel.Visible = True
                End If
            Finally
                Cursor.Current = oldCursor
            End Try
        End Sub

        Private Sub RunPlinqButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RunPlinqButton.Click
            Dim oldCursor As Cursor = Cursor.Current
            Cursor.Current = Cursors.WaitCursor

            ' Set query info values based on text box.
            info.Name = NameTextBox.Text.Trim()
            info.State = StateTextBox.Text.Trim()

            Try
                ' Clear the screen.
                PlinqPicture.Image = Nothing
                Refresh()

                ' Execute and time the query:
                Dim names As List(Of PopName) = Nothing
                Dim sw As New Stopwatch()

                Dim mre As New System.Threading.ManualResetEvent(False)
                System.Threading.ThreadPool.QueueUserWorkItem(Sub()
                                                                  sw.Start()
                                                                  For i As Integer = 0 To RunMultiplier - 1
                                                                      names = parQuery.ToList()
                                                                  Next i
                                                                  sw.Stop()
                                                                  LastParRun = sw.ElapsedTicks
                                                                  mre.Set()
                                                              End Sub)
                mre.WaitOne()

                ' And draw:
                PlinqPicture.Image = New Bitmap(PlinqPicture.Width, PlinqPicture.Height)
                Dim g As Graphics = Graphics.FromImage(PlinqPicture.Image)
                DrawResults(names, g, PlinqPicture.Image.Width, PlinqPicture.Image.Height)

                ' Note execution time:
                PlinqTimeLabel.Text = String.Format("{0:F2} seconds", (sw.ElapsedMilliseconds / 1000.0))
                PlinqTimeLabel.Visible = True

                If LastSeqRun <> 0 AndAlso LastParRun <> 0 Then
                    SpeedupLabel.Text = String.Format("{0:F2}x speedup", (CSng(LastSeqRun)) / LastParRun)
                    SpeedupLabel.Visible = True
                End If
            Finally
                Cursor.Current = oldCursor
            End Try
        End Sub

		Private Sub InputSize1MB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InputSize1MB.CheckedChanged
			If (CType(sender, RadioButton)).Checked Then
				LoadNames(1)
			End If
		End Sub

		Private Sub InputSize5MB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InputSize5MB.CheckedChanged
			If (CType(sender, RadioButton)).Checked Then
				LoadNames(5)
			End If
		End Sub

		Private Sub InputSize10MB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InputSize10MB.CheckedChanged
			If (CType(sender, RadioButton)).Checked Then
				LoadNames(10)
			End If
		End Sub

		Private Sub InputSize50MB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InputSize50MB.CheckedChanged
			If (CType(sender, RadioButton)).Checked Then
				LoadNames(50)
			End If
		End Sub

		Private Sub InputSize100MB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InputSize100MB.CheckedChanged
			If (CType(sender, RadioButton)).Checked Then
				LoadNames(100)
			End If
		End Sub

		Private Sub InputSize250MB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InputSize250MB.CheckedChanged
			If (CType(sender, RadioButton)).Checked Then
				LoadNames(250)
			End If
		End Sub

		Private Sub InputSize500MB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InputSize500MB.CheckedChanged
			If (CType(sender, RadioButton)).Checked Then
				LoadNames(500)
			End If
		End Sub

		Private Sub InputSize1GB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles InputSize1GB.CheckedChanged
			If (CType(sender, RadioButton)).Checked Then
				LoadNames(1000)
			End If
		End Sub

		Private Sub ProcessorsToUse_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles ProcessorsToUse.Scroll
			InitializeQueries()
		End Sub
	End Class

	Friend Enum NameGender
		Male
		Female
	End Enum

	Friend Class PopName
		' Fields:
		Private m_name As String
		Private m_gender As NameGender
		Private m_state As String
		Private m_year As Integer
		Private m_rank As Integer
		Private m_count As Integer

		' Properties:
		Friend Property Name() As String
			Get
				Return m_name
			End Get
			Set(ByVal value As String)
				m_name = value
			End Set
		End Property
		Friend Property Gender() As NameGender
			Get
				Return m_gender
			End Get
			Set(ByVal value As NameGender)
				m_gender = value
			End Set
		End Property
		Friend Property State() As String
			Get
				Return m_state
			End Get
			Set(ByVal value As String)
				m_state = value
			End Set
		End Property
		Friend Property Year() As Integer
			Get
				Return m_year
			End Get
			Set(ByVal value As Integer)
				m_year = value
			End Set
		End Property
		Friend Property Rank() As Integer
			Get
				Return m_rank
			End Get
			Set(ByVal value As Integer)
				m_rank = value
			End Set
		End Property
		Friend Property Count() As Integer
			Get
				Return m_count
			End Get
			Set(ByVal value As Integer)
				m_count = value
			End Set
		End Property

		Public Overrides Function ToString() As String
			Return String.Format("{{ Name={0}, Gender={1}, State={2}, Year={3}, Rank={4}, Count={5} }}", Name, Gender, State, Year, Rank, Count)
		End Function
	End Class
End Namespace