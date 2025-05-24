using System.Text;
Console.OutputEncoding = System.Text.Encoding.UTF8;
string ho = "Trần";
string tenlot = "Tiến";
String ten = "Đạt";
string fullname = ho + " " + tenlot + " " + ten;
Console.WriteLine(fullname);

StringBuilder sb = new StringBuilder();
sb.Append(ho);
sb.Append(" ");
sb.Append(tenlot);
sb.Append(" ");
sb.Append(ten);
Console.WriteLine(sb.ToString());
