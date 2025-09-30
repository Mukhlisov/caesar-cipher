namespace caesar.Alphabet;

public class AlphabetBase
{
    protected virtual AlphabetBounds LowerCaseAlphabetBounds => throw new NotImplementedException();
    protected virtual AlphabetBounds UpperCaseAlphabetBounds => throw new NotImplementedException();

    public virtual AlphabetBounds GetBounds(char letter)
    {
        if (letter >= LowerCaseAlphabetBounds.FirstLetter && letter <= LowerCaseAlphabetBounds.LastLetter)
            return LowerCaseAlphabetBounds;
        if (letter >= UpperCaseAlphabetBounds.FirstLetter && letter <= UpperCaseAlphabetBounds.LastLetter)
            return UpperCaseAlphabetBounds;
        return new AlphabetBounds('#', '#',  BoundStatus.NotInBounds);
    }

    public virtual char GetShiftedLetter(char letter, int shift, AlphabetBounds bounds)
    {
        var shifted = letter + shift;
        var newShift = shifted - bounds.LastLetter - 1;
        while (newShift >= 0)
        {
            shifted = bounds.FirstLetter + newShift;
            newShift = shifted - bounds.LastLetter - 1;
        }
        return (char)shifted;
    }
}