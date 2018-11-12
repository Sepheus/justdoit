using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace justdoit {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoEditPage : ContentPage {
        public ToDoListItem Model {
            get { return BindingContext as ToDoListItem; }
            set {
                BindingContext = value;
                OnPropertyChanged();
            }
        }

        public ToDoEditPage(ToDoListItem _model) {
            Model = _model;
            Title = "Edit";
            InitializeComponent();
        }

        public bool CheckName() {
            if (string.IsNullOrEmpty(Model.title)) {
                DisplayAlert("Error", "Title cannot be empty", "OK");
                return false;
            }
            return true;
        }

        private void OnSave(object sender, EventArgs e) {
            if (!CheckName()) { return; }
            new Database().EditItem(Model);
            Navigation.PopAsync();
        }
    }
}