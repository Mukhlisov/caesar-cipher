namespace caesar.Alphabet;

public class AlphabetBounds
{
    public char FirstLetter { get; set; }
    public char LastLetter { get; set; }
    public BoundStatus Status { get; set; }

    public AlphabetBounds(char firstLetter, char lastLetter, BoundStatus status)
    {
        FirstLetter = firstLetter;
        LastLetter = lastLetter;
        Status = status;
    }
}