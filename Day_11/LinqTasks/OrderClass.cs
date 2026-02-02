///<summary>
/// Here i define OrderClass with 3 private and 1 public fields 
/// Also define OrderItem class which has 2 private fields
/// And one static method Called AddOrderToList which adds dummy data to list and returns Order List.
/// </summary>


using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTasks
{
    internal class OrderClass
    {
        static int IDSault = 10001;

        private int _OrderId;
        private string _CustomerName = string.Empty;
        public List<OrderItem>ListOfOrderItem; 
        public OrderClass(int OrderId,string CustomerName, List<OrderItem> list)
        {
            this.OrderId = OrderId;
            this.CustomerName = CustomerName;
            this.ListOfOrderItem = list;
                     
        }

        public int OrderId { get { return _OrderId;  } set { _OrderId = value; } }
        public string CustomerName { get { return _CustomerName; } set { _CustomerName = value; } }
   
        public static List<OrderClass> AddOrderToList()
        {
            List<OrderClass> orderClasses = new List<OrderClass>()
            {
               new OrderClass(IDSault++,"Raj",   new List<OrderItem>(){ new OrderItem("Soffa",15000),               new OrderItem("Electric Stove",2500),  new OrderItem("Fan",1500)}),
               new OrderClass(IDSault++,"Ram",   new List<OrderItem>(){ new OrderItem("Lenovo ideapad slim3",50000),new OrderItem("Electric Stove",2500),  new OrderItem("Fan",1500)}),
               new OrderClass(IDSault++,"Rahul", new List<OrderItem>(){ new OrderItem("Soffa cover",1000),          new OrderItem("Electric hitter",3000), new OrderItem("TV",10000)}),
               new OrderClass(IDSault++,"Radha", new List<OrderItem>(){ new OrderItem("OnePuls Airbuds",1500),      new OrderItem("Air freshner",65),      new OrderItem("Chips",100)}),
               new OrderClass(IDSault++,"Ramesh",new List<OrderItem>(){ new OrderItem("Dinner Set",2000),           new OrderItem("Soffa", 25000),         new OrderItem("Contact lense",1500)}),
               new OrderClass(IDSault++,"Ravi",  new List<OrderItem>(){ new OrderItem("Kitechen set",5000),         new OrderItem("Flower Pott", 150)}),
               new OrderClass(IDSault++,"Rakesh",new List<OrderItem>(){ new OrderItem("Flower Pott",150)}),
            };

            return orderClasses;
        }
    }

    internal class OrderItem
    {
        private string _ProductName = string.Empty;
        private double _Price;

        public OrderItem(string ProductName,double Price)
        {
            this.ProductName = ProductName;
            this.Price = Price;
        }

        public string ProductName { get { return _ProductName; } set { _ProductName = value; } }
        public double Price { get { return _Price; } set { _Price = value; } }
    }
}
