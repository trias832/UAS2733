using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UAS2733
{
    /// <summary>
    /// Interaction logic for PilihVoucher.xaml
    /// </summary>
    public partial class PilihVoucher : Window
    {
        Controller.VoucherController voucherController;
        OnPilihVoucherChangedListener listener;

        public PilihVoucher()
        {
            InitializeComponent();

            voucherController = new Controller.VoucherController();
            DaftarVoucher.ItemsSource = voucherController.getItems();

            generateListVoucher();
        }

        private void generateListVoucher()
        {
            Model.Voucher awalTahun = new Model.Voucher(title: "Promo Awal Tahun Diskon 25%", discInPercent: 25);
            Model.Voucher tebusMurah = new Model.Voucher(title: "Promo Tebus Murah Diskon 30% atau max. 30.000", discInPercent: 30);
            Model.Voucher promoNatal = new Model.Voucher(title: "Promo Natal Potongan 10000", disc: 10000);

            voucherController.addItem(awalTahun);
            voucherController.addItem(tebusMurah);
            voucherController.addItem(promoNatal);

            DaftarVoucher.Items.Refresh();
        }

        public void SetOnItemSelectedListener(OnPilihVoucherChangedListener listener)
        {
            this.listener = listener;
        }

        public interface OnPilihVoucherChangedListener
        {
            void OnPilihVoucherChangedListener(Model.Voucher item);
        }

        private void DaftarVoucherSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Model.Voucher item = listbox.SelectedItem as Model.Voucher;

            this.listener.OnPilihVoucherChangedListener(item);
        }
    }
}
