using restlessmedia.Module.Meta.Data;
using System;

namespace restlessmedia.Module.Meta
{
  internal class MetaService : IMetaService
  {
    public MetaService(IMetaDataDataProvider metaDataProvider)
    {
      _metaDataProvider = metaDataProvider ?? throw new ArgumentNullException(nameof(metaDataProvider));
    }

    public void Save(IEntity entity, MetaCollection list, bool clearFirst = false)
    {
      // Because of properties where we store a pointer to the category and whether it is on or off, we can only have one instance of a category stored against an entity.
      // If we don't reselect that category again, it won't come through and therefore not updated (if null or empty remove meta relation)
      // In other meta relationships, we store the category all the time, and it's only the value that changes

      // update the metadata in the entity to have the right entityid and entitytype
      // if the caller has just executed an insert, the meta data may not have the entityid set against it so bruteforce update
      foreach (MetaEntity meta in list)
      {
        meta.MetaId = entity.EntityId;
      }

      if (clearFirst)
      {
        DeleteEntityMeta(entity);
      }

      Save(list);
    }

    public void Create(int categoryId, int entityGuid, object metaValue)
    {
      Save(new MetaEntity(categoryId, entityGuid, metaValue));
    }

    public void Save(MetaEntity meta)
    {
      if (meta == null)
      {
        throw new ArgumentNullException(nameof(meta));
      }

      _metaDataProvider.Save(meta);
    }

    public void Save(MetaCollection list)
    {
      if (list == null)
      {
        throw new ArgumentNullException(nameof(list));
      }

      _metaDataProvider.Save(list);
    }

    public void DeleteEntityMeta(int entityId)
    {
      _metaDataProvider.DeleteEntityMeta(entityId);
    }

    public void DeleteEntityMeta(IEntity entity)
    {
      if(entity == null)
      {
        throw new ArgumentNullException(nameof(entity));
      }

      if (!entity.EntityId.HasValue)
      {
        throw new ArgumentException(nameof(entity), "entity.EntityId is null");
      }

      DeleteEntityMeta(entity.EntityId.Value);
    }

    public MetaCollection List(IEntity entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException(nameof(entity));
      }

      return _metaDataProvider.List(entity);
    }

    private readonly IMetaDataDataProvider _metaDataProvider;
  }
}