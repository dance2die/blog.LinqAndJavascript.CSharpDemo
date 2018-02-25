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
```
