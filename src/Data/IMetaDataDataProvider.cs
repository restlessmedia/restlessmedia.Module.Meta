using restlessmedia.Module.Data;

namespace restlessmedia.Module.Meta.Data
{
  public interface IMetaDataDataProvider : IDataProvider
  {
    void Save(MetaEntity meta);

    void Save(MetaCollection list);

    void DeleteEntityMeta(int entityId);

    MetaCollection List(IEntity entity);
  }
}