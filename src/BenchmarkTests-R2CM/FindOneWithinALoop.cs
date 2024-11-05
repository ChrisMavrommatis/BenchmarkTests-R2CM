using BenchmarkDotNet.Attributes;
using BenchmarkTests.Models;

namespace BenchmarkTests;

[MemoryDiagnoser]
public class FindOneWithinALoop
{
    private readonly DataGenerator dataGenerator;

    public FindOneWithinALoop()
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
    public List<Article> Linq()
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
    public List<Article> Foreach()
    {
        var articles = new List<Article>();
        foreach (var author in this.Authors!)
        {
            foreach (var article in author.Articles)
            {
                if (article.WordCount > wordCountMin && article.WordCount <= wordCountMax)
                {
                    articles.Add(article);
                    break;
                }
            }
           
        }
        
        return articles;
    }
}

