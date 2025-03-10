namespace Blackbird.Applications.SDK.Blueprints
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BlueprintEventDefinitionAttribute : BaseBlueprintInvocableDefinitionAttribute<BlueprintEvent>
    {
        public BlueprintEventDefinitionAttribute(BlueprintEvent blueprintItem) : base(blueprintItem)
        {
        }
    }
}
