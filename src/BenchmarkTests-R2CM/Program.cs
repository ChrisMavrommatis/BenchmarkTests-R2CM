﻿using BenchmarkDotNet.Running;

namespace BenchmarkTests;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<FindOneWithinALoop>();
        //BenchmarkRunner.Run<CollectionsAllocations>();
    }
}