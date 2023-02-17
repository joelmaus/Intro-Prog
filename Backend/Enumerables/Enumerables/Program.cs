// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

var sw = new Stopwatch();
sw.Start();
foreach (var t in GetNumbers())
{
    Console.WriteLine(t);
    if (t == 10) { break; }
}
sw.Stop();
Console.WriteLine($"That took about {sw.ElapsedMilliseconds} milliseconds");


static IEnumerable<int> GetNumbers()
{

    for (int t = 1; t < 101; t++)
    {
        Thread.Sleep(500);
        yield return t;
    }

}