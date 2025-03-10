namespace Blackbird.Applications.SDK.Blueprints
{
    public class BaseBlueprintInvocableDefinitionAttribute<TBlueprintItem> : Attribute where TBlueprintItem : Enum
    {
        public TBlueprintItem BlueprintItem { get; }

        protected BaseBlueprintInvocableDefinitionAttribute(TBlueprintItem blueprintItem)
        {
            BlueprintItem = blueprintItem;
        }
    }
}
