using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Listview.xaml
    /// </summary>
    public partial class Listview : Window
    {
        public Listview()
        {
            InitializeComponent();

            using (ApplicationContext db = new ApplicationContext())
            {
                var currentList = LView.ItemsSource = db.route.Join(db.ticket,
                a => a.id,
                b => b.id,
                (a, b) => new { a.id, a.bus, a.driver, a.city, b.client, b.price }).ToList();
                var currentList2 = db.route.ToList();
                LView.ItemsSource = currentList;
            }

        }

        private void BtnReservation_Click(object sender, RoutedEventArgs e)
        {
            Reservation task = new Reservation();
            task.Show();
            this.Close();
        }
    }
}
