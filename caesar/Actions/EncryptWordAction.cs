using System.Text;
using caesar.Alphabet;
using caesar.Models;
using Spectre.Console;

namespace caesar.Actions;

public class EncryptWordAction(string actionName) : ApplicationActionBase(actionName)
{
    public override ActionResult PerformAction()
    {
        base.PerformAction();
        var word = GetInput("Enter word to encrypt: ");
        try
        {
            var encryptedWord = Encrypt(word);
            PrintResult($"Caesar's encryption method returned: {encryptedWord}");
            return ActionResult.Success;
        }
        catch (ArgumentException)
        {
            return ActionResult.Failure;
        }
    }

    private static string Encrypt(string word)
    {
        var stringBuilder = new StringBuilder();
        foreach (var shiftedLetter in word.Select(ShiftLetter))
            stringBuilder.Append(shiftedLetter);
        return stringBuilder.ToString();
    }

    private static char ShiftLetter(char letter)
    {
        var ruAlphabetBounds = RussianAlphabet.GetBounds(letter);
        if (ruAlphabetBounds.Status is not BoundStatus.NotInBounds)
            return RussianAlphabet.GetShiftedLetter(letter, Shift, ruAlphabetBounds);

        var enAlphabetBounds = EnglishAlphabet.GetBounds(letter);
        if (enAlphabetBounds.Status is not BoundStatus.NotInBounds)
            return EnglishAlphabet.GetShiftedLetter(letter, Shift, enAlphabetBounds);
        throw new ArgumentException("Incorrect symbol");
    }
}