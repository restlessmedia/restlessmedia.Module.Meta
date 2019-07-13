using restlessmedia.Module.Data;

namespace restlessmedia.Module.Meta.Data
{
  public class MetaDataDataProvider : MetaSqlDataProvider, IMetaDataDataProvider
  {
    public MetaDataDataProvider(IDataContext context)
      : base(context) { }
  }
}