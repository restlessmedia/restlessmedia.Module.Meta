using restlessmedia.Module.Data;

namespace restlessmedia.Module.Meta.Data
{
  internal class MetaDataDataProvider : MetaSqlDataProvider, IMetaDataDataProvider
  {
    public MetaDataDataProvider(IDataContext context)
      : base(context) { }
  }
}