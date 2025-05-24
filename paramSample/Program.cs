int sum( params int[]arr)
{
    int s = 0;
    foreach (int x in arr)
    
        s = s + x;
        return s;
    
}
int s0 = sum();
int s1 = sum(100);
int s2 = sum(100, 200);
int sn = sum(4, 5, 6, 100, 200, 34, 12, 13, 15, 456, 23);