namespace restlessmedia.Module.Meta
{
  public interface IMetaService : IService
  {
    /// <summary>
    /// Saves meta data. If clear first is specified, the meta for this entity is cleared out first.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="list"></param>
    /// <param name="clearFirst"></param>
    void Save(IEntity entity, MetaCollection list, bool clearFirst = false);

    /// <summary>
    /// Saves meta (if the meta already exists for this entity and category type, it's updated)
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="entityGuid"></param>
    /// <param name="metaValue"></param>
    void Create(int categoryId, int entityGuid, object metaValue);

    /// <summary>
    /// Saves meta (if the meta already exists for this entity and category type, it's updated)
    /// </summary>
    /// <param name="meta"></param>
    void Save(MetaEntity meta);

    /// <summary>
    /// Saves meta (if the meta already exists for this entity and category type, it's updated)
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    void Save(MetaCollection list);

    /// <summary>
    /// Deletes meta for an entity
    /// </summary>
    /// <param name="entityId"></param>
    void DeleteEntityMeta(int entityId);

    /// <summary>
    /// Deletes meta for an entity
    /// </summary>
    /// <param name="entity"></param>
    void DeleteEntityMeta(IEntity entity);

    /// <summary>
    /// List meta
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    MetaCollection List(IEntity entity);
  }
}
