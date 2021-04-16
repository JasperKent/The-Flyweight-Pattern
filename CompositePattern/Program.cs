using CompositePattern.ToDo;
using System;
using VisitorPattern.Visitors;
using FlyweightPattern.Flyweight;

namespace CompositePattern
{
    class Program
    {
        static void Main()
        {
            ToDoFactory factory = new();

            CompositeItem items = new("DevelopSite","All the work for developing my website");

            CompositeItem devClientSide = new("DevelopClient", "All the work for developing the front end");
            CompositeItem devServerSide = new("DevelopServer", "All the work for developing the back end");

            items.Add(devClientSide);
            items.Add(devServerSide);

            devClientSide.Add(factory.WorkItem ("DesignGui", "Think about making it pretty", 10, 12));
            devClientSide.Add(factory.WorkItem("ProgramGui", "Do some Angular stuff", 20, 15));
            devClientSide.Add(factory.PurchaseItem("BuyCoffee", "Get a latte", 4.5m, "Fortnum and Mason"));
            devClientSide.Add(factory.CommunicationItem("CallNewYork", "Telephone Donald in the Big Apple", 0.5));
            devClientSide.Add(factory.PurchaseItem("BuyCoffee", "Get a latte", 4.5m, "Fortnum and Mason"));

            CompositeItem initialDevServerSide = new("DevelopServerFirstTry", "All the work for developing the back end");
            CompositeItem retryDevServerSide = new("DevelopServerSecondTry", "All the work for developing the back end again");

            devServerSide.Add(initialDevServerSide);
            devServerSide.Add(retryDevServerSide);

            initialDevServerSide.Add(factory.WorkItem("DesignApi", "Design the WebAPI service", 15, 15));
            initialDevServerSide.Add(factory.CommunicationItem("CallNewYork", "Telephone Donald in the Big Apple", 0.5)); initialDevServerSide.Add(factory.WorkItem("ProgramApi", "Program the WebAPI service", 35, 15));
            initialDevServerSide.Add(factory.PurchaseItem("BuyCoffee", "Get a latte", 4.5m, "Fortnum and Mason"));
            initialDevServerSide.Add(factory.PurchaseItem("BuyBook", "Buy a book on how to program WebAPI", 35m, "Waterstones"));

            retryDevServerSide.Add(factory.WorkItem("ReProgramApi", "Fix the WebAPI service", 20, 15));
            retryDevServerSide.Add(factory.PurchaseItem("BuyCoffee", "Get a latte", 4.5m, "Fortnum and Mason"));
            retryDevServerSide.Add(factory.CommunicationItem("CallNewYorkAgain", "Explain the delays to Donald", 2));
            retryDevServerSide.Add(factory.PurchaseItem("BuyNewServer", "Go and get some better hardware", 5600m, "Dell"));
            retryDevServerSide.Add(factory.WorkItem("ReProgramApi", "Fix the WebAPI service", 20, 15));

            items.Add(factory.PurchaseItem("Champagne", "A bottle of bubbly to celebrate", 35, "Fortnum and Mason"));

            ToStringVisitor tsv = new();

            items.Accept(tsv);

            Console.WriteLine(tsv);

            Console.WriteLine($"Total cost is {items.Cost:C}.");
            Console.WriteLine($"Total duration is {items.Hours} hours.");

            Console.WriteLine();

            IToDoItem found = items.Find("BuyNewServer");

            Console.WriteLine(found?.ToString() ?? "Not found");

            OverrunVisitor orv = new();

            items.Accept(orv);

            Console.WriteLine($"Overrun is {orv.Overrun} hours.");

            SupplierBreakdownVisitor sbv = new();

            items.Accept(sbv);

            Console.WriteLine(sbv);

            Console.WriteLine($"Total objects created: {factory.ObjectCount}.");
        }
    }
}
