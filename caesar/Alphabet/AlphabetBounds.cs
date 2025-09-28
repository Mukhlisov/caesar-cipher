namespace caesar.Alphabet;

public class AlphabetBounds
{
    public char FirstLetter { get; }
    public char LastLetter { get; }
    public BoundStatus Status { get; }

    public AlphabetBounds(char firstLetter, char lastLetter, BoundStatus status)
    {
        FirstLetter = firstLetter;
        LastLetter = lastLetter;
        Status = status;
    }
}