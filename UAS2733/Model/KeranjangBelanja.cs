using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace UAS2733.Model
{
    class KeranjangBelanja
    {
        List<Item> itemBelanja;
        List<Promo> itemPromo;
        int maksimal = 1;
        Payment payment;
        OnKeranjangBelanjaChangedListener callback;

        public KeranjangBelanja(Payment payment, OnKeranjangBelanjaChangedListener callback)
        {
            this.payment = payment;
            this.itemBelanja = new List<Item>();
            this.itemPromo = new List<Promo>();
            this.callback = callback;
        }
        public List<Item> getItems()
        {
            return this.itemBelanja;
        }

        public List<Promo> getPromo()
        {
            return this.itemPromo;
        }


        public void addItem(Item item)
        {
            this.itemBelanja.Add(item);
            this.callback.addItemSucceed();
            calculateSubTotal();
        }

        public void addPromo(Promo item)
        {
            if (maksimal == 1)
            {
                this.itemPromo.Add(item);
                this.callback.addPromoSucceed();
                maksimal = 0;
                calculateSubTotal();
            }
            else
            {
                MessageBox.Show("Oopss! Hanya dapat menggunakan 1 voucher", "Warning", MessageBoxButton.OK);
            }
        }

        public void removePromo(Promo item)
        {
            this.itemPromo.Remove(item);
            this.callback.removePromoSucceed();
            maksimal = 1;
            calculateSubTotal();
        }

        public void removeItem(Item item)
        {
            this.itemBelanja.Remove(item);
            this.callback.removeItemSucceed();
            calculateSubTotal();
        }

        private void calculateSubTotal()
        {
            double subtotal = 0;
            double potongan = 0;
            foreach (Item item in itemBelanja)
            {
                subtotal += item.price;
            }

            foreach (Promo promo in itemPromo)
            {
                if (promo.discInPercent != 0)
                {

                    if (promo.discInPercent == 30)
                    {
                        if (subtotal >= 100000)
                        {
                            potongan -= 30000;
                        }
                        else
                        {
                            potongan -= subtotal * (promo.discInPercent / 100);
                        }
                    }
                    else
                    {
                        potongan -= subtotal * (promo.discInPercent / 100);
                    }
                }

                if (promo.disc != 0)
                {
                    potongan -= promo.disc;
                }
            }
            payment.updateTotal(subtotal, potongan);


        }

    }
    interface OnKeranjangBelanjaChangedListener
    {
        void removeItemSucceed();
        void addItemSucceed();

        void removePromoSucceed();
        void addPromoSucceed();
    }
}
