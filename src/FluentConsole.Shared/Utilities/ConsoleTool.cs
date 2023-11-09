namespace FluentConsole.Shared.Utilities;

public static class ConsoleTool {
    public static void PrintLogo() {
        Console.WriteLine(
            """
            
             ____    __                    ____    ___
            /\  _`\ /\ \__                /\  _`\ /\_ \
            \ \,\L\_\ \ ,_\    __     _ __\ \ \L\ \//\ \     ___      __
             \/_\__ \\ \ \/  /'__`\  /\`'__\ \  _ <'\ \ \   / __`\  /'_ `\
               /\ \L\ \ \ \_/\ \L\.\_\ \ \/ \ \ \L\ \\_\ \_/\ \L\ \/\ \L\ \
               \ `\____\ \__\ \__/.\_\\ \_\  \ \____//\____\ \____/\ \____ \
                \/_____/\/__/\/__/\/_/ \/_/   \/___/ \/____/\/___/  \/___L\ \
                                                                      /\____/
                                                                      \_/__/

            """);
    }

    public static void PrintDivider() {
        Console.WriteLine("============================================================================");
    }

    public static void PrintTitle(string title) {
        PrintDivider();
        Console.WriteLine(title);
        PrintDivider();
    }
}