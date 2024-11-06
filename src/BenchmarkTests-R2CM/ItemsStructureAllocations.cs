using BenchmarkDotNet.Attributes;
using BenchmarkTests.Models;

namespace BenchmarkTests;

[MemoryDiagnoser]
public class ItemsStructureAllocations
{
    public ItemsStructureAllocations()
    {
        
    }

    [Params(1, 5, 10)]
    public int NoOfItems { get; set; }
    
    [Benchmark(Baseline = true)]
    public List<Item1> Item1Allocations()
    {
        var items = new List<Item1>();
        for (int i = 0; i < this.NoOfItems; i++)
        {
            items.Add(new Item1 { ID = i.ToString(), Length = i, Width = i, Height = i });
        }
        return items;
    }
    
    [Benchmark]
    public List<Item2> Item2Allocations()
    {
        var items = new List<Item2>();
        for (int i = 0; i < this.NoOfItems; i++)
        {
            items.Add(new Item2 { ID = i.ToString(), Length = i, Width = i, Height = i, OriginalLength = i, OriginalHeight = i, OriginalWidth = i });
        }
        return items;
    }
    
}