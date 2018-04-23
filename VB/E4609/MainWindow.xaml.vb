Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Grid
Imports GridLayoutHelper

Namespace E4609
    Partial Public Class MainWindow
        Private Persons As ObservableCollection(Of Person)
        Public Sub New()
            InitializeComponent()
            Persons = New ObservableCollection(Of Person)()
            For i As Integer = 0 To 99
                Persons.Add(New Person With {
                    .Id = i,
                    .Name = "Name" & i.ToString(),
                    .Bool = i Mod 2 = 0
                })
            Next i
            grid.ItemsSource = Persons
        End Sub
        Private Sub AddColumn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            grid.Columns.BeginUpdate()
            grid.Columns.Add(New GridColumn() With {.FieldName = "Name"})
            grid.Columns.EndUpdate()
        End Sub
        Private Sub RemoveColumn_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            grid.Columns.Remove(grid.Columns.Last())
        End Sub
        Private Sub GridLayoutHelper_Trigger(ByVal sender As Object, ByVal e As MyEventArgs)
            Debug.WriteLine(String.Join(" | ", e.LayoutChangedTypes))
        End Sub
        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            grid.Columns.Clear()
        End Sub
    End Class
    Public Class Person
        Public Property Id() As Integer
        Public Property Name() As String
        Public Property Bool() As Boolean
    End Class
End Namespace