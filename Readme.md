<!-- default file list -->
*Files to look at*:

* [GridLayoutHelper.cs](./CS/E4609/Implementation/GridLayoutHelper.cs) (VB: [GridLayoutHelper.vb](./VB/E4609/Implementation/GridLayoutHelper.vb))
* [PropertyChangeNotifier.cs](./CS/E4609/Implementation/PropertyChangeNotifier.cs) (VB: [PropertyChangeNotifier.vb](./VB/E4609/Implementation/PropertyChangeNotifier.vb))
* [MainWindow.xaml](./CS/E4609/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/E4609/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/E4609/MainWindow.xaml.cs) (VB: [MainWindow.xaml](./VB/E4609/MainWindow.xaml))
<!-- default file list end -->
# How to provide an event that is raised on changing a grid layout


<p>This example demonstrates how to provide an event that is raised as soon as a grid layout is changed.</p>
<br />
<p>In this example, we have created a GridLayoutHelper class that handles changes of the GridControl object's necessary properties and columns, and raises a custom event in its handlers.</p>
<br />
<p>This class can be easily attached to the GridControl object in the following manner:</p>


```xaml
<dxg:GridControl x:Name="grid" AutoPopulateColumns="True">
	<dxmvvm:Interaction.Behaviors>
		<local:GridLayoutHelper LayoutChanged="OnGridLayoutChanged"/>
	</dxmvvm:Interaction.Behaviors>
</dxg:GridControl>
```


<p> </p>
<p>To learn more on how to implement similar functionality in <strong>Silverlight</strong>, refer to the <a href="https://www.devexpress.com/Support/Center/p/T243422">T243422</a> example.</p>

<br/>


