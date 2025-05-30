using System.Text;
using OOP2;
using OOP4_Reuse_OOP2;

Console.OutputEncoding = Encoding.UTF8;

FulltimeEmployee fe = new FulltimeEmployee();
fe.Id = 1;
fe.IdCard = "123456789";
fe.Name = "Trịnh Trần Phương Tuấn";
fe.Birthday = new DateTime(1990, 1, 1);

FulltimeEmployee fe2 = new FulltimeEmployee();
fe2.Id = 2;
fe2.IdCard = "987654321";
fe2.Name = "Trần Minh Hiếu";
fe2.Birthday = new DateTime(1999, 5, 5);

// Tạo danh sách nhân viên và thêm vào
List<FulltimeEmployee> employees = new List<FulltimeEmployee> { fe, fe2 };

foreach (var emp in employees)
{
    Console.WriteLine(emp);
    Console.WriteLine("==>AGE: " + emp.Tuoi());
}

int currentMonth = DateTime.Now.Month;
bool found = false;

foreach (var emp in employees)
{
    if (emp.Birthday.Month == currentMonth)
    {
        Console.WriteLine($"Tháng này là sinh nhật của nhân viên: {emp.Name} (Ngày sinh: {emp.Birthday:dd/MM/yyyy})");
        Console.WriteLine("Chúc mừng sinh nhật! 🎉");
        found = true;
    }
}

if (!found)
{
    Console.WriteLine("Tháng này không phải sinh nhật của nhân viên nào.");
}
