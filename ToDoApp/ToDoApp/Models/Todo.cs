using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ToDoApp.Models
{
    public class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private bool done;

        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Todo(string description)
        {
            this.description = description;
            this.done = false;
            this.date = DateTime.Now;
        }

        public Todo()
        {

        }
    }
}
