using System.Text;
using OOP1;

Console.OutputEncoding = Encoding.UTF8;
// Tạo đối tượng Category 1:
Category c1 = new Category();
c1.Id = 1;
c1.Name = "Nước mắm";
// XUất thông tin bằng cách gọi hàm:
c1.PrintInfo();

// Giả sử ta đổi giá trị trong ô nhớ đó:
c1.Name = "Nước mắm cá sấu";
Console.WriteLine("Sau khi tổi giá trị:");  
c1.PrintInfo();

// Sử dụng Employee

Console.WriteLine("----------EMPLOYEE----------");
Employee  e1 = new Employee();
e1.Id = 1; // Gọi setter property Id
e1.IdCard = "001"; // Gọi setter property IdCard
e1.Name = "Nguyễn Tống Khánh Vĩnh"; // Gọi setter property Name
e1.Email = "Vincuto@gmail.com"; // Gọi setter property Email
e1.Phone = "0987654321"; // Gọi setter property Phone
//Xuất thông tin
e1.PrintInfo();

Employee e2 = new Employee()
{
    Id = 2,
    IdCard = "001",
    Name = "Văn Quang Duy",
    Email = "DuyVQ@gmail.com",
    Phone = "0987654321"

};
Console.WriteLine("----------EMPLOYEE 2----------");
e2.PrintInfo();

Employee e3 = new Employee();
Console.WriteLine("---------EMPLOYEE 3-----------");
e3.PrintInfo();


Console.WriteLine("---------EMPLOYEE 4-----------");
Employee e4 = new Employee(4, "004", "Đạt", "Dat@gmail.com", "234343");
e4.PrintInfo();
Console.WriteLine("--------EMPLOYEE 4 CÁCH 2---------");
Console.WriteLine(e4);// Tự động gọi hàm ToString


Console.WriteLine("===========CUSTOMER 1============");
Customer cus1 = new Customer()
{
    Id = "CUS1",
    Name = "Nguyễn Minh Nhựt",
    Email = " Nhut@gmail.com",
    Phone = "035454545",
    Address = "Số 2 - Huỳnh Khương An - Gò Vấp",
};

cus1.PrintInfo();
cus1.Address = "Số 10 - Huỳnh Khương An - Gò Vấp";
Console.WriteLine("Customer sau khi thay đổi");
cus1.PrintInfo();



