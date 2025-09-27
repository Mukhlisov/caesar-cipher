namespace caesar.Alphabet;

public class RussianAlphabet : AlphabetBase
{
    protected override AlphabetBounds LowerCaseAlphabetBounds { get; }
    protected override AlphabetBounds UpperCaseAlphabetBounds { get; }

    public RussianAlphabet()
    {
        LowerCaseAlphabetBounds = new AlphabetBounds('а', 'я', BoundStatus.Lower);
        UpperCaseAlphabetBounds = new AlphabetBounds('А', 'Я', BoundStatus.Upper);
    }
}