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
using System.Windows.Shapes;

namespace MyWpf2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext bd = new ApplicationContext()) 
            { 
                client client = new client();
                client.email = pochta.Text;
                client.phone= phone.Text;
                client.password = pass.Text;
                bd.Add(client);
                try 
                {
                    bd.SaveChanges();
                    MessageBox.Show("Регистрация успешна");
                    MainWindow open= new MainWindow();
                    open.Show();
                    this.Close();
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
