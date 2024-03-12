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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Window
    {
    
        private ticket ticket = new ticket();
        public EditPage(ticket selectedTicket)
        {
            InitializeComponent();

            if (selectedTicket != null)
            {
                ticket = selectedTicket;
            }
            DataContext = ticket;
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ticket ticket = DataContext as ticket;
                if (ticket != null)
                {
                    db.ticket.Update(ticket);
                    db.SaveChanges();   
                    MessageBox.Show("Сохранено");
                    DataGrid win = new DataGrid();
                    win.Show();
                    this.Close();
                }
            }
        }
        private void BtnCancel2_Click(object sender, RoutedEventArgs e)
        {
            DataGrid task = new DataGrid();
            task.Show();
            this.Close();
        }
    }
}

