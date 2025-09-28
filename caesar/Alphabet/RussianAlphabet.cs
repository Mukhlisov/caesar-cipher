namespace caesar.Alphabet;

public class RussianAlphabet : AlphabetBase
{
    protected override AlphabetBounds LowerCaseAlphabetBounds { get; }
    protected override AlphabetBounds UpperCaseAlphabetBounds { get; }
    private const int ShiftToZhLetter = 6; // Shift to the right from first letter
    private const int ShiftToYoLetter = 2; // Shift to the right from last letter

    public RussianAlphabet()
    {
        LowerCaseAlphabetBounds = new AlphabetBounds('а', 'я', BoundStatus.Lower);
        UpperCaseAlphabetBounds = new AlphabetBounds('А', 'Я', BoundStatus.Upper);
    }

    public override AlphabetBounds GetBounds(char letter) => letter switch
    {
        'ё' => LowerCaseAlphabetBounds,
        'Ё' => UpperCaseAlphabetBounds,
        _ => base.GetBounds(letter)
    };

    public override char GetShiftedLetter(char letter, int shift, AlphabetBounds bounds)
    {
        var yoLetter = GetYo(bounds);
        var (shifted, newShift) = ShiftIncludingYo(letter, shift, bounds, yoLetter);
        while (newShift >= 0)
            (shifted, newShift) = ShiftIncludingYo(bounds.FirstLetter, newShift, bounds, yoLetter);
        return (char)shifted;
    }

    private static (int shifted, int newShisft) ShiftIncludingYo(char letter, int shift, AlphabetBounds bounds,
        int yoLetter)
    {
        var zhLetter = bounds.FirstLetter + ShiftToZhLetter;
        int shifted;
        if (letter == yoLetter)
        {
            shifted = zhLetter + shift - 1;
            return (shifted, shifted - bounds.LastLetter - 1);
        }

        shifted = letter + shift;
        var newShift = shifted - bounds.LastLetter - 1;
        if (letter >= zhLetter)
            return (shifted, newShift);
        if (shifted == zhLetter)
            return (yoLetter, -1);
        if (shifted > zhLetter)
            return (shifted - 1, newShift - 1);
        return (shifted, -1);
    }

    private static int GetYo(AlphabetBounds bounds) => bounds.LastLetter + ShiftToYoLetter;
}