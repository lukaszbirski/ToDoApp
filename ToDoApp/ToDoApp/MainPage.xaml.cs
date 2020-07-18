using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ToDoApp.Models;

namespace ToDoApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddToDoPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Todo>();
                var todos = conn.Table<Todo>().ToList();
                todosListView.ItemsSource = todos;
            };
        }

        private void todosListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedToDo = todosListView.SelectedItem as Todo;

            if(selectedToDo != null)
            {
                Navigation.PushAsync(new ToDoDetailsPage(selectedToDo));
            }
        }
    }
}
