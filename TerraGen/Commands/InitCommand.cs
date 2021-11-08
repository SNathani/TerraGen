using System;

namespace TerraGen.Commands
{



    public class InitCommand : Command
    {
        #region .ctor

        public InitCommand() : base("Init")
        {
            Description = $"Initializes {ApplicationInfo.Name}";
            AddAlias("init");

            Handler = OnExecute;
        }


        #endregion

        #region Handler Methods

        private void OnExecute(Command command)
        {
            Console.WriteLine($"Command {Name} Invoked ...");
        }

        #endregion
    }


}
