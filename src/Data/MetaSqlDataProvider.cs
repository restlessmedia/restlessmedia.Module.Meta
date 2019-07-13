using Dapper;
using System.Data;
using System.Linq;
using restlessmedia.Module.Data.Sql;
using restlessmedia.Module.Data;

namespace restlessmedia.Module.Meta.Data
{
  public class MetaSqlDataProvider : SqlDataProviderBase
  {
    public MetaSqlDataProvider(IDataContext context)
      : base(context)
    { }

    public void Save(MetaEntity meta)
    {
      Save(new MetaCollection { meta });
    }

    public void Save(MetaCollection list)
    {
      const string commandName = "dbo.SPSaveMeta";

      ExecuteWithTransaction((transaction) =>
      {
        foreach (MetaEntity meta in list)
        {
          DynamicParameters dynamicParameters = new DynamicParameters();
          dynamicParameters.Add("categoryId", meta.CategoryId);
          dynamicParameters.Add("entityId", meta.EntityId);
          dynamicParameters.Add("entityType", (int)meta.EntityType);
          dynamicParameters.Add("metaValue", meta.MetaValueAsString);
          dynamicParameters.Add("valueType", (int)meta.ValueType);
          meta.DiscoverType();
          meta.MetaId = transaction.Connection.Query<int?>(commandName, dynamicParameters, transaction: transaction, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
      });
    }

    public void DeleteEntityMeta(int entityId)
    {
      const string commandName = "dbo.SPDeleteEntityMeta";
      Execute(commandName, new { entityId });
    }

    public MetaCollection List(IEntity entity)
    {
      const string commandName = "dbo.SPListMeta";
      return new MetaCollection(Query<MetaEntity>(commandName, new { entityTypeValue = (int)entity.EntityType, entityId = entity.EntityId }));
    }
  }
}