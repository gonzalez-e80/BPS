﻿using BethanysPieShop.InventoryManagement.Domain.General;
using BethanysPieShop.InventoryManagement.Domain.ProductManagement;

PrintWelcome();

Product.ChangeStockThreshold(10); //this is using the class, changing the value for all of them
Product.StockThreshold = 10;

//Price samplePrice = new Price(10, Currency = Currency.Euro);
Price samplePrice = new Price() { ItemPrice = 10, Currency = Currency.Euro};

//Product p1 = new Product(1, "Sugar", "Lorem ipsum", samplePrice, UnitType.PerKg, 100);
//max amount in stock can't be set through a property!!
Product p1 = new Product(1) { Name = "Sugar", Description = "Lorem ipsum", Price = samplePrice, UnitType = UnitType.PerKg };
p1.IncreaseStock(10);
p1.Description = "Sample description";

//var p2 = new Product(2, "Cake decorations", "Lorem ipsum", samplePrice, UnitType.PerItem, 20);
//Product p3 = new(3, "Strawberry", "Lorem ipsum", samplePrice, UnitType.PerBox, 10);

var p2 = new Product(2, "Cake decorations", "Lorem ipsum", new Price() { ItemPrice = 8, Currency = Currency.Euro }, UnitType.PerItem, 20);
p2.Description = "Another description";

Product p3 = new(3, "Strawberry", "Lorem ipsum", new Price() { ItemPrice = 3, Currency = Currency.Euro }, UnitType.PerBox, 10);

Console.WriteLine("Application shutting down...");

Console.ReadLine();

#region Layout

static void PrintWelcome()
{

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"
    ()()()()()()   ____       _   _                       _       _____ _         _____ _                                        
    |\         |  |  _ \     | | | |                     ( )     |  __ (_)       / ____| |                                         ()()()()()()
    |.\. . . . |  | |_) | ___| |_| |__   __ _ _ __  _   _|/ ___  | |__) |  ___  | (___ | |__   ___  _ __                           |\         |
    \'.\       |  |  _ < / _ \ __| '_ \ / _` | '_ \| | | | / __| |  ___/ |/ _ \  \___ \| '_ \ / _ \| '_ \                          |.\. . . . |
     \.:\ . . .|  | |_) |  __/ |_| | | | (_| | | | | |_| | \__ \ | |   | |  __/  ____) | | | | (_) | |_) |                         \'.\       |
      \'o\     |  |____/ \___|\__|_| |_|\__,_|_| |_|\__, | |___/ |_|__ |_|\___| |_____/|_| |_|\___/| .__/                    _      \.:\ . . .|
       \.'\. . |  |_   _|                    | |     __/ |         |  \/  |                        | |                      | |      \'o\     |
        \'.\   |    | |  _ ____   _____ _ __ | |_ __|___/__ _   _  | \  / | __ _ _ __   __ _  __ _ |_|_ _ __ ___   ___ _ __ | |_      \.'\. . |
         \'`\ .|    | | | '_ \ \ / / _ \ '_ \| __/ _ \| '__| | | | | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '_ ` _ \ / _ \ '_ \| __|      \'.\   |
          \.'\ |   _| |_| | | \ V /  __/ | | | || (_) | |  | |_| | | |  | | (_| | | | | (_| | (_| |  __/ | | | | |  __/ | | | |_        \'`\ .|
           \__\|  |_____|_| |_|\_/ \___|_| |_|\__\___/|_|   \__, | |_|  |_|\__,_|_| |_|\__,_|\__, |\___|_| |_| |_|\___|_| |_|\__|        \.'\ |
                                                             __/ |                            __/ |                                       \__\|
                                                            |___/                            |___/                               
    ");

    Console.ResetColor();

    Console.WriteLine("Press enter key to start logging in!");

    //accepting enter here
    Console.ReadLine();

    Console.Clear();
}
#endregion