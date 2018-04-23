Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports E4609

Namespace GridLayoutHelper
    Public Class GridLayoutHelper
        Inherits Behavior(Of GridControl)

        Public Event LayoutChanged As EventHandler(Of MyEventArgs)

        Private IsLocked As Boolean
        Private ReadOnly ChangesCache As New List(Of LayoutChangedType)()
        Private ReadOnly Notifiers As New List(Of PropertyChangeNotifier)()

        Protected ReadOnly Property Grid() As GridControl
            Get
                Return AssociatedObject
            End Get
        End Property
        Public Property RaiseEventsImmediately() As Boolean

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            SubscribeColumns(Grid.Columns)
            AddHandler Grid.Columns.CollectionChanged, AddressOf ColumnsCollectionChanged
            AddHandler Grid.SortInfo.CollectionChanged, AddressOf OnSortInfoChanged
            AddHandler Grid.FilterChanged, AddressOf OnGridFilterChanged
        End Sub
        Protected Overrides Sub OnDetaching()
            Notifiers.Clear()
            UnsubscribeColumns(Grid.Columns)
            RemoveHandler Grid.Columns.CollectionChanged, AddressOf ColumnsCollectionChanged
            RemoveHandler Grid.SortInfo.CollectionChanged, AddressOf OnSortInfoChanged
            RemoveHandler Grid.FilterChanged, AddressOf OnGridFilterChanged
            MyBase.OnDetaching()
        End Sub

        #Region "GridEventHandlers"
        Protected Overridable Sub OnGridFilterChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ProcessLayoutChanging(LayoutChangedType.FilerChanged)
        End Sub
        Protected Overridable Sub OnSortInfoChanged(ByVal sender As Object, ByVal e As System.Collections.Specialized.NotifyCollectionChangedEventArgs)
            ProcessLayoutChanging(LayoutChangedType.SortingChanged)
        End Sub
        Protected Overridable Sub ColumnsCollectionChanged(ByVal sender As Object, ByVal e As System.Collections.Specialized.NotifyCollectionChangedEventArgs)
            Dim hasChanges As Boolean = False
            Dim newColumns = Grid.Columns.Except(SubscribedColumns).ToList()
            Dim oldColumns = SubscribedColumns.Except(Grid.Columns).ToList()
            If oldColumns.Any() Then
                hasChanges = True
                UnsubscribeColumns(oldColumns)
            End If
            If newColumns.Any() Then
                hasChanges = True
                SubscribeColumns(newColumns)
            End If
            If hasChanges Then
                ProcessLayoutChanging(LayoutChangedType.ColumnsCollection)
            End If
        End Sub

        Protected Overridable Sub ProcessLayoutChanging(ByVal type As LayoutChangedType)
            If LayoutChangedEvent Is Nothing Then
                Return
            End If
            If RaiseEventsImmediately Then
                RaiseEvent LayoutChanged(Me, New MyEventArgs With { _
                    .LayoutChangedTypes = New List(Of LayoutChangedType) From {type} _
                })
            Else
                If Not ChangesCache.Contains(type) Then
                    ChangesCache.Add(type)
                End If
                If IsLocked Then
                    Return
                End If
                IsLocked = True
                Dispatcher.BeginInvoke(New Action(Sub()
                    IsLocked = False
                    RaiseEvent LayoutChanged(Me, New MyEventArgs With {.LayoutChangedTypes = ChangesCache})
                    ChangesCache.Clear()
                End Sub))
            End If
        End Sub
        #End Region

        #Region "ColumnEventHandlers"
        Private SubscribedColumns As New List(Of GridColumn)()
        Protected Overridable Sub SubscribeColumns(ByVal columns As IEnumerable(Of GridColumn))
            SubscribedColumns.AddRange(columns)
            For Each column As GridColumn In columns
                Subscribe(column)
            Next column
        End Sub
        Protected Overridable Sub UnsubscribeColumns(ByVal columns As IEnumerable(Of GridColumn))
            For Each column As GridColumn In columns
                SubscribedColumns.Remove(column)
                Unsubscribe(column)
            Next column
        End Sub
        Protected Overridable Sub Subscribe(ByVal column As GridColumn)
            Dim actualWidthDescriptor = New PropertyChangeNotifier(column, BaseColumn.ActualWidthProperty)
            AddHandler actualWidthDescriptor.ValueChanged, AddressOf OnColumnWidthChanged
            Notifiers.Add(actualWidthDescriptor)

            Dim visibleIndexDescriptor = New PropertyChangeNotifier(column, BaseColumn.VisibleIndexProperty)
            AddHandler visibleIndexDescriptor.ValueChanged, AddressOf OnColumnVisibleIndexChanged
            Notifiers.Add(visibleIndexDescriptor)

            Dim groupIndexDescriptor = New PropertyChangeNotifier(column, GridColumn.GroupIndexProperty)
            AddHandler groupIndexDescriptor.ValueChanged, AddressOf OnColumnGroupIndexChanged
            Notifiers.Add(groupIndexDescriptor)

            Dim visibleDescriptor = New PropertyChangeNotifier(column, BaseColumn.VisibleProperty)
            AddHandler visibleDescriptor.ValueChanged, AddressOf OnColumnVisibleChanged
            Notifiers.Add(visibleDescriptor)
        End Sub
        Protected Overridable Sub Unsubscribe(ByVal column As GridColumn)

            Dim notifiers_Renamed = Notifiers.Where(Function(x) x.PropertySource Is column).ToList()
            For Each n In notifiers_Renamed
                n.Dispose()
                Notifiers.Remove(n)
            Next n
        End Sub
        Protected Overridable Sub OnColumnWidthChanged(ByVal sender As Object, ByVal args As EventArgs)
            ProcessLayoutChanging(LayoutChangedType.ColumnWidth)
        End Sub
        Protected Overridable Sub OnColumnVisibleIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
            ProcessLayoutChanging(LayoutChangedType.ColumnVisibleIndex)
        End Sub
        Protected Overridable Sub OnColumnGroupIndexChanged(ByVal sender As Object, ByVal args As EventArgs)
            ProcessLayoutChanging(LayoutChangedType.ColumnGroupIndex)
        End Sub
        Protected Overridable Sub OnColumnVisibleChanged(ByVal sender As Object, ByVal args As EventArgs)
            ProcessLayoutChanging(LayoutChangedType.ColumnVisible)
        End Sub
        #End Region
    End Class

    Public Class MyEventArgs
        Inherits EventArgs

        Public Property LayoutChangedTypes() As List(Of LayoutChangedType)
    End Class

    Public Enum LayoutChangedType
        ColumnsCollection
        FilerChanged
        SortingChanged
        ColumnGroupIndex
        ColumnVisibleIndex
        ColumnWidth
        ColumnVisible
        None
    End Enum
End Namespace
