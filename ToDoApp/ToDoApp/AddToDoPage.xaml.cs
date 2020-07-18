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
    public partial class AddToDoPage : ContentPage
    {
        public AddToDoPage()
        {
            InitializeComponent();
        }

        private void AddToDoButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(descriptionEntry.Text))
            {
                string description = descriptionEntry.Text;
                Todo todo = new Todo(description);

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Todo>();
                    int rows = conn.Insert(todo);

                    if (rows > 0) DisplayAlert("Success", $"{description} was succesfully added to the list", "Ok");
                    else DisplayAlert("Failure", $"{description} wasn't added to the list", "Ok");
                };

                Navigation.PushAsync(new MainPage());
            }
            else DisplayAlert("Failure", "Field can not be empty", "Ok");
        }
    }
}