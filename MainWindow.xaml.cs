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

namespace MyWpf2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                var user = db.client.FirstOrDefault(p => p.email == Pochta.Text && p.password == Pass.Password);
                if (user != null)
                {
                    if (user.type_user == "Admin" || user.type_user == "admin" || user.type_user == "Administrator" || user.type_user == "administrator"
                        || user.type_user == "Админ" || user.type_user == "Администратор" || user.type_user == "админ" || user.type_user == "администратор")
                    {
                        DataGrid task = new DataGrid();
                        task.Show();
                        this.Close();
                    }
                    else
                    {
                        Listview task = new Listview();
                        task.Show();
                        this.Close();
                    }
                }
            }
        }
    }
 }
