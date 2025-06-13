﻿using System.ComponentModel;
using System.Text;
using DemoLINQ2SQL;


Console.OutputEncoding = Encoding.UTF8;
//Khai báo chuỗi kết nối tới CSDL
string connectionString = @"server = DESKTOP-JLCFJCR\SQLEXPRESS;database=MyStore;uid=sa;pwd=12345 ";
MyStoreDataContext context = new MyStoreDataContext(connectionString);

// Câu 1: Truy vấn toàn bộ doanh mục 
var dsdm = context.Categories.ToList();
   Console.WriteLine("----Danh sách Danh mục----");
foreach (var d in dsdm )
    Console.WriteLine(d.CategoryID + "\t" + d.CategoryName);
// Câu 2: Lấy thông tin chi tiết dnah mục khi biết mã
int madm = 7;
Category cate = context.Categories
    .FirstOrDefault(c => c.CategoryID == madm);
if (cate == null)
{
    Console.WriteLine("Không tìm thấy danh mục có mã =" + madm);

}
else
{
    Console.WriteLine("Tìm thấy danh mục có mã = " + madm);
    Console.WriteLine(cate.CategoryID + "\t" + cate.CategoryName);
} 
 
// Câu 3: Dùng Querry Syntax để truy vấn toàn bộ sản phẩm
var dssp = from p in context.Products
           select p;
Console.WriteLine("----Danh sách Sản phẩm----");
foreach (var p in dssp)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}

// Câu 4: Dùng Querry Syntax và Annonymus type để lọc ra
// các sản phẩm nhưng chỉ lấy mã sản phẩm và đơn giá
// đồng thời sắp xếp giảm dần
var dssp4 = from p in context.Products
            orderby p.UnitPrice descending
            select new { p.ProductID, p.UnitPrice };
Console.WriteLine("----Danh sách Sản phẩm theo yêu cầu câu 4----");
foreach (var p in dssp4)
{
    Console.WriteLine(p.ProductID + "\t" + p.UnitPrice);
}    

// Câu 5: sửa câu 4 theo extension method (Method Syntax)

var dssp5 = context.Products
    .OrderByDescending(p => p.UnitPrice)
    .Select(p => new { p.ProductID, p.UnitPrice });

// Câu 6: Lọc ra top 3 sản phẩm có giá lớn nhất hệ thống

var dssptop3 = context.Products
    .OrderbyDescending(p => p.UnitPrice)
    .Take(3);
Console.WriteLine("----Top 3 sản phẩm có giá lớn nhất----");
foreach (var p in dssptop3)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}

// Câu 7 sửa tên danh mục khi biết mã

int madm_edit = 16;
Category cate_edit = context.Categories
    .FirstOrDefault(c => c.CategoryID == madm_edit);
if ( cate_edit != null)
{
    cate_edit.CategoryName = "Hàng Trôi Nổi";
    context.SubmitChanges(); // Xác nhận lưu thay đổi 
}

// Câu 8: Xóa danh mục khi biết mã

int madm_delete = 15;
Category cate_remove = context.Categories
    .FirstOrDefault(c => c.CategoryID == madm_delete);
if ( cate_remove != null)
{
    context.Categories.DeleteOnSubmit(cate_remove);
    context.SubmitChanges(); // Xác nhận lưu thay đổi
}

// Câu 9: Xóa các danh mục nếu không có bất kì sản phẩm nào
// lưu ý: là xóa cùng 1 lúc nhiều danh mục, mà các danh mục này
// không có chứa bất kỳ 1 sản phẩm nào

var dsdm_delete_emptyproduct = context.Categories
    .Where(c => c.Products.Count() == 0)
    .ToList();
context.Categories.DeleteAllOnSubmit(dsdm_delete_emptyproduct);
context.SubmitChanges(); // Xác nhận lưu thay đổi

// Câu 10: Thêm mới dnah mục

Category c_new = new Category();
c_new.CategoryName = "Hàng Lậu từ Trung Quốc";
context.Categories.InsertOnSubmit(c_new);
context.SubmitChanges();

// Câu 11: Thêm mới nhiều danh mục

List<Category> list = new List<Category>();
list.Add(new Category() { CategoryName = "Hàng Gai Dụng" });
list.Add(new Category() { CategoryName = "Hàng Điện Tử" });
list.Add(new Category() { CategoryName = "Hàng Phụ Kiện" });
context.Categories.InsertAllOnSubmit(list);
context.SubmitChanges(); // Xác nhận lưu thay đổi

