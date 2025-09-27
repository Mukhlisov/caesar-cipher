using caesar.Models;
using Spectre.Console;

namespace caesar.Actions;

public class ApplicationActionBase
{
    public string ActionName { get; set; }

    public ApplicationActionBase(string actionName)
    {
        ActionName = actionName;
    }

    public virtual ActionResult PerformAction()
    {
        AnsiConsole.Write(new Rule($"[Cyan]{ActionName}[/]"));
        return ActionResult.Exit;
    }

    public override string ToString()
    {
        return ActionName;
    }
}