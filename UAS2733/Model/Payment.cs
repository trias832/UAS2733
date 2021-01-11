using System;
using System.Collections.Generic;
using System.Text;

namespace UAS2733.Model
{
    class Payment
    {
        
        private OnPaymentChangedListener paymentCallback;

        public Payment(OnPaymentChangedListener paymentCallback)
        {
            this.paymentCallback = paymentCallback;
        }

        public void updateTotal(double subtotal, double potongan)
        {
            double total = subtotal + potongan;
            this.paymentCallback.onPriceUpdated(subtotal, total, potongan);
        }

    }
    interface OnPaymentChangedListener
    {
        void onPriceUpdated(double subtotal, double grantTotal, double potongan);
    }
}
