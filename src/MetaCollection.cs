using System.Collections.Generic;

namespace restlessmedia.Module.Meta
{
  public class MetaCollection : ModelCollection<MetaEntity>
  {
    public MetaCollection()
      : this(0) { }

    public MetaCollection(int capacity)
      : base(capacity) { }

    public MetaCollection(IEnumerable<MetaEntity> collection)
      : base(collection) { }

    public MetaCollection(IEnumerable<MetaEntity> collection, int totalCount)
      : base(collection, totalCount) { }
  }
}