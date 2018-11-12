using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace justdoit {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            CheckDatabasePopulated();
        }

        internal List<ToDoListItem> GetToDoList() {
            return new Database().GetToDoItems();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            listView.ItemsSource = GetToDoList();
        }

        /// <summary>
        /// Create an initial list of ten tasks with the opacity being reduced the further down the list the task.
        /// </summary>
        private void CheckDatabasePopulated() {
            var connection = new Database();
            if(connection.GetToDoItems().Count() < 1) {
                var items = Enumerable.Range(1, 10)
                    .Select(n => new ToDoListItem() { title = "Task " + n.ToString(), content = "Tap here to write a new task", alpha = (1.05 - ((double)n / 20)).ToString() })
                    .ToList<ToDoListItem>();
                connection.AddToDoItems(items);
            }
        }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem == null) { return; }
            (sender as ListView).SelectedItem = null;
            var todoEditPage = new ToDoEditPage(e.SelectedItem as ToDoListItem);
            await Navigation.PushAsync(todoEditPage);
        }
    }
}
