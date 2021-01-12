using System;
using System.Collections.Generic;
using System.Text;
using UAS2733.Model;

namespace UAS2733.Controller
{
    class MainWindowController
    {
        KeranjangBelanja keranjangBelanja;

        public MainWindowController(KeranjangBelanja keranjangBelanja)
        {
            this.keranjangBelanja = keranjangBelanja;
        }

        public void addItem(Item item)
        {
            this.keranjangBelanja.addItem(item);
        }

        public void addPromo(Promo item)
        {
            this.keranjangBelanja.addPromo(item);
        }
        public List<Item> getSelectedItems()
        {
            return this.keranjangBelanja.getItems();
        }

        public List<Promo> getSelectedPromos()
        {
            return this.keranjangBelanja.getPromo();
        }

        public void deleteSelectedItem(Item item)
        {
            this.keranjangBelanja.removeItem(item);
        }

        public void deleteSelectedPromo(Promo item)
        {
            this.keranjangBelanja.removePromo(item);
        }


    }
}
