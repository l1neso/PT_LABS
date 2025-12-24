public class TextDocument : File
{
    public int PageCount { get; set; }
    public string Font { get; set; }
    public int FontSize { get; set; }

    public override string ToString()
    {
        return base.ToString() + $" | Страниц: {PageCount} | Шрифт: {Font}";
    }
}