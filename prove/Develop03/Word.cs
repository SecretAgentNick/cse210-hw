public class Word
{
    private string _text;

    public Word()
    {
        _text = "2 Wherefore, in my days, I would that ye should know that I fought much with the sword to preserve my people, the Nephites, from falling into the hands of their enemies, the Lamanites. But behold, I of myself aam a wicked man, and I have not kept the statutes and the commandments of the Lord as I ought to have done. \n3 And it came to pass that two hundred and seventy and six years had passed away, and we had many seasons of peace; and we had many aseasons of serious war and bloodshed. Yea, and in fine, two hundred and eighty and two years had passed away, and I had kept these plates according to the bcommandments of my fathers; and I conferred them upon my son Amaron. And I make an end.";
    }
    public Word(string text)
    {
        _text = text;
    }
    public string GetDisplayText()
    {   
        string sendingText = _text;
        return(sendingText);
    }
}