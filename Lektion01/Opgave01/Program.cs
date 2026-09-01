using System.Text.Json;
using Opgave01.model;

namespace Opgave01;

class Program
{
    static void Main(string[] args)
    {
        // Opgave 1.1: Serialiser et enkelt Item-objekt til JSON
        Item item = GetItem();
        
        string jsonString = JsonSerializer.Serialize(item);
        Console.WriteLine(jsonString);


        // Opgave 1.2: Serialiser et Order-objekt til JSON med pæn formatering (WriteIndented)
        Order order = GetOrder();
       
        var options = new JsonSerializerOptions
        {
            WriteIndented = true // Gør JSON pæn og læsbar med indrykninger
        };

        string jsonString1 = JsonSerializer.Serialize(order, options);
        Console.WriteLine(jsonString1);


        // Opgave 1.3: Serialiser en liste af ordrer (List<Order>) til JSON
        List<Order> orders = GetOrders();

        string jsonString2 = JsonSerializer.Serialize(orders, options);
        Console.WriteLine(jsonString2);
    }

    public static Item GetItem()
    {
        return new Item("Kaffe", 25.50m);
    } 

    public static Order GetOrder()
    {
        return new Order(new List<OrderLine>
        {
            new OrderLine(new Item("Kaffe", 25.50m), 2),
            new OrderLine(new Item("Kanelsnegl", 18.00m), 3),
            new OrderLine(new Item("Juice", 22.00m), 1)
        });
    }

    public static List<Order> GetOrders()
    {
        return new List<Order>
        {
            new Order(new List<OrderLine>
            {
                new OrderLine(new Item("Espresso", 20.00m), 1),
                new OrderLine(new Item("Croissant", 15.00m), 2)
            }),
            new Order(new List<OrderLine>
            {
                new OrderLine(new Item("Sandwich", 45.00m), 2),
                new OrderLine(new Item("Sodavand", 25.00m), 2)
            })
        };
    }
}

