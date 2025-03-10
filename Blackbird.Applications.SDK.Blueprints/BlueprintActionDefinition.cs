namespace Blackbird.Applications.SDK.Blueprints
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BlueprintActionDefinitionAttribute : BaseBlueprintInvocableDefinitionAttribute<BlueprintAction>
    {
        public BlueprintActionDefinitionAttribute(BlueprintAction blueprintItem) : base(blueprintItem)
        {
        }
    }
}
