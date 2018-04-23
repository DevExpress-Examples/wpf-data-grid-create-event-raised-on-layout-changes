using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Grid;
using GridLayoutHelper;

namespace E4609 {
    public partial class MainWindow {
        ObservableCollection<Person> Persons;
        public MainWindow() {
            InitializeComponent();
            Persons = new ObservableCollection<Person>();
            for (int i = 0; i < 100; i++)
                Persons.Add(new Person { Id = i, Name = "Name" + i, Bool = i % 2 == 0 });
            grid.ItemsSource = Persons;
        }
        private void AddColumn_Click(object sender, RoutedEventArgs e) {
            grid.Columns.BeginUpdate();
            grid.Columns.Add(new GridColumn() { FieldName = "Name" });
            grid.Columns.EndUpdate();
        }
        private void RemoveColumn_Click(object sender, RoutedEventArgs e) {
            grid.Columns.Remove(grid.Columns.Last());
        }
        private void GridLayoutHelper_Trigger(object sender, MyEventArgs e) {
            Debug.WriteLine(string.Join(" | ", e.LayoutChangedTypes));
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            grid.Columns.Clear();
        }
    }
    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Bool { get; set; }
    }
}