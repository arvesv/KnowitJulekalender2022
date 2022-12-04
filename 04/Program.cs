// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


int sum = 0;

for (int i = 1; i < 10000000; i++)
{
    if (Util.Tool.IsMultiPalindriom(i))
    {
        sum += i;
    }


}

Console.WriteLine(sum);
