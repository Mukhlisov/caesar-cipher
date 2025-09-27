namespace caesar.Alphabet;

public class EnglishAlphabet : AlphabetBase
{
    protected override AlphabetBounds LowerCaseAlphabetBounds { get; }
    protected override AlphabetBounds UpperCaseAlphabetBounds { get; }

    public EnglishAlphabet()
    {
        LowerCaseAlphabetBounds = new AlphabetBounds('a', 'z', BoundStatus.Lower);
        UpperCaseAlphabetBounds = new AlphabetBounds('A', 'Z', BoundStatus.Upper);
    }
}