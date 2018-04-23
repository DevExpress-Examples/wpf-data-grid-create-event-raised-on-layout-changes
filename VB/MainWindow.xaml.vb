Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Collections.ObjectModel
Imports System.Globalization
Imports System.Windows.Data
Imports System.Windows.Markup
Imports DevExpress.Xpf.Grid
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Windows.Input
Imports GridLayoutHelper

Namespace DXGridSample
    Partial Public Class MainWindow
        Inherits Window

        Private Persons As ObservableCollection(Of Person)
        Public Sub New()
            InitializeComponent()
            Persons = New ObservableCollection(Of Person)()
            For i As Integer = 0 To 99
                Persons.Add(New Person With {.Id = i, .Name = "Name" & i, .Bool = i Mod 2 = 0})
            Next i
            grid.ItemsSource = Persons
        End Sub
        Private Sub AddColumn_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
            grid.Columns.Add(New GridColumn() With {.FieldName = "Name"})
        End Sub
        Private Sub RemoveColumn_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
            grid.Columns.Remove(grid.Columns.Last())
        End Sub
        Private Sub GridLayoutHelper_Trigger(ByVal sender As Object, ByVal e As MyEventArgs)
            Dim str As String = String.Empty
            For Each type In e.LayoutChangedTypes
                str = If(String.IsNullOrEmpty(str), type.ToString(), str & " | " & type)
            Next type
            Debug.WriteLine(str)
        End Sub
    End Class
    Public Class Person
        Public Property Id() As Integer
        Public Property Name() As String
        Public Property Bool() As Boolean
    End Class
End Namespace