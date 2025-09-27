using caesar.Actions;
using Spectre.Console;

namespace caesar;

public static class AppSettings
{
    public const int CipherShift = 4;
    public static readonly List<ApplicationActionBase> Actions = new()
    {
        new EncryptWordAction($"{Emoji.Known.LockedWithKey} Encrypt the word"),
        new DecryptWordAction($"{Emoji.Known.Keyboard} Decrypt the word"),
        new BreakCipherAction($"{Emoji.Known.Hammer} Break the cipher"),
        new ApplicationActionBase($"{Emoji.Known.Door} Exit program")
    };

    public static class Bounds
    {
        public const char LeftEnLower = 'a';
        public const char RightEnLower = 'z';
        public const char LeftEnUpper = 'A';
        public const char RightEnUpper = 'Z';

        public const char LeftRuLower = 'а';
        public const char RightRuLower = 'я';
        public const  char LeftRuUpper = 'А';
        public const char RightRuUpper = 'Я';
    }
}