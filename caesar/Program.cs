using caesar.Actions;
using caesar.Models;
using Spectre.Console;

namespace caesar;

class Program
{
    //enLower = abcdefghijklmnopqrstuvwxyz
    //enUpper = ABCDEFGHIJKLMNOPQRSTUVWXYZ
    //ruLower = абвгдеёжзийклмнопрстуфхцчшщъыьэюя
    //ruUpper = АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ 
    static void Main(string[] args)
    {
        PrintHeader();
        var exit = false;
        while (!exit)
        {
            var prompt = new SelectionPrompt<ApplicationActionBase>()
                .Title("[cyan]What would you like to do?[/]")
                .PageSize(AppSettings.Actions.Count)
                .AddChoices(AppSettings.Actions);
            var result = AnsiConsole
                .Prompt(prompt)
                .PerformAction();
            exit = HandleResult(result);
            AnsiConsole.Clear();
        }
    }

    private static bool HandleResult(ActionResult result)
    {
        if (result is ActionResult.Exit)
            return true;
        if (result is ActionResult.Failure)
        {
            AnsiConsole.Write(new Markup("[red]Possibly incorrect input[/]\n[gray]Press any key to continue...[/]"));
            Console.ReadKey();
        }
        return false;
    }

    private static void PrintHeader()
    {
        var figletText = new FigletText("Caesar's cipher")
            .Justify(Justify.Center)
            .Color(Color.Cyan1);
        AnsiConsole.Write(figletText);
    }
}