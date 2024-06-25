<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128652431/15.2.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4609)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [GridLayoutHelper.cs](./CS/E4609/Implementation/GridLayoutHelper.cs) (VB: [GridLayoutHelper.vb](./VB/E4609/Implementation/GridLayoutHelper.vb))
* [PropertyChangeNotifier.cs](./CS/E4609/Implementation/PropertyChangeNotifier.cs) (VB: [PropertyChangeNotifier.vb](./VB/E4609/Implementation/PropertyChangeNotifier.vb))
* [MainWindow.xaml](./CS/E4609/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/E4609/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/E4609/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/E4609/MainWindow.xaml.vb))
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


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-create-event-raised-on-layout-changes&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-create-event-raised-on-layout-changes&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
