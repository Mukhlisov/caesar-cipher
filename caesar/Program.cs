using caesar.Actions;
using caesar.Models;
using Spectre.Console;

namespace caesar;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            var prompt = new SelectionPrompt<ApplicationActionBase>()
                .Title("[cyan]What would you like to do?[/]")
                .PageSize(AppSettings.Actions.Count)
                .AddChoices(AppSettings.Actions);
            var result = AnsiConsole
                .Prompt(prompt)
                .PerformAction();
            if (result == ActionResult.Exit)
                break;
        }
    }
}