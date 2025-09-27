using caesar.Alphabet;
using caesar.Models;
using Spectre.Console;

namespace caesar.Actions;

public class ApplicationActionBase
{
    protected const int Shift = AppSettings.CipherShift;
    protected static readonly RussianAlphabet RussianAlphabet = new ();
    protected static readonly EnglishAlphabet EnglishAlphabet = new ();
    private string ActionName { get; set; }

    public ApplicationActionBase(string actionName)
    {
        ActionName = actionName;
    }

    public virtual ActionResult PerformAction()
    {
        AnsiConsole.Write(new Rule($"[Cyan]{ActionName}[/]"));
        return ActionResult.Exit;
    }

    protected static string GetInput(string message)
    {
        var prompt = new TextPrompt<string>(message)
            .Validate(input => string.IsNullOrEmpty(input) switch
            {
                true => ValidationResult.Error("The input is empty!"),
                false => ValidationResult.Success()
            });
        return AnsiConsole.Prompt(prompt);
    }

    protected static void PrintResult(string message)
    {
        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public override string ToString()
    {
        return ActionName;
    }
}