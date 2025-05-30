using System;
using System.Text;
using OOP2;

Console.OutputEncoding = Encoding.UTF8 ;

FulltimeEmployee obama = new FulltimeEmployee();
obama.Id = 1;
obama.IdCard = "123445";
obama.Name = "Barack Obama";
obama.Birthday = new DateTime(1961, 8, 4);
Console.WriteLine("Thong tin cua Obama:");
Console.WriteLine("ID= " + obama.Id);
Console.WriteLine("ID Card= " + obama.IdCard);
Console.WriteLine("Name= " + obama.Name);
Console.WriteLine("Birthday= " 
    + obama.Birthday.ToString("dd/MM/yyyy"));
Console.WriteLine("Salary= " + obama.calSalary());

Console.WriteLine("======================================================");
ParttimeEmployee trump = new ParttimeEmployee()
{ 
    Id = 2,
    IdCard = "9999",
    Name = "Donald Trump",
    Birthday = new DateTime(1946, 6, 14),
    WorkingHours = 2
};
Console.WriteLine("Thong tin cua Trump:");
Console.WriteLine("ID= " + trump.Id);
Console.WriteLine("ID Card= " + trump.IdCard);
Console.WriteLine("Name= " + trump.Name);
Console.WriteLine("Birthday= "
    + trump.Birthday.ToString("dd/MM/yyyy"));
Console.WriteLine("Salary= " + trump.calSalary());

Console.WriteLine("========================Staff's Information in the way 2==============================");
Console.WriteLine(obama);
Console.WriteLine(trump);

