using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoList__Desktop_
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> names = new List<string>();
        Models.Manager man = new Models.Manager();
        string item = "";
        public MainWindow()
        {
            

            
            InitializeComponent();
            Task_List.ItemsSource = names;
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            item = "";
            if (Task_List.SelectedItem != null)
            {
                item = Task_List.SelectedItem.ToString();
                Models.Task aux = man.get(item);
                title.Text = aux.getTitle();
                description.Text = aux.getDescription();
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Models.Task aux = new Models.Task(title.Text, description.Text);
            bool status = man.add(aux);
            if (!status)
            {
                MessageBox.Show("Tasks is already on list", "Error");
            }
            else
            {
                names.Add(title.Text);
            }
            Task_List.ItemsSource = names.ToArray();
            title.Text = "";
            description.Text = "";
            updateList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (item.Equals(""))
            {
                MessageBox.Show("You must select one item first","Warning");
            }
            else
            {
                Models.Task t = man.get(item);
                if (t != null)
                {
                    t.setTitle(title.Text);
                    t.setDescription(description.Text);
                }
            }
            updateList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (item.Equals(""))
            {
                MessageBox.Show("any element selected", "Error");

            }
            else
            {
                string aux = item;
                Task_List.SelectedIndex = 0;
                bool status = man.delete(aux);
                
                if (!status)
                {
                    MessageBox.Show("Element doesn't exists", "Error");

                }
            }

            updateList();
        }

        private void updateList()
        {
            Task_List.ItemsSource = man.getTitles();
        }
    }
}
