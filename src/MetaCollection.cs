using System.Collections.Generic;
using System.Linq;

namespace restlessmedia.Module.Meta
{
  public class MetaCollection : ModelCollection<MetaEntity>
  {
    public MetaCollection()
      : this(0)
    { }

    public MetaCollection(int capacity)
      : base(capacity)
    { }

    public MetaCollection(IEnumerable<MetaEntity> collection)
      : base(collection)
    { }

    public MetaCollection(IEnumerable<MetaEntity> collection, int totalCount)
      : base(collection, totalCount)
    { }

    public int? GetCategoryId(int categoryParentId)
    {
      MetaEntity meta;
      return (meta = this.FirstOrDefault(x => x.CategoryParentId == categoryParentId)) != null ? meta.CategoryId : (int?)null;
    }

    public void SetCategoryId(int categoryParentId, int categoryId, object value = null)
    {
      MetaEntity meta;
      if ((meta = this.FirstOrDefault(x => x.CategoryParentId == categoryParentId)) != null)
      {
        meta.CategoryId = categoryId;
        meta.MetaValue = value;
      }
      else
      {
        Add(new MetaEntity() { CategoryParentId = categoryParentId, CategoryId = categoryId, MetaValue = value });
      }
    }
  }
}