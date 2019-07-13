using System.Linq;

namespace restlessmedia.Module.Meta
{
  public static class MetaCollectionExtensions
  {
    public static int? GetCategoryId(this MetaCollection metaCollection, int categoryParentId)
    {
      MetaEntity meta;
      return (meta = metaCollection.FirstOrDefault(x => x.CategoryParentId == categoryParentId)) != null ? meta.CategoryId : (int?)null;
    }

    public static void SetCategoryId(this MetaCollection metaCollection, int categoryParentId, int categoryId, object value = null)
    {
      MetaEntity meta;
      if ((meta = metaCollection.FirstOrDefault(x => x.CategoryParentId == categoryParentId)) != null)
      {
        meta.CategoryId = categoryId;
        meta.MetaValue = value;
      }
      else
      {
        metaCollection.Add(new MetaEntity() { CategoryParentId = categoryParentId, CategoryId = categoryId, MetaValue = value });
      }
    }
  }
}