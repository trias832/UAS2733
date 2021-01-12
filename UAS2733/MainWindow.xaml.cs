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
using UAS2733.Controller;
using UAS2733.Model;
using static UAS2733.PilihPromo;

namespace UAS2733
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,
        OnPenawaranChangedListener,
        OnPilihPromoChangedListener,
        OnPaymentChangedListener,
        OnKeranjangBelanjaChangedListener
    {
        MainWindowController controller;
        Payment payment;

        public MainWindow()
        {
            InitializeComponent();

            payment = new Payment(this);

            KeranjangBelanja keranjangBelanja = new KeranjangBelanja(payment, this);

            controller = new MainWindowController(keranjangBelanja);

            listBoxPesanan.ItemsSource = controller.getSelectedItems();
            listBoxPakaiPromo.ItemsSource = controller.getSelectedPromos();

            initializeView();

        }

        private void initializeView()
        {
            labelSubtotal.Content = "Rp 0";
            labelGrantTotal.Content = "Rp 0";
            labelPromoFee.Content = "Rp 0";
        }

        public void onPenawaranSelected(Item item)
        {
            controller.addItem(item);
        }

        private void onButtonAddItemClicked(object sender, RoutedEventArgs e)
        {
            Penawaran penawaranWindow = new Penawaran();
            penawaranWindow.SetOnItemSelectedListener(this);
            penawaranWindow.Show();
        }

        private void listBoxPesanan_ItemClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Kamu ingin menghapus item ini?",
                    "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Item item = listBox.SelectedItem as Item;
                controller.deleteSelectedItem(item);
            }
        }

        private void listBoxPakaiPromo_ItemClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Kamu ingin membatalkan voucher ini?",
                   "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Promo item = listBox.SelectedItem as Promo;
                controller.deleteSelectedPromo(item);
            }
        }

        public void onPriceUpdated(double subtotal, double grantTotal, double potongan)
        {
            labelSubtotal.Content = "Rp " + subtotal;
            labelGrantTotal.Content = "Rp " + grantTotal;
            labelPromoFee.Content = "Rp " + potongan;
        }

        public void removeItemSucceed()
        {
            listBoxPesanan.Items.Refresh();
        }

        public void addItemSucceed()
        {
            listBoxPesanan.Items.Refresh();
        }

        public void removePromoSucceed()
        {
            listBoxPakaiPromo.Items.Refresh();
        }

        public void addPromoSucceed()
        {
            listBoxPakaiPromo.Items.Refresh();
        }

        private void OnPilihPromoClicked(object sender, RoutedEventArgs e)
        {
            PilihPromo pilihPromoWindow = new PilihPromo();
            pilihPromoWindow.SetOnItemSelectedListener(this);
            pilihPromoWindow.Show();
        }

        public void OnPilihPromoChangedListener(Promo item)
        {
            controller.addPromo(item);
        }


    }

}
