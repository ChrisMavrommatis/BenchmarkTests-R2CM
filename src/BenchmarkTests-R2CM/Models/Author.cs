namespace BenchmarkTests.Models;

public class Author
{
    public int ID { get; set; }
    public int Age { get; set; }
    public List<Article> Articles { get; set; }
}