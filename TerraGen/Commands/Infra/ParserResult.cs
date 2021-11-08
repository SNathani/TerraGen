using System.Collections.Generic;

namespace TerraGen.Commands
{
    public class ParserResult
    {
        public bool IsValid { get; private set; }

        public List<string> Exceptions { get; private set; }

        public Command Command { get; private set; }

        public void Run()
        {

        }
    }
}
