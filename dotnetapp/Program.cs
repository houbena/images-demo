using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using Utils;
using static System.Console;

public static class Program
{
    public static void Main(string[] args) 
    {
          var defaultMessage = "Hello from Berlin!";
          var bot = GetBot();
          var (message, withColor) = ParseArgs(args);
          var output = message == string.Empty ? $"    {defaultMessage}{bot}" : $"    {message}{bot}";

          if (withColor)
          {
              ConsoleUtils.PrintStringWithRandomColor(output);
          }
          else
          {
              WriteLine(output);
          }
          
          WriteLine("**Environment**");
          WriteLine($"Platform: .NET Core");
          WriteLine($"OS: {RuntimeInformation.OSDescription}");
          WriteLine();
          System.Threading.Thread.Sleep(36000000);
    }

    private static (string, bool) ParseArgs(string[] args)
    {
      var buffer = new StringBuilder();
      var withColor = false;
      foreach(var s in args)
      {
        if (s == "--with-color")
        {
          withColor = true;
          continue;
        }
        buffer.Append(" ");
        buffer.Append(s);
      }

      return (buffer.ToString(), withColor);
    }

    private static string GetBot() 
    {
            
            return @"
      __________________
                        \
                        \
                            ....
                            ....'
                            ....
                          ..........
                      .............'..'..
                  ................'..'.....
                .......'..........'..'..'....
                ........'..........'..'..'.....
              .'....'..'..........'..'.......'.
              .'..................'...   ......
              .  ......'.........         .....
              .                           ......
              ..    .            ..        ......
            ....       .                 .......
            ......  .......          ............
              ................  ......................
              ........................'................
            ......................'..'......    .......
          .........................'..'.....       .......
      ........    ..'.............'..'....      ..........
    ..'..'...      ...............'.......      ..........
    ...'......     ...... ..........  ......         .......
  ...........   .......              ........        ......
  .......        '...'.'.              '.'.'.'         ....
  .......       .....'..               ..'.....
    ..       ..........               ..'........
            ............               ..............
          .............               '..............
          ...........'..              .'.'............
        ...............              .'.'.............
        .............'..               ..'..'...........
        ...............                 .'..............
        .........                        ..............
          .....

  ";
    }
}
