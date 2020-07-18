using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ToDoApp.Models;

namespace ToDoApp.Test.Models.Test
{
    [TestFixture]
    class TodoTest
    {
        [Test]
        public void Todo_Check_If_When_Instantiated_Done_Returns_False() 
        {
            //Arrange
            Todo todo = new Todo("przeczytac ksiazke");

            //Assert
            Assert.IsFalse(todo.Done);
        }

        [Test]
        public void Todo_Check_If_When_Instantiated_Date_Is_Not_Null()
        {
            //Arrange
            Todo todo = new Todo("przeczytac ksiazke");

            //Assert
            Assert.IsNotNull(todo.Date);
        }
    }
}
