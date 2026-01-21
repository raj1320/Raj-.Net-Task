using System;
public class GenericRepo<GenRepo>
{
    // list for generic type 
    public List<GenRepo> list = new List<GenRepo>();
    
    // insert method
    public void Insert(GenRepo content)
    {
        list.Add(content);
    }

    // delete method
    public void Delete(GenRepo content)
    {
        list.Remove(content);
    }
    
    // update method
    public void Update(GenRepo OldContent,GenRepo content)
    {
        int idx=list.IndexOf(OldContent);
        list[idx]= content;
    }
  
    // display method
    public void Display()
    {
        Console.WriteLine("=================");
        foreach (GenRepo item in list)
        {
            Console.WriteLine(item);
        }
    }
}


public class MyClass
{ 
     
    static void Main()
    {
        // object of the Generic repo class
        GenericRepo<string> repo = new GenericRepo<string>();

        //CRUD operation..
        repo.Insert("Raj");
        repo.Insert("Ravi");
        repo.Insert("Rakesh");
        repo.Insert("Yashraj");
        repo.Insert("Ram");
        repo.Insert("Meet");
        repo.Insert("Mit");
        
        repo.Display();

        repo.Update("Raj", "Rana Raj");

        repo.Display();

        repo.Delete("Ram");

        repo.Display();
    }


}

