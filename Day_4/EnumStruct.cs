using System;
using static Order;

// Order class
public class Order
{
    // Enum ...
    public  enum oderStatus
    {
        Shippping,
        Cancle,
        Hold,
        Delivered,
    }
    string productName;
	oderStatus productOrderStatus;

	public Order(string? productName)
	{
		this.productName = productName ?? "Tv";
		this.productOrderStatus = oderStatus.Shippping;
	}

	public oderStatus GetproductStatus()
	{
		return this.productOrderStatus;
	}

    public void SetproductStatus(oderStatus el)
    {
		this.productOrderStatus = el;

    }
}

// code of Coordinate struct
public struct Coordinate
{
    double coordinateX;
    double coordinateY;

    public Coordinate(double coordinateX,double coordinateY)
    {
        this.coordinateX = coordinateX;
        this.coordinateY = coordinateY;
    }

    public string CoordinatePrints()
    {
        return $"This is a Coordinate of yours {this.coordinateY}deg {this.coordinateY}deg";
    }
}
public class EnumStruct
{
	
	static void Main(string[] args)
	{
        // Order Enum code...
		Order newOrder = new Order("Music player");
		Console.WriteLine("Your Product Order Status is : "+newOrder.GetproductStatus());
        newOrder.SetproductStatus(oderStatus.Hold);
        Console.WriteLine("Your Product Order Status is : "+ newOrder.GetproductStatus());
        newOrder.SetproductStatus(oderStatus.Delivered);
        Console.WriteLine("Your Product Order Status is : "+ newOrder.GetproductStatus());

        // Coordinate Struct Code
        Coordinate coordinateOfMe = new Coordinate(122.222,145.544);
        string LocationPrints = coordinateOfMe.CoordinatePrints();
        Console.WriteLine(LocationPrints);
    }
}
