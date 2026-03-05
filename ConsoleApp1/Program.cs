// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");
User u = new User()
{ 
    Id=1,
    Name="Me"
};

Console.WriteLine(u.Id.ToString());
Console.WriteLine(u.Name);