<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128652431/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4609)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Data Grid - Create an Event Raised on Layout Changes

This example demonstrates how to create an event that is raised when a user changes the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl)'s layout.

![image](https://user-images.githubusercontent.com/65009440/186855425-d8682588-b7dd-46f2-9df1-d715f963c17d.png) 

In this example, the `GridLayoutHelper` class handles changes of the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl) and [GridColumn](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridColumn) layout properties and raises a custom event. The event's handler logs layout changes in the **Output** window:

![image](https://user-images.githubusercontent.com/65009440/186855562-2ed02acf-e9cd-485e-a446-9f46387668d1.png)

The following code sample demonstrates how to attach the `GridLayoutHelper` class to the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl):

```xaml
<dxg:GridControl x:Name="grid" AutoGenerateColumns="AddNew">
    <dxmvvm:Interaction.Behaviors>
	<local:GridLayoutHelper LayoutChanged="GridLayoutHelper_Trigger"/>
    </dxmvvm:Interaction.Behaviors>
</dxg:GridControl>
```

## Files to Look At

* [GridLayoutHelper.cs](./CS/E4609/Implementation/GridLayoutHelper.cs) (VB: [GridLayoutHelper.vb](./VB/E4609/Implementation/GridLayoutHelper.vb))
* [PropertyChangeNotifier.cs](./CS/E4609/Implementation/PropertyChangeNotifier.cs) (VB: [PropertyChangeNotifier.vb](./VB/E4609/Implementation/PropertyChangeNotifier.vb))
* [MainWindow.xaml](./CS/E4609/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/E4609/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/E4609/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/E4609/MainWindow.xaml.vb))

## Documentation

* [GridControl.Columns](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.Columns)
* [GridControl.SortInfo](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl.SortInfo)
* [DataControlBase.FilterChanged](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.FilterChanged)
* [BaseColumn.ActualWidth](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.BaseColumn.ActualWidth)
* [BaseColumn.VisibleIndex](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.BaseColumn.VisibleIndex)
* [GridColumn.GroupIndex](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridColumn.GroupIndex)
* [BaseColumn.Visible](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.BaseColumn.Visible)

## More Examples

* [WPF Data Grid - Save Layout and Restore It from a Memory Stream](https://github.com/DevExpress-Examples/how-to-save-grid-layout-to-and-restore-it-from-a-memory-stream-e1655)
