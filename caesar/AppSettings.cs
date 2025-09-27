using caesar.Actions;
using Spectre.Console;

namespace caesar;

public static class AppSettings
{
    public const int CipherShift = 3;
    public static readonly List<ApplicationActionBase> Actions = new()
    {
        new EncryptWordAction($"Encrypt the word"),
        new DecryptWordAction($"Decrypt the word"),
        new BreakCipherAction($"Break the cipher"),
        new ApplicationActionBase($"Exit program")
    };
}