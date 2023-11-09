namespace FluentConsole.Shared.Utilities;

public static class ConsoleTool {
    public static string PrintLogo() {
        const string logo = """
                            
                             ____    __                    ____    ___
                            /\  _`\ /\ \__                /\  _`\ /\_ \
                            \ \,\L\_\ \ ,_\    __     _ __\ \ \L\ \//\ \     ___      __
                             \/_\__ \\ \ \/  /'__`\  /\`'__\ \  _ <'\ \ \   / __`\  /'_ `\
                               /\ \L\ \ \ \_/\ \L\.\_\ \ \/ \ \ \L\ \\_\ \_/\ \L\ \/\ \L\ \
                               \ `\____\ \__\ \__/.\_\\ \_\  \ \____//\____\ \____/\ \____ \
                                \/_____/\/__/\/__/\/_/ \/_/   \/___/ \/____/\/___/  \/___L\ \
                                                                                      /\____/
                                                                                      \_/__/

                            """;
        Console.WriteLine(logo);
        return logo;
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