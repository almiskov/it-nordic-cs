using System;
using System.Collections.Generic;

namespace Lesson_34_Classwork.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal Discount { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
