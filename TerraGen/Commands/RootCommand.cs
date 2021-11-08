using System.Reflection;

namespace TerraGen.Commands
{
    public class RootCommand : Command
    {
        #region .ctor
        public RootCommand() : base("root")
        {
            Name = Assembly.GetExecutingAssembly().GetName().Name;
        }

        #endregion


        #region Methods

        public void Initialize()
        {
            /*
             * terragen
             *  - operation         -   operation command to create API operation
             *      --url           -   Generate API operation from url
             *      --openapi-url   -   Generate API operations from OpenAPI specification
             */

        }
        #endregion
    }
}
