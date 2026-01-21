using System;
public class Generics
{
    // swap method . implimented by generic method concept
    public static void SwapMe<Genric>(ref  Genric a,ref Genric b)
    {
        Genric Temp = a;
        a = b;
        b = Temp;
    }

    static void Main(string[] args)
    {
        int a = 2;
        int b = 5;
        Console.WriteLine($"Value after swap a={a} and b={b}");
        SwapMe(ref a, ref b);
        Console.WriteLine($"Value after swap a={a} and b={b}");
    }
}