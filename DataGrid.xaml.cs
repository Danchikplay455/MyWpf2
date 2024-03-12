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
    /// Логика взаимодействия для DataGrid.xaml
    /// </summary>
    public partial class DataGrid : Window
    {
        public DataGrid()
        {
            InitializeComponent();
            using (ApplicationContext context = new ApplicationContext())
            {
                DGridMovies.ItemsSource = context.ticket.ToList();
            }
        }


        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                EditPage taskWindow = new EditPage((sender as Button).DataContext as ticket);
                taskWindow.Show();
                this.Close();
            }
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            EditPage taskWindow = new EditPage(null);
            taskWindow.Show();
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var ticketDel = DGridMovies.SelectedItems.Cast<ticket>().ToList();
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        db.ticket.RemoveRange(ticketDel);
                        db.SaveChanges();
                        DGridMovies.ItemsSource = db.ticket.ToList();
                    }
                }
            }
        }
    }
}
