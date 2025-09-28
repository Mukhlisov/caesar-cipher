namespace caesar.Alphabet.Extensions;

public static class RuAlphabetBoundsExtensions
{
    // Shifts from first letter in alphabet
    private const int ShiftToYoLowerLetter = 33;
    private const int ShiftToYoUpperLetter = -15;

    public static int GetYo(this AlphabetBounds bounds)
    {
        if (bounds.Status == BoundStatus.Lower)
            return bounds.FirstLetter + ShiftToYoLowerLetter;
        return bounds.FirstLetter + ShiftToYoUpperLetter;
    }
}