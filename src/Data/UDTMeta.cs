using restlessmedia.Module.Data.Sql;

namespace restlessmedia.Module.Meta.Data
{
  public class UDTMeta : UDTBase
  {
    public UDTMeta(int id, object value)
    {
      Id = id;
      Value = value != null ? value.ToString() : null;
    }

    [MetaData("Id", System.Data.SqlDbType.Int)]
    public int Id
    {
      get
      {
        return DataRecord.GetInt32(0);
      }
      set
      {
        DataRecord.SetValue(0, value);
      }
    }

    [MetaData("Value", System.Data.SqlDbType.VarChar)]
    public string Value
    {
      get
      {
        return DataRecord.GetString(1);
      }
      set
      {
        DataRecord.SetValue(1, value);
      }
    }

    public const string TypeName = "UDTMeta";
  }
}