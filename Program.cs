using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace LinqAndJavascript.CSharpDemo
{
    class Program
    {
        private static List<Order> Orders = new List<Order>{
            new Order(id: 1, quantity: 40, orderDate: new DateTime(2018, 1,1,1,1,1,1)),
            new Order(id: 2, quantity: 20, orderDate: new DateTime(2018, 2,2,2,2,2,2)),
            new Order(id: 3, quantity: 30, orderDate: new DateTime(2018, 3,3,3,3,3,3)),
            new Order(id: 4, quantity: 10, orderDate: new DateTime(2018, 4,4,4,4,4,4)),
            new Order(id: 5, quantity: 20, orderDate: new DateTime(2018, 5,5,5,5,5,5)),
        };

        static void Main(string[] args)
        {
            PrintHeaderFooter("Select DEMO - Print Order Quantities", () => SelectDemo(Orders));
            PrintHeaderFooter("Aggregate DEMO - Sum Quantities", () => AggregateDemo(Orders));
            PrintHeaderFooter("Where DEMO - Order with Quantity over 30", () => WhereDemo(Orders));
            PrintHeaderFooter("OrderBy DEMO - Order by Quantities in Ascending Order", () => OrderByDemo(Orders));
            PrintHeaderFooter("OrderByDescending DEMO - Order by Quantities in Descending Order", () => OrderByDescendingDemo(Orders));
        }

        private static void OrderByDescendingDemo(List<Order> orders)
        {
            var orderedOrders = orders.OrderByDescending(order => order.Quantity);
            PrintOrders(orderedOrders);
        }

        private static void OrderByDemo(List<Order> orders)
        {
            var orderedOrders = orders.OrderBy(order => order.Quantity);
            PrintOrders(orderedOrders);
        }

        private static void WhereDemo(List<Order> orders)
        {
            var ordersWithQuantityOver30 = orders.Where(order => order.Quantity > 30);
            PrintOrders(ordersWithQuantityOver30);
        }

        private static void AggregateDemo(List<Order> orders)
        {
            const int initialQuantity = 0;
            var totalQuantities = orders.Aggregate(initialQuantity, (sum, order) => sum + order.Quantity);
            // Same as Order simply use a convinient `Sum()` method.
            // var totalQuantities = orders.Sum(order => order.Quantity);
            System.Console.WriteLine($"Total Quantities: {totalQuantities}");
        }

        private static void SelectDemo(List<Order> orders)
        {
            var quantities = orders.Select(order => order.Quantity);
            quantities.ToList().ForEach(quantity => System.Console.WriteLine($"Quantity: {quantity}")));
        }

        private static void PrintHeaderFooter(string title, Action action)
        {
            var divider = new string('=', 20);
            System.Console.WriteLine($"{divider}  {title}  {divider}");
            action();
        }

        private static void PrintOrders(IEnumerable<Order> orders) {
            foreach (var order in orders){
                System.Console.WriteLine(order);
            }
        }
    }

    class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(int id, int quantity, DateTime orderDate)
        {
            Id = id;
            Quantity = quantity;
            OrderDate = orderDate;
        }

        public override string ToString()
        {
            return $"Order ID: {Id}, Quantity: {Quantity}, Order Date: {OrderDate.ToString("dd MMM yyyy hh:mm tt p\\s\\t", CultureInfo.InvariantCulture)}";
        }
    }
}
