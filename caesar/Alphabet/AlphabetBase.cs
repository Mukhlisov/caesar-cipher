namespace caesar.Alphabet;

public class AlphabetBase
{
    protected virtual AlphabetBounds LowerCaseAlphabetBounds => throw new NotImplementedException();
    protected virtual AlphabetBounds UpperCaseAlphabetBounds => throw new NotImplementedException();
    public AlphabetBounds GetBounds(char letter)
    {
        if (letter >= LowerCaseAlphabetBounds.FirstLetter && letter <= LowerCaseAlphabetBounds.LastLetter)
            return LowerCaseAlphabetBounds;
        if (letter >= UpperCaseAlphabetBounds.FirstLetter && letter <= UpperCaseAlphabetBounds.LastLetter)
            return UpperCaseAlphabetBounds;
        return new AlphabetBounds('#', '#',  BoundStatus.NotInBounds);
    }
}