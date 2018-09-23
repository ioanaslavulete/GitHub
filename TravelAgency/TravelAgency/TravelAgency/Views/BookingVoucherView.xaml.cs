﻿using System;
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

namespace TravelAgency.Views
{
    /// <summary>
    /// Interaction logic for BookingVoucherView.xaml
    /// </summary>
    public partial class BookingVoucherView : Window
    {
        public BookingVoucherView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Reservation Successful !");
            this.Close();
        }
    }
}
