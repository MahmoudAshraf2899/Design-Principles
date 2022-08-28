using Encapsulate_With_Varies;

Pizza pizza = Pizza.Order(PizzaConstants.CheesePizza);
Console.WriteLine(pizza);

Console.ReadKey();


class Pizza
{
    public virtual string Title => $"{nameof(Pizza)}"; //it return Pizza as Text not class
    public virtual decimal Price => 10m;

    private static Pizza Create(string type)
    {
        Pizza pizza;

        if (type.Equals(PizzaConstants.CheesePizza))
        {
            pizza = new Cheese();
        }
        else if (type.Equals(PizzaConstants.MeatPizza))
        {
            pizza = new Meat();
        }
        else
        {
            pizza = new Chicken();
        }
        return pizza;
    }
    public static Pizza Order(string type)
    {
        Pizza pizza = Create(type);

        Prepare();
        Cook();
        Cut();

        return pizza;

    }


    private static void Prepare()
    {
        Console.Write("Preparing...");
        Thread.Sleep(500);
        Console.WriteLine("Completed");
    }
    private static void Cook()
    {
        Console.Write("Cooking...");
        Thread.Sleep(500);
        Console.WriteLine("Completed");
    }
    private static void Cut()
    {
        Console.Write("Cutting and Boxing...");
        Thread.Sleep(500);
        Console.WriteLine("Completed");
    }
    public override string ToString()
    {
        return $"\n{Title}" +
                $"\n\tPrice {Price.ToString("C")}";
    }

}

class Cheese : Pizza
{
    public override string Title => $"{base.Title} {nameof(Cheese)}"; //OutPut : Pizza Cheese

    public override decimal Price => base.Price + 3m;
}

class Chicken : Pizza
{
    public override string Title => $"{base.Title} {nameof(Chicken)}"; //OutPut : Pizza Chicken

    public override decimal Price => base.Price + 3m;
}

class Meat : Pizza
{
    public override string Title => $"{base.Title} {nameof(Meat)}"; //OutPut : Pizza Meat

    public override decimal Price => base.Price + 5m;
}