using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SharedApp
{
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime alertDate { get; set; }
        
        public string taskText { get; set; }

        public string taskTitle { get; set; }

        public string taskImage { get; set; }

        public Task() { }
     
        public Task(string taskText, string taskTitle)
        {
            this.taskText = taskText;
            this.taskTitle = taskTitle;
        }
    }
}
