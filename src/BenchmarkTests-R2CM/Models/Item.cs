namespace BenchmarkTests.Models;

public class Item1
{
    public string ID { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public IEnumerable<Item1> GetOrientations()
    {
        yield return new Item1 { ID = this.ID, Length = this.Length, Width = this.Width, Height = this.Height };
        yield return new Item1 { ID = this.ID, Length = this.Width, Width = this.Height, Height = this.Length };
        yield return new Item1 { ID = this.ID, Length = this.Height, Width = this.Length, Height = this.Width };
        yield return new Item1 { ID = this.ID, Length = this.Height, Width = this.Width, Height = this.Length };
        yield return new Item1 { ID = this.ID, Length = this.Width, Width = this.Length, Height = this.Height };
        yield return new Item1 { ID = this.ID, Length = this.Length, Width = this.Height, Height = this.Width };
    }
}

public class Item2
{
    public string ID { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int OriginalLength { get; set; }
    public int OriginalHeight { get; set; }
    public int OriginalWidth { get; set; }
    private int currentOrientation = 0;  
    public void Rotate()
    {
        this.currentOrientation++;
        if (this.currentOrientation > 5)
        {
            this.currentOrientation = 0;
        }
        
        switch (this.currentOrientation)
        {
            case 0:
                this.Length = this.OriginalLength;
                this.Width = this.OriginalWidth;
                this.Height = this.OriginalHeight;
                break;
            case 1:
                this.Length = this.OriginalWidth;
                this.Width = this.OriginalHeight;
                this.Height = this.OriginalLength;
                break;
            case 2:
                this.Length = this.OriginalHeight;
                this.Width = this.OriginalLength;
                this.Height = this.OriginalWidth;
                break;
            case 3:
                this.Length = this.OriginalHeight;
                this.Width = this.OriginalWidth;
                this.Height = this.OriginalLength;
                break;
            case 4:
                this.Length = this.OriginalWidth;
                this.Width = this.OriginalLength;
                this.Height = this.OriginalHeight;
                break;
            case 5:
                this.Length = this.OriginalLength;
                this.Width = this.OriginalHeight;
                this.Height = this.OriginalWidth;
                break;
        }
        
        
    }
}