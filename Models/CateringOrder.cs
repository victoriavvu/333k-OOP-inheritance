using System;
using System.ComponentModel.DataAnnotations;

namespace Vu_Victoria_HW2.Models
{
    public class CateringOrder: Order
    {
        //properties
        //customer type - catering
        [Display(Name = "Customer Type:")]
        public CustomerType Catering { get; set; }

        //customer code
        [Display(Name = "Customer Code:")]
        [Required(ErrorMessage = "Customer code is required!")]
        [StringLength(4)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Customer code may only contain letters.")]
        public String CustomerCode { get; set; }

        //delivery fee
        [Display(Name = "Delivery Fee:")]
        [Required(ErrorMessage = "Delivery fee is required!")]
        [Range(0, int.MaxValue, ErrorMessage = "The field Delivery Fee: must be a number.")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal DeliveryFee { get; set; }

        //preferred customer
        [Display(Name = "Is this a preferred customer?")]
        public Boolean PreferredCustomer { get; set; }

        //methods
        //calculating totals
        public void CalcTotals()
        {
            //calculating subtotals
            CalcSubtotals();
            //delivery fee is 0 if they're a preferred customer or if subtotal >= 1000
            if (PreferredCustomer || Subtotal >= 1000)
            {
                 DeliveryFee = 0m;
            }
            //calculating total
            Total = Subtotal + DeliveryFee;
        }
    }
}
