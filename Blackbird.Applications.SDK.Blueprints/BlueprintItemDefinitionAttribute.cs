namespace Blackbird.Applications.SDK.Blueprints
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class BlueprintItemDefinitionAttribute : Attribute
    {
        public string IconPath { get; }
        public string Description { get; }
        public string? DefaultCategory { get; set; }

        public BlueprintItemDefinitionAttribute(string iconPath, string description)
        {
            IconPath = iconPath;
            Description = description;
        }
    }
}
