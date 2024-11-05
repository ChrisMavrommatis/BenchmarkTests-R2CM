using BenchmarkTests.Models;
using Bogus;

namespace BenchmarkTests;

public class DataGenerator
{
    public Faker<Models.Author> AuthorFaker { get; }
    
    public DataGenerator()
    {
        Randomizer.Seed = new Random(8675309);

        this.AuthorFaker = new Faker<Author>()
            .RuleFor(x => x.ID, x => x.IndexFaker + 1)
            .RuleFor(x => x.Age, x => x.Random.Number(20, 80))
            .RuleFor(x => x.Articles, x => new Faker<Article>()
                .RuleFor(article => article.ID, articleFaker => articleFaker.IndexFaker + 1)
                .RuleFor(article => article.WordCount, articleFaker => articleFaker.Random.Number(100, 2000))
                .RuleFor(article => article.Date, articleFaker => articleFaker.Date.Past())
                .Generate(10)
            );

    }
}