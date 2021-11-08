namespace TerraGen.Commands
{
    public class CommandOption
    {
        public CommandOption(string name, string description = null)
        {
            Name = name;
            Description = description;
        }

        #region Properties 

        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string DefaultValue { get; set; }
        public bool IsRequired { get; set; }

        #endregion
    }
}
