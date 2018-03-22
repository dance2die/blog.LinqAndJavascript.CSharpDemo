# C# source code for 
[the blog entry](https://www.slightedgecoder.com/2018/02/24/approximate-equivalent-linq-methods-javascript/)

## How to run the source code
### NOTE: Requires [.NET Core 2](https://www.microsoft.com/net/download/windows).
Clone the source code

```bash
git clone https://github.com/dance2die/blog.LinqAndJavascript.CSharpDemo.git
```

Go to the cloned directory
```bash
cd blog.LinqAndJavascript.CSharpDemo
```

Restore  nuget packages.
```bash
dotnet restore
```

Run the code
```bash
dotnet run
```

Result would look as shown below.
```bash
dance2die@LELOUCH c:\misc\sources\blog\blog.LinqAndJavascript.CSharpDemo
> dotnet run
====================  Select DEMO - Print Order Quantities  ====================
Quantity: 40
Quantity: 20
Quantity: 30
Quantity: 10
Quantity: 20
====================  Aggregate DEMO - Sum Quantities  ====================
Total Quantities: 120
====================  Where DEMO - Order with Quantity over 30  ====================
Order ID: 1, Quantity: 40, Order Date: 01 Jan 2018 01:01 AM pst
====================  OrderBy DEMO - Order by Quantities in Ascending Order  ====================
Order ID: 4, Quantity: 10, Order Date: 04 Apr 2018 04:04 AM pst
Order ID: 2, Quantity: 20, Order Date: 02 Feb 2018 02:02 AM pst
Order ID: 5, Quantity: 20, Order Date: 05 May 2018 05:05 AM pst
Order ID: 3, Quantity: 30, Order Date: 03 Mar 2018 03:03 AM pst
Order ID: 1, Quantity: 40, Order Date: 01 Jan 2018 01:01 AM pst
====================  OrderByDescending DEMO - Order by Quantities in Descending Order  ====================
Order ID: 1, Quantity: 40, Order Date: 01 Jan 2018 01:01 AM pst
Order ID: 3, Quantity: 30, Order Date: 03 Mar 2018 03:03 AM pst
Order ID: 2, Quantity: 20, Order Date: 02 Feb 2018 02:02 AM pst
Order ID: 5, Quantity: 20, Order Date: 05 May 2018 05:05 AM pst
Order ID: 4, Quantity: 10, Order Date: 04 Apr 2018 04:04 AM pst
====================  Any DEMO - Check if there are *any* orders with certain quantities  ====================
Are there orders with quantity great than and equal to 30? True
Are there orders ordered before 2018? False
Do we have more than 100 Orders? False
====================  Distinct DEMO - Get Distinct Order Quantities  ====================
Distinct Quantity: 40
Distinct Quantity: 20
Distinct Quantity: 30
Distinct Quantity: 10
====================  Concat DEMO - Concatenate the first and the last orders  ====================
Order ID: 1, Quantity: 40, Order Date: 01 Jan 2018 01:01 AM pst
Order ID: 5, Quantity: 20, Order Date: 05 May 2018 05:05 AM pst
====================  SelectMany DEMO - Concatenate the first and the last orders  ====================
Order ID: 1, Quantity: 40, Order Date: 01 Jan 2018 01:01 AM pst
Order ID: 5, Quantity: 20, Order Date: 05 May 2018 05:05 AM pst
====================  Reverse DEMO - Reverse elements  ====================
    ********************  Reversing from this list  ********************
    Order ID: 3, Quantity: 30, Order Date: 03 Mar 2018 03:03 AM pst
    Order ID: 4, Quantity: 10, Order Date: 04 Apr 2018 04:04 AM pst
    Order ID: 5, Quantity: 20, Order Date: 05 May 2018 05:05 AM pst
    Order ID: 1, Quantity: 40, Order Date: 01 Jan 2018 01:01 AM pst
    Order ID: 2, Quantity: 20, Order Date: 02 Feb 2018 02:02 AM pst
Order ID: 2, Quantity: 20, Order Date: 02 Feb 2018 02:02 AM pst
Order ID: 1, Quantity: 40, Order Date: 01 Jan 2018 01:01 AM pst
Order ID: 5, Quantity: 20, Order Date: 05 May 2018 05:05 AM pst
Order ID: 4, Quantity: 10, Order Date: 04 Apr 2018 04:04 AM pst
Order ID: 3, Quantity: 30, Order Date: 03 Mar 2018 03:03 AM pst
====================  Zip DEMO - Appending Order Numbers in Text  ====================
Quantity of Order One: 40
Quantity of Order Two: 20
Quantity of Order Three: 30
Quantity of Order Four: 10
Quantity of Order Five: 20
====================  Min/Max DEMO - Get Min and Max Order Quantities  ====================
Minimum Quantity: 10
Maximum Quantity: 40
====================  Union DEMO - Display Domestic & International Orders  ====================
Order ID: 1, Quantity: 40, Order Date: 01 Jan 2018 01:01 AM pst
Order ID: 11, Quantity: 20, Order Date: 02 Nov 2018 02:02 AM pst
Order ID: 111, Quantity: 450, Order Date: 01 Nov 2018 02:02 AM pst
Order ID: 1111, Quantity: 230, Order Date: 11 Nov 2018 02:02 AM pst
Order ID: 3, Quantity: 30, Order Date: 03 Mar 2018 03:03 AM pst
Order ID: 33, Quantity: 300, Order Date: 03 Mar 2018 03:03 AM pst
Order ID: 4, Quantity: 10, Order Date: 04 Apr 2018 04:04 AM pst
Order ID: 44, Quantity: 100, Order Date: 04 Apr 2018 04:04 AM pst
Order ID: 5, Quantity: 20, Order Date: 05 May 2018 05:05 AM pst
Order ID: 55, Quantity: 200, Order Date: 05 May 2018 05:05 AM pst
====================  Intersect (intersection) DEMO - Find All Orders on Hold  ====================
    ********************  US Orders on hold  ********************
    Order ID: 1, Quantity: 40, Order Date: 01 Jan 2018 01:01 AM pst
    ********************  International Orders on hold  ********************
    Order ID: 3, Quantity: 30, Order Date: 03 Mar 2018 03:03 AM pst
    Order ID: 4, Quantity: 10, Order Date: 04 Apr 2018 04:04 AM pst
    Order ID: 5, Quantity: 20, Order Date: 05 May 2018 05:05 AM pst
====================  Except (subtraction) DEMO - Get all orders NOT on hold  ====================
Order ID: 11, Quantity: 20, Order Date: 02 Nov 2018 02:02 AM pst
Order ID: 111, Quantity: 450, Order Date: 01 Nov 2018 02:02 AM pst
Order ID: 1111, Quantity: 230, Order Date: 11 Nov 2018 02:02 AM pst
Order ID: 33, Quantity: 300, Order Date: 03 Mar 2018 03:03 AM pst
Order ID: 44, Quantity: 100, Order Date: 04 Apr 2018 04:04 AM pst
Order ID: 55, Quantity: 200, Order Date: 05 May 2018 05:05 AM pst
```
