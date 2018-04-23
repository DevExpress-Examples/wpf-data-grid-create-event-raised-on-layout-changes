using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using DevExpress.Xpf.Grid;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Input;
using GridLayoutHelper;

namespace DXGridSample {
	public partial class MainWindow: Window {
		ObservableCollection<Person> Persons;
		public MainWindow() {
			InitializeComponent();
			Persons = new ObservableCollection<Person>();
			for (int i = 0; i < 100; i++)
				Persons.Add(new Person { Id = i, Name = "Name" + i, Bool = i % 2 == 0 });
			grid.ItemsSource = Persons;
		}
		private void AddColumn_Click(object sender, System.Windows.RoutedEventArgs e) {
			grid.Columns.Add(new GridColumn() { FieldName = "Name" });
		}
		private void RemoveColumn_Click(object sender, System.Windows.RoutedEventArgs e) {
			grid.Columns.Remove(grid.Columns.Last());
		}
		private void GridLayoutHelper_Trigger(object sender, MyEventArgs e) {
			string str = string.Empty;
			foreach (var type in e.LayoutChangedTypes)
				str = string.IsNullOrEmpty(str) ? type.ToString() : str + " | " + type;
			Debug.WriteLine(str);
		}
	}
	public class Person {
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Bool { get; set; }
	}
}