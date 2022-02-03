using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList__Desktop_.Models
{
    internal class Manager
    {
        List<Task> Tasks { get; set; } = new List<Task>();

        public bool add(Task t)
        {
            for (int i = 0;i< Tasks.Count; i++)
            {
                if (Tasks[i].getTitle().Equals(t.getTitle()))
                {
                    return false;
                }
            }
            Tasks.Add(t);
            return true;
        }
        public Task get(string n)
        {
            for (int i = 0;i< Tasks.Count; i++)
            {
                if (Tasks[i].getTitle().Equals(n)) return Tasks[i];
            }

            return null;
        }

        public bool delete(string n)
        {
            Task t = get(n);
            if (t != null)
            {
                Tasks.Remove(t);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string[] getTitles()
        {
            string[] t = new string[Tasks.Count];
            for (int i = 0;i< Tasks.Count; i++)
            {
                t[i] = Tasks[i].getTitle();
            }

            return t;
        }
    }
}
