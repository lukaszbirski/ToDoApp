using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ToDoApp.Models;
using SQLite;

namespace ToDoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoDetailsPage : ContentPage
    {
        Todo selectedTodo;
        public ToDoDetailsPage(Todo selectedTodo)
        {
            InitializeComponent();
            this.selectedTodo = selectedTodo;

            descriptionDetailsLabel.Text = selectedTodo.Description;
            dateDetailsLabel.Text = $"Added: {selectedTodo.Date.ToString()}";

            var assembly = typeof(ToDoDetailsPage);
            if(selectedTodo.Done)
            {
                iconImage.Source = ImageSource.FromResource("ToDoApp.Assets.Images.check-450dp.png", assembly);
            }
            else
            {
                iconImage.Source = ImageSource.FromResource("ToDoApp.Assets.Images.sad-450dp.png", assembly);
            }
            
        }

        private void updateButton_Clicked(object sender, EventArgs e)
        {

            if (selectedTodo.Done) selectedTodo.Done = false;
            else selectedTodo.Done = true;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                 conn.CreateTable<Todo>();
                 int rows = conn.Update(selectedTodo);

                 if (rows > 0) DisplayAlert("Success", "To do was succesfully updated", "Ok");
                 else DisplayAlert("Failure", "To do wasn't updated", "Ok");
            };

            Navigation.PushAsync(new MainPage());
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Todo>();
                int rows = conn.Delete(selectedTodo);

                if (rows > 0) DisplayAlert("Success", $"To do {selectedTodo.Description} was succesfully deleted", "Ok");
                else DisplayAlert("Failure", $"To do {selectedTodo.Description} wasn't deleted", "Ok");
            };

            Navigation.PushAsync(new MainPage());
        }
    }
}