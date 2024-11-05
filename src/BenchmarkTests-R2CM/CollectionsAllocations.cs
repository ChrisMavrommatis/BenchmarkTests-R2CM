using BenchmarkDotNet.Attributes;
using BenchmarkTests.Models;

namespace BenchmarkTests;

[MemoryDiagnoser]
public class CollectionsAllocations
{
    private readonly DataGenerator dataGenerator;

    public CollectionsAllocations()
    {
        this.dataGenerator = new DataGenerator();
    }
    
    [Params(1, 5, 10)]
    public int NoOfAuthors { get; set; }
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        this.Authors = this.dataGenerator.AuthorFaker.Generate(this.NoOfAuthors).ToList();
    }
    
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        this.Authors = null;
    }

    public List<Author>? Authors { get; set; }
    private int wordCountMin = 1000;
    private int wordCountMax = 1500;
    
    [Benchmark(Baseline = true)]
    public List<Article> ListWithoutSize()
    {
        
        var articles = new List<Article>();
        foreach (var author in this.Authors!)
        {
            var article = author.Articles
                .FirstOrDefault(x => x.WordCount > wordCountMin && x.WordCount <= wordCountMax);
            if(article is not null)
            {
                articles.Add(article);
            }
        }
        
        return articles;
    } 
    
    [Benchmark]
    public List<Article> ListWithSize()
    {
        
        var articles = new List<Article>(this.Authors.Count);
        foreach (var author in this.Authors!)
        {
            var article = author.Articles
                .FirstOrDefault(x => x.WordCount > wordCountMin && x.WordCount <= wordCountMax);
            if(article is not null)
            {
                articles.Add(article);
            }
        }
        
        return articles;
    } 
    
    [Benchmark]
    public Article[] Array()
    {
        
        var articles = new Article[this.Authors.Count];
        var count = 0;
        foreach (var author in this.Authors!)
        {
            var article = author.Articles
                .FirstOrDefault(x => x.WordCount > wordCountMin && x.WordCount <= wordCountMax);
            if(article is not null)
            {
                articles[count] = article;
            }
            count++;
        }
        
        return articles;
    } 
}