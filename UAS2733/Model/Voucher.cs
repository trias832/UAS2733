using System;
using System.Collections.Generic;
using System.Text;

namespace UAS2733.Model
{
    public class Voucher
    {
        public string title { get; set; }
        public double disc { get; set; }

        public double discInPercent { get; set; }

        public Voucher(string title, double disc = 0, double discInPercent = 0)
        {
            this.title = title;
            this.disc = disc;
            this.discInPercent = discInPercent;
        }
    }
}
