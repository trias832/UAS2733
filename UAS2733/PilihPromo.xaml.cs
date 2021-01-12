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
    public partial class PilihPromo : Window
    {
        Controller.PromoController promoController;
        OnPilihPromoChangedListener listener;


        public PilihPromo()
        {
            InitializeComponent();

            promoController = new Controller.PromoController();
            DaftarPromo.ItemsSource = promoController.getItems();

            generateListPromo();
        }

       
        private void generateListPromo()
        {
            Model.Promo awalTahun = new Model.Promo(title: "Promo Awal Tahun Diskon 25%", discInPercent: 25);
            Model.Promo tebusMurah = new Model.Promo(title: "Promo Tebus Murah Diskon 30% atau max. 30.000", discInPercent: 30);
            Model.Promo promoNatal = new Model.Promo(title: "Promo Natal Potongan 10000", disc: 10000);

            promoController.addItem(awalTahun);
            promoController.addItem(tebusMurah);
            promoController.addItem(promoNatal);

            DaftarPromo.Items.Refresh();
        }

        public void SetOnItemSelectedListener(OnPilihPromoChangedListener listener)
        {
            this.listener = listener;
        }

        public interface OnPilihPromoChangedListener
        {
            void OnPilihPromoChangedListener(Model.Promo item);
        }

        private void DaftarPromoSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Model.Promo item = listbox.SelectedItem as Model.Promo;

            this.listener.OnPilihPromoChangedListener(item);
        }
    }
}
