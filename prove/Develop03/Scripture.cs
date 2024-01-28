using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Scripture
{
    private string _reference;
    private string _text;
    private int _wordLength; 
    private List<Word> _words = new List<Word>();
    private List<string> _stringWords = new List<string>();
    private List<int> _rndList = new List<int>();

    public Scripture()
    {

    }
    public Scripture(Reference Reference, Word text)
    {
        
        _reference = Reference.GetDisplayText();
        _text = text.GetDisplayText();

        foreach (string i in _text.Split(' '))  //Creates a list out of the input text.
        {
            Word word = new Word(i);
            _words.Add(word);
        }
        StringBuilder trimedList = new StringBuilder($"{_reference}: ");

        foreach (Word i in _words) //Creates a readable string from Word.
        {
            _stringWords.Add(i.GetDisplayText());
            trimedList.Append(i.GetDisplayText());
            trimedList.Append(' ');
        }
        _text = $"{trimedList.ToString().Trim()}";
        _wordLength = _words.Count;


        for (int i = 0; i < _wordLength;i++) //CREATES A RANDOM LIST FROM THE LENGTH OF THE ORINAL SCRIPTURE. PREVENTS REPEAT WORDS BEING REMOVED.
        {
            _rndList.Add(i);
        }
        _rndList = _rndList.OrderBy(x=> Random.Shared.Next()).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random maxRND = new Random();
        int rndNumber = maxRND.Next(1, _wordLength/5);
        int wordsChanged = 0;
        for (int i = 0; i < _wordLength; i++)
        {
            if (_stringWords[_rndList[i]] != "_____")
            {
                _stringWords[_rndList[i]] = "_____";
                wordsChanged += 1;
            }
            if (wordsChanged == rndNumber)
            {
                break;
            }
        }
    }
    public string GetDisplayText()
    {
        string sendText = $"{_reference}:\n {string.Join(' ',_stringWords)}";
        return(sendText);
    }
}