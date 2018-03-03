using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

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

            // Part 2 Demos start here.
            PrintHeaderFooter("Any DEMO - Check if there are *any* orders with certain quantities", () => AnyDemo(Orders));
            PrintHeaderFooter("Distinct DEMO - Get Distinct Order Quantities", () => DistinctDemo(Orders));
        }

        private static void DistinctDemo(List<Order> orders)
        {
            var distinctQuantityOrders = orders.Select(order => order.Quantity).Distinct();
            distinctQuantityOrders.ToList().ForEach(quantity => WriteLine($"Distinct Quantity: {quantity}"));
        }

        private static void AnyDemo(List<Order> orders)
        {
            var ordersMoreThanEqualToQuantity30Exists = orders.Any(order => order.Quantity >= 30);
            WriteLine($"Are there orders with quantity great than and equal to 30? {ordersMoreThanEqualToQuantity30Exists}");

            var ordersBeforeYear2018 = orders.Any(order => order.OrderDate.Year < 2018);
            WriteLine($"Are there orders ordered before 2018? {ordersBeforeYear2018}");

            var ordersWithIDGreaterThan100 = orders.Any(order => order.Id > 100);
            WriteLine($"Do we have more than 100 Orders? {ordersWithIDGreaterThan100}");
        }

        private static void OrderByDescendingDemo(List<Order> orders)
        {
            // https://msdn.microsoft.com/en-us/library/system.linq.enumerable.orderbydescending(v=vs.110).aspx
            var orderedOrders = orders.OrderByDescending(order => order.Quantity);
            PrintOrders(orderedOrders);
        }

        private static void OrderByDemo(List<Order> orders)
        {
            // https://msdn.microsoft.com/en-us/library/system.linq.enumerable.orderby(v=vs.110).aspx
            var orderedOrders = orders.OrderBy(order => order.Quantity);
            PrintOrders(orderedOrders);
        }

        private static void WhereDemo(List<Order> orders)
        {
            // https://msdn.microsoft.com/en-us/library/system.linq.enumerable.where(v=vs.110).aspx
            var ordersWithQuantityOver30 = orders.Where(order => order.Quantity > 30);
            PrintOrders(ordersWithQuantityOver30);
        }

        private static void AggregateDemo(List<Order> orders)
        {
            const int initialQuantity = 0;
            // https://msdn.microsoft.com/en-us/library/system.linq.enumerable.aggregate(v=vs.110).aspx
            var totalQuantities = orders.Aggregate(initialQuantity, (sum, order) => sum + order.Quantity);
            // Same as Order simply use a convinient `Sum()` method.
            // var totalQuantities = orders.Sum(order => order.Quantity);
            WriteLine($"Total Quantities: {totalQuantities}");
        }

        private static void SelectDemo(List<Order> orders)
        {
            // https://msdn.microsoft.com/en-us/library/system.linq.enumerable.select(v=vs.110).aspx
            var quantities = orders.Select(order => order.Quantity);
            quantities.ToList().ForEach(quantity => WriteLine($"Quantity: {quantity}"));
        }

        private static void PrintHeaderFooter(string title, Action action)
        {
            var divider = new string('=', 20);
            WriteLine($"{divider}  {title}  {divider}");
            action();
        }

        private static void PrintOrders(IEnumerable<Order> orders) {
            foreach (var order in orders){
                WriteLine(order);
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
