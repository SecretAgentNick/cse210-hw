public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference() //Default Value of Scripture if nothing is added
    {
        _book = "Omni";
        _chapter = 1;
        _verse = 2;
        _endVerse = 3;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse  = startVerse;
        _endVerse = endVerse;

    }
    public string GetDisplayText()
    {
        string scriptureTitle = $"{_book} {_chapter}:{_verse}-{_endVerse}";
        return(scriptureTitle);
    }
}