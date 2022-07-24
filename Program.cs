class AsciiImageConverter
{
    public static void Main(string[] args)
    {
        // Returns false if the input is invalid
        if (!ValidateInput(args))
            return;

        Console.WriteLine($"Converting file: '{args[0]}'");
    }

    private static bool ValidateInput(string[] args)
    {
        string message = string.Empty;

        if (args.Length < 1)
            message = "The file path is a required argument.";

        if (args.Length > 2)
            message = "Too many arguments provided.";

        if (string.IsNullOrEmpty(args[0]) || args[0].Any(x => Path.GetInvalidPathChars().Contains(x)))
            message = "The input image file path contains invalid characters.";

        if (!File.Exists(args[0]))
            message = "The input image does not exist.";

        if (string.IsNullOrEmpty(args[1]) && args[1].Any(x => Path.GetInvalidPathChars().Contains(x)))
            message = "The output image file path contains invalid characters.";

        if (!string.IsNullOrEmpty(message))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {message}");
            Console.ResetColor();
            return false;
        }

        return true;
    }
}