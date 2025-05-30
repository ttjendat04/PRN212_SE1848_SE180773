/*
 * Sử dụng Generic List để quản lý nhân sự với đầy đủ
 * Tính năng CRUD
 * C -> CREATER --> TẠO MỚI DỮ LIỆU
 * R -> Read/Retrieve --> Xem, lọc, tìm kiếm, săp xếp, thống kê,...
 * U -> Update --> Cập nhật dữ liệu
 * D -> Delete --> Xóa dữ liệu
 */

// Câu 1:  Tạo 5 nhân viên, 3 nhân viên chính thức, 2 nhân viên thời vụ
// lưu vào Generic List;

using System.Text;
using OOP2;
using System.Text.Json;




List<Employee> employees = new List<Employee>();
FulltimeEmployee fe1 = new FulltimeEmployee
{
    Id = 1,
    IdCard = "123456789",
    Name = "Nguyễn Thanh Tùng",
    Birthday = new DateTime(1994, 7, 4)
};

employees.Add(fe1);
FulltimeEmployee fe2 = new FulltimeEmployee
{
    Id = 2,
    IdCard = "987654321",
    Name = "Trần Minh An",
    Birthday = new DateTime(1999, 5, 5)
};

employees.Add(fe2);
FulltimeEmployee fe3 = new FulltimeEmployee
{
    Id = 3,
    IdCard = "456789123",
    Name = "Nguyễn Văn Chế",
    Birthday = new DateTime(1995, 3, 15)
};
employees.Add(fe3);

ParttimeEmployee pe1 = new ParttimeEmployee()
{
    Id = 4,
    IdCard = "123456789",
    Name = "Lê Văn Bảo",
    Birthday = new DateTime(2001, 6, 10),
    WorkingHours = 5 // Số giờ làm việc
};
employees.Add(pe1);
ParttimeEmployee pe2 = new OOP2.ParttimeEmployee()
{
    Id = 4,
    IdCard = "321654987",
    Name = "Lê Thị Bích",
    Birthday = new DateTime(2000, 8, 20),
    WorkingHours = 3
};

employees.Add(pe2);
Console.OutputEncoding = Encoding.UTF8;
// Câu 2: R -> Xuất toàn bộ nhân sự:
Console.WriteLine("Câu 2: R -> Xuất toàn bộ nhân sự:");
// Cách 1:
employees.ForEach(e => Console.WriteLine(e));

// Câu 3: Lọc ra các nhan sự là chính thức
// cách 1:
List<FulltimeEmployee> fe_list =
    employees.OfType<FulltimeEmployee>().ToList();
Console.WriteLine("Câu 3: Lọc ra các nhan sự là chính thức:");
foreach (FulltimeEmployee fe in fe_list)
{
    Console.WriteLine(fe);
}

// Câu 4: Tính tổng tiền lương phải trả cho nhân viên chính thức:
double fe_sum_salary = fe_list.Sum(e => e.calSalary());
Console.WriteLine("Câu 4: Tính tổng tiền lương phải trả cho nhân viên chính thức: ");
Console.WriteLine(fe_sum_salary);

//Câu 5: Tính tổng tiền lương phải trả cho nhân viên thời vụ:
double pe_sum_salary = employees.OfType<ParttimeEmployee>()
    .Sum(e => e.calSalary());
Console.WriteLine("Câu 5: Tính tổng tiền lương phải trả cho nhân viên thời vụ: ");
Console.WriteLine(pe_sum_salary);

// Bổ sung thêm tính năng xóa sửa dữ liệu;
void UpdateEmployee(List<Employee> employees)
{
    Console.Write("Nhập Id nhân viên cần sửa: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var emp = employees.FirstOrDefault(e => e.Id == id);
        if (emp != null)
        {
            Console.Write("Nhập tên mới: ");
            emp.Name = Console.ReadLine();
            Console.Write("Nhập số CMND mới: ");
            emp.IdCard = Console.ReadLine();
            Console.Write("Nhập ngày sinh mới (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime birthday))
                emp.Birthday = birthday;

            if (emp is ParttimeEmployee pe)
            {
                Console.Write("Nhập số giờ làm việc mới: ");
                if (int.TryParse(Console.ReadLine(), out int hours))
                    pe.WorkingHours = hours;
            }
            Console.WriteLine("Đã cập nhật thông tin nhân viên.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy nhân viên.");
        }
    }
}

void DeleteEmployee(List<Employee> employees)
{
    Console.Write("Nhập Id nhân viên cần xóa: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var emp = employees.FirstOrDefault(e => e.Id == id);
        if (emp != null)
        {
            employees.Remove(emp);
            Console.WriteLine("Đã xóa nhân viên.");
        }
        else
        {
            Console.WriteLine("Không tìm thấy nhân viên.");
        }
    }
}

// Thêm menu vào cuối Main:
while (true)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Sửa thông tin nhân viên");
    Console.WriteLine("2. Xóa nhân viên");
    Console.WriteLine("0. Thoát");
    Console.Write("Chọn chức năng: ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            UpdateEmployee(employees);
            break;
        case "2":
            DeleteEmployee(employees);
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Lựa chọn không hợp lệ.");
            break;
            void SaveEmployees(List<Employee> employees, string filePath)
            {
                var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
                File.WriteAllText(filePath, JsonSerializer.Serialize(employees, options));
                List<Employee> LoadEmployees(string filePath)
                {
                    if (File.Exists(filePath))
                    {
                        var options = new JsonSerializerOptions { IncludeFields = true };
                        return JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(filePath), options) ?? new List<Employee>();
                    }
                    return new List<Employee>();
                }
            }
    }
}
