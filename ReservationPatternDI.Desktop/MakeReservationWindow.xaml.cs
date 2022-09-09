using ReservationPatternDI.Desktop.Models;
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

namespace ReservationPatternDI.Desktop
{
    /// <summary>
    /// Interaction logic for MakeReservationWindow.xaml
    /// </summary>
    public partial class MakeReservationWindow : Window
    {
        private int _counter;
        private OrdersWindow _ordersWindow;

        public MakeReservationWindow(OrdersWindow ordersWindow)
        {
            InitializeComponent();
            startDate.SelectedDate = DateTime.MinValue;
            endDate.SelectedDate = DateTime.MinValue;

            _ordersWindow = ordersWindow;

        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            int _floorId = int.Parse(floorId.Text);
            int _roomId = int.Parse(roomId.Text);

            Order order = new Order{ Username = username.Text, FloorId = _floorId, RoomId = _roomId, StartDate = startDate.SelectedDate.Value, EndDate = endDate.SelectedDate.Value };

            if (order.StartDate > order.EndDate)
            {
                MessageBox.Show("Conflict with date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                startDate.SelectedDate = DateTime.MinValue;
                endDate.SelectedDate = DateTime.MinValue;
                return;
            }

            foreach (Order item in _ordersWindow.Orders)
            {
                if (item.RoomId == order.RoomId && item.FloorId == order.FloorId)
                {
                    MessageBox.Show("The room is occupied", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    floorId.Text = "";
                    roomId.Text = "";
                    return;

                }
            }
            _ordersWindow.Orders.Add(order);
            _ordersWindow.gridOrders.ItemsSource = _ordersWindow.Orders;
            _ordersWindow.gridOrders.Items.Refresh();

            this.Close();

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            username.Text = "";
            floorId.Text = "";
            roomId.Text = "";
            startDate.DataContext = DateTime.MinValue;
            endDate.DataContext = DateTime.MinValue;
        }
    }
}
