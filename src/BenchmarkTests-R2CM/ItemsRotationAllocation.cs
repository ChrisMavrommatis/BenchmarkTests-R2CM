using BenchmarkDotNet.Attributes;
using BenchmarkTests.Models;

namespace BenchmarkTests;

[MemoryDiagnoser]
public class ItemsRotationAllocation
{
    public ItemsRotationAllocation()
    {
    }

    [Params(1, 5, 10)] public int NoOfItems { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        this.Items1 = new List<Item1>();
        this.Items2 = new List<Item2>();

        for (int i = 0; i < this.NoOfItems; i++)
        {
            this.Items1.Add(new Item1 { ID = i.ToString(), Length = i, Width = i, Height = i });
            this.Items2.Add(new Item2
            {
                ID = i.ToString(), Length = i, Width = i, Height = i, OriginalLength = i, OriginalHeight = i,
                OriginalWidth = i
            });
        }
    }


    [GlobalCleanup]
    public void GlobalCleanup()
    {
        this.Items1 = null;
        this.Items2 = null;
    }

    public List<Item1> Items1 { get; set; }
    public List<Item2> Items2 { get; set; }

    [Benchmark(Baseline = true)]
    public int Item1Rotations()
    {
        var itemsAndOrientationsCount = 0;
        foreach (var item in this.Items1)
        {
            foreach (var orientation in item.GetOrientations())
            {
                itemsAndOrientationsCount++;
            }
        }

        return itemsAndOrientationsCount;
    }
    
    [Benchmark]
    public int Item2Rotations()
    {
        var itemsAndOrientationsCount = 0;
        foreach (var item in this.Items2)
        {
            item.Rotate();
            itemsAndOrientationsCount++;
        }

        return itemsAndOrientationsCount;
    }
}