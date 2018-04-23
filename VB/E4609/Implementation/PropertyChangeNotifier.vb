Imports System
Imports System.Windows
Imports System.Windows.Data

Namespace E4609
    Public Class PropertyChangeNotifier
        Inherits DependencyObject

        Public Shared ReadOnly ValueProperty As DependencyProperty = DependencyProperty.Register("Value", GetType(Object), GetType(PropertyChangeNotifier), New FrameworkPropertyMetadata(Nothing, New PropertyChangedCallback(AddressOf OnValuePropertyChanged)))

        Private Shared Sub OnValuePropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            DirectCast(d, PropertyChangeNotifier).OnValueChanged(e)
        End Sub

        Private _propertySource As WeakReference
        Public Event ValueChanged As EventHandler

        Public Property Value() As Object
            Get
                Return GetValue(ValueProperty)
            End Get
            Set(ByVal value As Object)
                SetValue(ValueProperty, value)
            End Set
        End Property
        Public ReadOnly Property PropertySource() As DependencyObject
            Get
                Return If(_propertySource IsNot Nothing AndAlso _propertySource.IsAlive, DirectCast(_propertySource.Target, DependencyObject), Nothing)
            End Get
        End Property

        Public Sub New(ByVal propertySource As DependencyObject, ByVal [property] As DependencyProperty)
            If propertySource Is Nothing Then
                Throw New ArgumentNullException("propertySource")
            End If
            If [property] Is Nothing Then
                Throw New ArgumentNullException("property")
            End If
            _propertySource = New WeakReference(propertySource)
            Dim binding As New Binding()
            binding.Path = New PropertyPath([property])
            binding.Mode = BindingMode.OneWay
            binding.Source = propertySource
            BindingOperations.SetBinding(Me, ValueProperty, binding)
        End Sub

        Protected Overridable Sub OnValueChanged(ByVal e As DependencyPropertyChangedEventArgs)
            RaiseEvent ValueChanged(Me, EventArgs.Empty)
        End Sub
        Public Sub Dispose()
            AddHandler ValueChanged, Nothing
            BindingOperations.ClearBinding(Me, ValueProperty)
        End Sub
    End Class
End Namespace