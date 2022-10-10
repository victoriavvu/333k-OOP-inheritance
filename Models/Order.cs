using System;
using System.ComponentModel.DataAnnotations;

namespace Vu_Victoria_HW2.Models
{
    //enum customer type - walkup & catering
    public enum CustomerType 
    { 
        Walkup, 
        Catering 
    }
    public abstract class Order
    {
        //constants
        //taco & burger prices
        public const Decimal TACO_PRICE = 2.75M;
        public const Decimal BURGER_PRICE = 4.50M;

        //properties
        //customer type
        public CustomerType CustomerType { get; set; }

        //number of burgers
        [Display(Name = "Number of Burgers:")]
        [Required(ErrorMessage = "Number of burgers is required!")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Number of burgers must be at least zero!")]
        public Int32 NumberOfBurgers { get; set; }

        //number of tacos
        [Display(Name = "Number of Tacos:")]
        [Required(ErrorMessage = "Number of tacos is required!")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Number of tacos must be at least zero!")]
        public Int32 NumberOfTacos { get; set; }

        //burger subtotal
        [Display(Name = "Burger Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal BurgerSubtotal { get; private set; }

        //taco subtotal
        [Display(Name = "Taco Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal TacoSubtotal { get; private set; }

        //subtotal
        [Display(Name = "Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Subtotal { get; private set; }

        //total
        [Display(Name = "Total:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Total { get; protected set; }

        //total items
        [Display(Name = "Total Items:")]
        public Int32 TotalItems { get; private set; }

        //methods
        //calculating subtotals
        public void CalcSubtotals()
        {
            //calculating total items & ensuring the customer purchases atleast one item
            TotalItems = NumberOfBurgers + NumberOfTacos;
            if (TotalItems == 0)
            {
                throw new Exception("You must purchase atleast one item.");
            }
            //taco subtotal
            TacoSubtotal = NumberOfTacos * TACO_PRICE;
            //burger subtotal
            BurgerSubtotal = NumberOfBurgers * BURGER_PRICE;
            //subtotal (tacos + burgers)
            Subtotal = TacoSubtotal + BurgerSubtotal;
        }
    }
    
}
