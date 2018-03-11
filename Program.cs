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
            PrintHeaderFooter("Concat DEMO - Concatenate the first and the last orders", () => ConcatDemo(Orders));
            PrintHeaderFooter("SelectMany DEMO - Concatenate the first and the last orders", () => SelectManyDemo(Orders));

            // Part 3 Demos start here.
            PrintHeaderFooter("Reverse DEMO - Reverse elements", () => ReverseDemo(Orders));
        }

        /// <summary>
        /// "Reverse" is different from "OrderBy" that you don't specify which element to reverse with.
        /// It simply reverses the current sequence in opposite order.
        /// Therefore passing sample orders would simply reverse by order ID, as it is how it is declared.
        /// 
        /// In this demo, I will first reverse first & last half of the order and reverse that list.
        /// </summary>
        private static void ReverseDemo(List<Order> orders)
        {
            int mid = orders.Count / 2;
            var leftHalf = orders.Take(mid);
            var rightHalf = orders.Skip(mid);
            var combinedOrders = rightHalf.Concat(leftHalf);

            const int indentyBy = 4;  // indent sub result
            PrintHeaderFooter("Reversing from this list", () => PrintOrders(combinedOrders, indentyBy), indentyBy, '*');

            var reversedOrders = combinedOrders.Reverse();
            PrintOrders(reversedOrders);
        }

        private static void SelectManyDemo(List<Order> orders)
        {
            // WARNING ⚠️: Super contrived example again...
            var firstOrder = orders.Take(1);
            var lastOrder = orders.TakeLast(1);
            var firstAndLastOrders = new[] { firstOrder, lastOrder }.SelectMany(order => order);
            PrintOrders(firstAndLastOrders);
        }

        private static void ConcatDemo(List<Order> orders)
        {
            // WARNING ⚠️: Super contrived example
            var firstOrder = orders.Take(1);
            var lastOrder = orders.TakeLast(1);
            var firstAndLastOrders = firstOrder.Concat(lastOrder);
            PrintOrders(firstAndLastOrders);
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

        private static void PrintHeaderFooter(
            string title, Action action, int indentBy = 0, char dividerCharacter = '=')
        {
            var divider = new string(dividerCharacter, 20);
            var indentation = new string(' ', indentBy);
            WriteLine($"{indentation}{divider}  {title}  {divider}");
            action();
        }

        private static void PrintOrders(IEnumerable<Order> orders, int indentBy = 0)
        {
            foreach (var order in orders)
            {
                var indentation = new string(' ', indentBy);
                WriteLine($"{indentation}{order}");
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
    
    internal class OrderEqualityCompaprer : IEqualityComparer<Order>
    {
         public bool Equals(Order x, Order y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(Order order)
        {
            if (order == null) return 0;

            return order.Id.GetHashCode();
        }
    }

}
