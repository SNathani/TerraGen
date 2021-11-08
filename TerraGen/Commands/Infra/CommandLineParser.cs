using System;
using System.Linq;

namespace TerraGen.Commands
{
    public class CommandLineParser
    {
        public CommandLineParser(string[] args)
        {
            Arguments = args;
        }

        public string[] Arguments { get; init; }

        public Command Parse(Command definition)
        {
            var root = new RootCommand();
            Command current = root;
            Command defCurrent = definition;

            if (defCurrent.Name == root.Name)
            {
                root.Handler = defCurrent.Handler;
            }

            foreach (var item in Arguments)
            {
                var arg = item.Trim();

                if (IsOption(arg))
                {
                    var option = CreateCommandOption(arg);
                    var optionFound = defCurrent.Options.SingleOrDefault(f => f.Name.ToLower() == option.Name.ToLower());
                    if (optionFound != null)
                    {
                        option.DefaultValue = optionFound.DefaultValue;
                        current.Options.Add(option);
                    }
                    else
                    {
                        Error($"Invalid option - {option.Name}");
                        return null;
                    }
                }
                else if (IsCommand(arg))
                {
                    var commandFound = defCurrent.Commands.SingleOrDefault(f => f.Name.ToLower() == arg.ToLower());
                    if (commandFound != null)
                    {
                        var command = CreateCommand(commandFound, arg);
                        current.Commands.Add(command);
                        defCurrent = commandFound;
                        current = command;
                    }
                    else
                    {
                        Error($"Command not found - {arg}");
                        return null;
                    }
                }
            }

            return root;
        }

        private Command CreateCommand(Command defCommand, string arg)
        {
            var result = new Command(arg, defCommand.Description);
            result.Handler = defCommand.Handler;
            return result;
        }

        void Error(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }

        CommandOption CreateCommandOption(string arg)
        {
            var argNameValue = arg.Split(new char[] { ':', '=' }, 2);
            var result = new CommandOption(argNameValue[0].Trim('/', '-'));
            result.Value = argNameValue[1];
            return result;
        }

        bool IsCommand(string arg)
        {
            return !IsOption(arg);
        }

        bool IsOption(string arg)
        {
            return (arg.StartsWith("--") || arg.StartsWith('/') || arg.StartsWith("-"));
        }


    }
}
