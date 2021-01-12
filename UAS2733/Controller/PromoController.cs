using System;
using System.Collections.Generic;
using System.Text;
using UAS2733.Model;

namespace UAS2733.Controller
{
    class PromoController
    {
        private List<Promo> items;

        public PromoController()
        {
            items = new List<Promo>();
        }

        public void addItem(Promo item)
        {
            this.items.Add(item);
        }

        public List<Promo> getItems()
        {
            return this.items;
        }

    }
}
