using System;
using System.IO;

public class ProductCounter
{
    private static ProductCounter instance = new ProductCounter();
    private int foodCount;
    private int medicineCount;
    private int clothingCount;
    private double totalSales;
    private StreamWriter logFile;

    private ProductCounter()
    {
        foodCount = 0;
        medicineCount = 0;
        clothingCount = 0;
        totalSales = 0;

        logFile = new StreamWriter("sales_log.txt");
    }

    public static ProductCounter Instance
    {
        get { return instance; }
    }

    public void SellProduct(ProductType type, double price)
    {
        switch (type)
        {
            case ProductType.Food:
                foodCount++;
                totalSales += price * 1.05; 
                break;
            case ProductType.Medicine:
                medicineCount++;
                totalSales += price * 1.1; 
                break;
            case ProductType.Clothing:
                clothingCount++;
                totalSales += price * 1.15; 
                break;
        }

        logFile.WriteLine($"[{DateTime.Now}] Sold a {type} product for ${price}");
    }

    public void ShowSalesSummary()
    {
        Console.WriteLine("Sales Summary:");
        Console.WriteLine($"Food: {foodCount} items");
        Console.WriteLine($"Medicine: {medicineCount} items");
        Console.WriteLine($"Clothing: {clothingCount} items");
        Console.WriteLine($"Total Sales: ${totalSales}");
    }

    public void CloseLogFile()
    {
        logFile.Close();
    }
}

public enum ProductType
{
    Food,
    Medicine,
    Clothing
}

class Program
{
    static void Main(string[] args)
    {
        ProductCounter counter = ProductCounter.Instance;

        counter.SellProduct(ProductType.Food, 10.0);
        counter.SellProduct(ProductType.Food, 30.0);
        counter.SellProduct(ProductType.Medicine, 20.0);
        counter.SellProduct(ProductType.Clothing, 30.0);

        counter.ShowSalesSummary();

        counter.CloseLogFile();
    }
}
