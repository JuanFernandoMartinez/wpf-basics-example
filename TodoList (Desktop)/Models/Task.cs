using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList__Desktop_.Models
{
    internal class Task
    {
        private string Title { get; set; } = "Default Title";
        private string Description { get; set; } = "Default Description";

        public Task(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string getTitle()
        {
            return Title;
        }
        public void setTitle(string t)
        {
            Title = t;
        }

        public string getDescription()
        {
            return Description;
        }

        public void setDescription(string d)
        {
            Description = d;
        }
    }
}
