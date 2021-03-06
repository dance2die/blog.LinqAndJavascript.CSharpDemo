﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;

namespace LinqAndJavascript.CSharpDemo
{
    class Program
    {
        private const int indentBy = 4;
        private static DateTime march = new DateTime(2018, 3, 1);
        private static DateTime september = new DateTime(2018, 9, 1);

        private static Order NullOrder = new Order(-1, 0, DateTime.MinValue);
        private static List<Order> Orders = new List<Order>{
            new Order(id: 1, quantity: 40, orderDate: new DateTime(2018, 1,1,1,1,1,1)),
            new Order(id: 2, quantity: 20, orderDate: new DateTime(2018, 2,2,2,2,2,2)),
            new Order(id: 3, quantity: 30, orderDate: new DateTime(2018, 3,3,3,3,3,3)),
            new Order(id: 4, quantity: 10, orderDate: new DateTime(2018, 4,4,4,4,4,4)),
            new Order(id: 5, quantity: 20, orderDate: new DateTime(2018, 5,5,5,5,5,5)),
        };

        private static List<Order> DomesticOrders = new List<Order>{
            new Order(id: 1, quantity: 40, orderDate: new DateTime(2018, 1,1,1,1,1,1)),
            new Order(id: 11, quantity: 20, orderDate: new DateTime(2018, 11,2,2,2,2,2)),
            new Order(id: 111, quantity: 450, orderDate: new DateTime(2018, 11,1,2,2,2,2)),
            new Order(id: 1111, quantity: 230, orderDate: new DateTime(2018, 11,11,2,2,2,2)),
        };

        private static List<Order> InternationalOrders = new List<Order>{
            new Order(id: 3, quantity: 30, orderDate: new DateTime(2018, 3,3,3,3,3,3)),
            new Order(id: 33, quantity: 300, orderDate: new DateTime(2018, 3,3,3,3,33,3)),
            new Order(id: 4, quantity: 10, orderDate: new DateTime(2018, 4,4,4,4,4,4)),
            new Order(id: 44, quantity: 100, orderDate: new DateTime(2018, 4,4,4,4,44,4)),
            new Order(id: 5, quantity: 20, orderDate: new DateTime(2018, 5,5,5,5,5,5)),
            new Order(id: 55, quantity: 200, orderDate: new DateTime(2018, 5,5,5,5,55,5)),
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
            PrintHeaderFooter("Zip DEMO - Appending Order Numbers in Text", () => ZipDemo(Orders));
            PrintHeaderFooter("Min/Max DEMO - Get Min and Max Order Quantities", () => MinMaxDemo(Orders));

            // Part 4 Demos start here.
            PrintHeaderFooter("Union DEMO - Display Domestic & International Orders", () => UnionDemo(DomesticOrders, InternationalOrders));
            var ordersOnHold = Orders;
            PrintHeaderFooter("Intersect (intersection) DEMO - Find All Orders on Hold", () => IntersectDemo(ordersOnHold, DomesticOrders, InternationalOrders));
            PrintHeaderFooter("Except (subtraction) DEMO - Get all orders NOT on hold", () => ExceptDemo(ordersOnHold, DomesticOrders, InternationalOrders));

            // Part 5 Demos start here.
            PrintHeaderFooter("Sum DEMO - Sum All Quantities", () => SumDemo(Orders));
            PrintHeaderFooter("Avarage DEMO - Average Quantity", () => AverageDemo(Orders));
            PrintHeaderFooter("Count DEMO - Count Orders Placed On and After March", () => CountDemo(Orders));

            // Part 6 Demos start here.
            PrintHeaderFooter("First/FirstOrDefault DEMO - Get First Order", () => FirstDemo(Orders));
            PrintHeaderFooter("Last/LastOrDefault DEMO - Get Last Order", () => LastDemo(Orders));
            PrintHeaderFooter("DefaultIfEmpty DEMO - Get Order or Default if Empty", () => DefaultIfEmptyDemo(Orders));
            PrintHeaderFooter("Skip/SkipWhile DEMO - Skip Orders", () => SkipDemo(Orders));
            PrintHeaderFooter("Take/TakeWhile DEMO - Take Orders", () => TakeDemo(Orders));

            // Part 7 Demos start here.
            PrintHeaderFooter("Empty DEMO - Get an Empty Order Sequence", () => EmptyDemo());
            PrintHeaderFooter("Repeat DEMO - Repeat Texts", () => RepeatDemo());
            PrintHeaderFooter("Range DEMO - Some Generic Examples", () => RangeDemo());

            // Part 8 Demos start here.
            PrintHeaderFooter("All DEMO - Check If All Orders Match a Condition", () => AllDemo(Orders));
            PrintHeaderFooter("Contains DEMO - Do Shipped Orders Contain a Domestic Order?", () => ContainsDemo(Orders, DomesticOrders));
            PrintHeaderFooter("SequenceEqual DEMO - Check If Two Sequences Are The Same", () => SequenceEqualDemo(Orders, DomesticOrders));
        }

        private static void SequenceEqualDemo(List<Order> shippedOrders, List<Order> domesticOrders)
        {
            var sameOrderAreSame = shippedOrders.SequenceEqual(shippedOrders);
            WriteLine($"Same Orders share the same sequence {sameOrderAreSame}");
            var areAllDomesticOrdersShipped = shippedOrders.SequenceEqual(domesticOrders);
            WriteLine($"Are All Domestic Order Shipped? {areAllDomesticOrdersShipped}");
        }

        private static void ContainsDemo(List<Order> shippedOrders, List<Order> domesticOrders)
        {
            var firstDomesticOrder = domesticOrders.First();
            var containsDomesticOrder = shippedOrders.Contains(firstDomesticOrder, new OrderEqualityCompaprer());
            WriteLine($"Is the first domestic order shipped? {containsDomesticOrder}");
        }

        private static void AllDemo(List<Order> orders)
        {
            var areAllOrdersPlacedOn2018 = orders.All(order => order.OrderDate.Year == 2018);
            WriteLine($"Are All Orders Placed On 2018?: {areAllOrdersPlacedOn2018}");
        }

        private static void RangeDemo()
        {
            var oneToTen = Enumerable.Range(1, 10);
            WriteLine($"One to Ten => {string.Join(",", oneToTen)}");
            var randomRange = Enumerable.Range(999, 3);
            WriteLine($"Three numbers from 999 => {string.Join(",", randomRange)}");
        }

        private static void RepeatDemo()
        {
            var texts = Enumerable.Repeat("I love your smile", 5);
            foreach (var text in texts)
            {
                WriteLine(text);
            }
        }

        private static void EmptyDemo()
        {
            var emptyOrders = Enumerable.Empty<Order>();
            PrintHeaderFooter("This prints no order since the sequence is empty", () => PrintOrders(emptyOrders), indentBy);
        }

        private static void TakeDemo(List<Order> orders)
        {
            var firstTwoOrders1 = orders.Take(2);
            PrintHeaderFooter("First Two Orders - Take", () => PrintOrders(firstTwoOrders1, indentBy), indentBy);

            var firstTwoOrders2 = orders.TakeWhile((order, index) => index <= 1);
            PrintHeaderFooter("First Two Orders - TakeWhile", () => PrintOrders(firstTwoOrders2, indentBy), indentBy);
        }

        private static void SkipDemo(List<Order> orders)
        {
            var lastTwoOrders1 = orders.Skip(orders.Count - 2);
            PrintHeaderFooter("Last Two Orders - Skip", () => PrintOrders(lastTwoOrders1, indentBy), indentBy);

            var lastTwoOrders2 = orders.SkipWhile((order, index) => index < orders.Count - 2);
            PrintHeaderFooter("Last Two Orders - SkipWhile", () => PrintOrders(lastTwoOrders2, indentBy), indentBy);
        }

        private static void DefaultIfEmptyDemo(List<Order> orders)
        {
            var ordersAfterSeptember = orders.Where(order => order.OrderDate >= september).DefaultIfEmpty(NullOrder);
            PrintOrders(ordersAfterSeptember);
        }

        private static void LastDemo(List<Order> orders)
        {
            var lastOrderAfterMarch = orders.Last(order => order.OrderDate >= march);
            PrintHeaderFooter("Last order after March", () => PrintOrder(lastOrderAfterMarch, indentBy), indentBy);

            var LastOrderAfterSeptember = orders.LastOrDefault(order => order.OrderDate >= september);
            PrintHeaderFooter("Last or Default order after September", () => PrintOrder(LastOrderAfterSeptember, indentBy), indentBy);
        }

        private static void FirstDemo(List<Order> orders)
        {
            var firstOrderAfterMarch = orders.First(order => order.OrderDate >= march);
            PrintHeaderFooter("First order after March", () => PrintOrder(firstOrderAfterMarch, indentBy), indentBy);

            var firstOrderAfterSeptember = orders.FirstOrDefault(order => order.OrderDate >= september);
            PrintHeaderFooter("First or Default order after September", () => PrintOrder(firstOrderAfterSeptember, indentBy), indentBy);
        }

        private static void CountDemo(List<Order> orders)
        {
            var ordersOnAndAfterMarch = orders.Where(order => order.OrderDate >= march);
            PrintOrders(ordersOnAndAfterMarch, indentBy: indentBy);
            var orderCountPlacedOnAndAfterMarch = orders.Count(order => order.OrderDate >= march);
            WriteLine($"Total Orders Placed On and After March: {orderCountPlacedOnAndAfterMarch}");
        }

        private static void AverageDemo(List<Order> orders)
        {
            var averageQuantity = orders.Average(order => order.Quantity);
            var totalQuantities = orders.Sum(order => order.Quantity);
            var count = orders.Count();
            WriteLine($"Average Quantity: {totalQuantities} / {count} = {averageQuantity}");
        }

        private static void SumDemo(List<Order> orders)
        {
            var totalQuantities = orders.Sum(order => order.Quantity);
            WriteLine($"SumDemo - Total Quantities: {totalQuantities}");
        }

        private static void ExceptDemo(List<Order> ordersOnHold, List<Order> domesticOrders, List<Order> internationalOrders)
        {
            var allOrders = domesticOrders.Union(internationalOrders);
            var allOrdersNotOnHold = allOrders.Except(ordersOnHold, new OrderEqualityCompaprer());
            PrintOrders(allOrdersNotOnHold);
        }

        private static void IntersectDemo(List<Order> ordersOnHold, List<Order> domesticOrders, List<Order> internationalOrders)
        {
            var orderComparer = new OrderEqualityCompaprer();
            var usOrdersOnHold = ordersOnHold.Intersect(domesticOrders, orderComparer);
            var internationalOrdersOnHold = ordersOnHold.Intersect(internationalOrders, orderComparer);

            const char dividerCharacter = '*';
            PrintHeaderFooter("US Orders on hold", () => PrintOrders(usOrdersOnHold, indentBy), indentBy, dividerCharacter);
            PrintHeaderFooter("International Orders on hold", () => PrintOrders(internationalOrdersOnHold, indentBy), indentBy, dividerCharacter);
        }

        private static void UnionDemo(List<Order> domesticOrders, List<Order> internationalOrders)
        {
            var allOrders = domesticOrders.Union(internationalOrders);
            PrintOrders(allOrders);
        }

        private static void MinMaxDemo(List<Order> orders)
        {
            var minimumQuantity = orders.Min(order => order.Quantity);
            var maximumQuantity = orders.Max(order => order.Quantity);
            WriteLine($"Minimum Quantity: {minimumQuantity}");
            WriteLine($"Maximum Quantity: {maximumQuantity}");
        }

        private static void ZipDemo(List<Order> orders)
        {
            var orderNumbersInText = new[] { "One", "Two", "Three", "Four", "Five" };
            orders
                .Zip(orderNumbersInText, (order, text) => $"Quantity of Order {text}: {order.Quantity}")
                .ToList()
                .ForEach(sentence => WriteLine(sentence));
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

            PrintHeaderFooter("Reversing from this list", () => PrintOrders(combinedOrders, indentBy), indentBy, '*');

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
            orders.ToList().ForEach(order => PrintOrder(order, indentBy));
        }

        private static void PrintOrder(Order order, int indentBy = 0)
        {
            var indentation = new string(' ', indentBy);
            WriteLine($"{indentation}{order ?? (object)"<NULL>"}");
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
