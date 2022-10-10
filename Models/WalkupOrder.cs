using System;
using System.ComponentModel.DataAnnotations;

namespace Vu_Victoria_HW2.Models
{
    public class WalkupOrder: Order
    {
        //constants
        //sales tax rate
        public const Decimal SALES_TAX_RATE = 0.0825M;

        //properties
        //customer type - walkup
        [Display(Name = "Customer Type:")]
        public CustomerType Walkup { get; set; }

        //customer name
        [Display(Name = "Customer Name:")]
        public String CustomerName { get; set; }

        //sales tax
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal SalesTax { get; set; }

        //methods
        //calculating totals
        public void CalcTotals()
        {
            CalcSubtotals();
            SalesTax = Subtotal * SALES_TAX_RATE;
            Total = SalesTax + Subtotal;
        }
    }
}
