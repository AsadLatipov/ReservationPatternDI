using ReservationPatternDI.Desktop.Models;
using ReservationPatternDI.Desktop.StartupHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ReservationPatternDI.Desktop
{
    public partial class OrdersWindow : Window
    {
        private readonly IAbstractFactory<MakeReservationWindow> _abstractFactory;
        public List<Order> Orders = new List<Order>();


        public OrdersWindow(IAbstractFactory<MakeReservationWindow> abstractFactory)
        {
            InitializeComponent();
            _abstractFactory = abstractFactory;
            Orders.Add(new Order { Username = "Ahmadjon", FloorId = 1, RoomId = 1, StartDate = DateTime.Today.AddDays(-1), EndDate = DateTime.Today.AddDays(2) });
            Orders.Add(new Order { Username = "Asadbek", FloorId = 1, RoomId = 4, StartDate = DateTime.Today.AddDays(-1), EndDate = DateTime.Today.AddDays(2) });
            Orders.Add(new Order { Username = "Ruslan", FloorId = 3, RoomId = 1, StartDate = DateTime.Today.AddDays(-1), EndDate = DateTime.Today.AddDays(2) });
            gridOrders.ItemsSource = Orders;
            gridOrders.Items.Refresh();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _abstractFactory.Create().Show();

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if(searchText.Text.Length > 2)
            {
                gridOrders.ItemsSource = Orders.Where(obj => obj.Username.ToLower().Contains(searchText.Text.ToLower()));
                gridOrders.Items.Refresh();
            }
            else
            {
                gridOrders.ItemsSource = Orders;
                gridOrders.Items.Refresh();
            }
        }
    }
}
