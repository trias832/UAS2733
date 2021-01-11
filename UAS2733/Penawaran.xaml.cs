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
using UAS2733.Controller;
using UAS2733.Model;

namespace UAS2733
{/// <summary>
 /// Interaction logic for Penawaran.xaml
 /// </summary>

    public partial class Penawaran : Window
    {
        PenawaranController Penawarancontroller;
        OnPenawaranChangedListener listener;
        public Penawaran()
        {
            InitializeComponent();

            Penawarancontroller = new PenawaranController();
            listPenawaran.ItemsSource = Penawarancontroller.getItems();

            generateContentPenawaran();

        }

        public void SetOnItemSelectedListener(OnPenawaranChangedListener listener)
        {
            this.listener = listener;
        }

        private void generateContentPenawaran()
        {
            Item drink1 = new Item("Coffe Late", 30000);
            Item drink2 = new Item("BlackTea", 20000);
            Item food1 = new Item("Pizza", 75000);
            Item drink3 = new Item("Milk Shake", 15000);
            Item food2 = new Item("Fried Rice Special", 45000);
            Item drink4 = new Item("Watermelon Juice", 25000);
            Item drink5 = new Item("Lemon Squash", 30000);
            
            

            Penawarancontroller.addItem(drink1);
            Penawarancontroller.addItem(drink2);
            Penawarancontroller.addItem(food1);
            Penawarancontroller.addItem(drink3);
            Penawarancontroller.addItem(food2);
            Penawarancontroller.addItem(drink4);
            Penawarancontroller.addItem(drink5);

            listPenawaran.Items.Refresh();
        }

        private void listPenawaran_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Item item = listbox.SelectedItem as Item;

            this.listener.onPenawaranSelected(item);
        }
    }
    public interface OnPenawaranChangedListener
    {
        void onPenawaranSelected(Item item);
    }
}

