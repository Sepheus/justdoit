using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace justdoit {
    class Database {

        private SQLiteConnection _connection;

        public Database() {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<ToDoListItem>();
        }

        public List<ToDoListItem> GetToDoItems() {
            return _connection.Table<ToDoListItem>().ToList();
        }

        public void AddToDoItem(ToDoListItem item) {
            _connection.Insert(item);
        }

        public void AddToDoItems(List<ToDoListItem> items) {
            foreach(var item in items) {
                AddToDoItem(item);
            }
        }

        public void EditItem(ToDoListItem item) {
            _connection.Update(item);
        }
    }
}
