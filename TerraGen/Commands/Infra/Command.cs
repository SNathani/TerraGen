using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using TerraGen.Extensions;

namespace TerraGen.Commands
{

    public class Command
    {
        public Command(string name, string description = null)
        {
            Name = name;
            Description = description;
        }

        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }

        public List<CommandOption> Options { get; set; } = new List<CommandOption>();

        [JsonIgnore]
        public Action<Command> Handler { get; set; }

        public List<string> Aliases { get; init; } = new List<string>();

        public List<Command> Commands { get; init; } = new List<Command>();

        #endregion

        #region Methods

        public Command AddAlias(string aliasName)
        {
            if (Aliases.Contains(aliasName) == false)
            {
                Aliases.Add(aliasName);
            }
            return this;
        }

        public Command AddCommand(Command command)
        {
            var found = Commands.Any(f => f.Name.ToLower() == command.Name.ToLower());

            Debug.Assert(found == false, "Command already added");

            Commands.Add(command);
            return this;
        }

        public virtual void Execute()
        {
            Console.WriteLine($"Command {Name} Invoked ...");

            ShowOptions();

            if (Handler != null)
            {
                Handler(this);
            }
            foreach (var command in Commands)
            {
                command.Execute();
            }
        }

        void ShowOptions()
        {
            foreach (var option in Options)
            {
                Console.WriteLine($"{Name} - {option.Name} = {option.Value ?? option.DefaultValue}");
            }
        }

        #endregion
    }
}
