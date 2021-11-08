using System;
using System.Reflection;
using TerraGen.Commands;
using TerraGen.Extensions;

namespace TerraGen
{
    class Program
    {
        static void Main(string[] args)
        {

            //if (args.Length == 0)
            //{
            //    AppInfo();
            //    ShowHelp();
            //}

            ShowArgs(args);
            var rootCommand = InitializeCommands(args);
            rootCommand.Execute();
        }

        private static Command InitializeCommands(string[] args)
        {
            var definition = DefineCommands();
            var parser = new CommandLineParser(args);
            var result = parser.Parse(definition);


            return result;
        }


        private static void ShowArgs(string[] args)
        {
            args.ForEach(item => Console.WriteLine(item));
        }

        private static void ShowHelp()
        {
            var help = @"";
            Console.WriteLine(help);
        }

        private static void AppInfo()
        {
            var versionString = Assembly.GetEntryAssembly()
                   .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                   .InformationalVersion
                   .ToString();

            //Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            var exeName = ApplicationInfo.Name;

            Console.WriteLine($"{Seperator}");
            Console.WriteLine($"{exeName} v{versionString}");
            Console.WriteLine("Terraform script generator");
            Console.WriteLine($"{Seperator}");

        }

        static string Seperator { get; } = new string('-', 80);
    }
}
