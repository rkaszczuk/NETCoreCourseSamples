using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _07_MethodChaining.Samples
{
    public enum PaymentOptions { Cash, CreditCard, BankTransfer}
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class Order
    {
        public string Address { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalPrice { get; set; }
        public PaymentOptions PaymentOption { get; set; }
    }

    public class OrderCompositionSample
    {
        private Order order;
        public OrderCompositionSample()
        {
            order = new Order();
        }
        public OrderCompositionSample AddProduct(Product product)
        {
            order.Products.Add(product);
            return this;
        }
        public OrderCompositionSample SetAddress(string address)
        {
            order.Address = address;
            return this;
        }
        public OrderCompositionSample SetPaymentOption(PaymentOptions paymentOption)
        {
            order.PaymentOption = paymentOption;
            return this;
        }
        public Order ComposeOrder()
        {
            order.TotalPrice = order.Products.Sum(x => x.Price);
            return order;
        }
    }

    public class OrderCompositionStaticInitSample
    {
        private Order order;
        private OrderCompositionStaticInitSample()
        {
            order = new Order();
        }
        public static OrderCompositionStaticInitSample Init()
        {
            return new OrderCompositionStaticInitSample();
        }

        public OrderCompositionStaticInitSample AddProduct(Product product)
        {
            order.Products.Add(product);
            return this;
        }
        public OrderCompositionStaticInitSample SetAddress(string address)
        {
            order.Address = address;
            return this;
        }
        public OrderCompositionStaticInitSample SetPaymentOption(PaymentOptions paymentOption)
        {
            order.PaymentOption = paymentOption;
            return this;
        }
        public Order ComposeOrder()
        {
            order.TotalPrice = order.Products.Sum(x => x.Price);
            return order;
        }
    }
}
