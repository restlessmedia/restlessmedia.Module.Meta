namespace restlessmedia.Module.Meta
{
  public class MetaModel
  {
    public MetaModel() { }

    public MetaModel(int categoryId)
    {
      CategoryId = categoryId;
    }

    public MetaModel(MetaEntity meta)
    {
      Title = meta.Title;
      CategoryId = meta.CategoryId;
      Value = meta.MetaValueAsString;
    }

    public int CategoryId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Value { get; set; }

    public int Rank { get; set; }

    public MetaEntity GetMeta()
    {
      MetaEntity meta = new MetaEntity();
      meta.Title = Title;
      meta.CategoryId = CategoryId;
      meta.MetaValue = Value;
      return meta;
    }
  }
}