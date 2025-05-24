﻿using System.Text;

void first_degree_solution(double a, double b)
{
    if (a == 0 && b == 0)
    {
        // 0 + 0 = 0
       
        Console.WriteLine("Phương trình vô số nghiệm");
    }
    else if (a == 0 && b != 0)
    {
        // 0 + b = 0 (b != 0)
        Console.WriteLine("Phương trình vô nghiệm");
    }
    else
    {
        Console.WriteLine("X= {0}", -b / a);
    }
 }
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Giải phương trình bậc nhất ax + b = 0");
Console.WriteLine("Nhập hệ số a: ");
double a = double.Parse(Console.ReadLine());
Console.WriteLine("Nhập hệ số b: ");
double b = double.Parse(Console.ReadLine());

Console.WriteLine("{0}x + {1} = 0", a,b);
first_degree_solution(a, b);
Console.ReadLine();