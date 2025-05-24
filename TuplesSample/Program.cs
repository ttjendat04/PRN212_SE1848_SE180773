﻿using System.Windows.Markup;

(int, double) SumAndAverage (params int[] values)
{
    int sum = 0;
    double avg = 0;
    foreach (int value in values)
        sum += value;
    avg = sum*1.0/values.Length;
    return (sum, avg);

}
int[] values = new int[10];

void create_array (int[] values)
{
    Random rd = new Random();
    for(int i = 0; i < values.Length; i++)
    {
        values[i] = rd.Next(100);
    }   
}
void print_array(int[] values)
{
    foreach(int value in values)
        Console.WriteLine( $"{value}");
}

create_array(values);
print_array(values);
Console.WriteLine("\n Thông tin Sum + AVG: ");
(int sum, double avg) = SumAndAverage(values);
Console.WriteLine($"SUM = {sum}");   
Console.WriteLine($"AVG = {avg}");

