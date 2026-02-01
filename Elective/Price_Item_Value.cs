using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elective
{
    internal class Price_Item_Value
    {
        public String price, itemname, discount_amount; //codes for setting the value of the item name and item price, which are to be stored inside these variables.

        public void SetPriceItemValue(string item_name, string item_price)
        {
            this.itemname = item_name;
            this.price = item_price;
        }

        //codes for getting the value of an item and using it as needed in the application
        public string GetItemName()
        {
            return itemname;
        }

        //codes for getting the value of a price and using it as needed in the application
        public string GetPrice()
        {
            return price;
        }

        //codes for setting the value of the discount amount and item price, which are to be stored inside the discount_amt and priceItem variables
        public void SetPriceDiscountAmountValue(string discount_amt, string priceItem)
        {
            this.price = priceItem;
            this.discount_amount = discount_amt;
        }

        //codes for getting the value of an item and using it as needed in the application
        public string GetPriceItem()
        {
            return price;
        }

        //codes for getting the value of a discount amount and using it as needed in the application
        public string GetDiscountAmount()
        {
            return discount_amount;
        }
    }
}
