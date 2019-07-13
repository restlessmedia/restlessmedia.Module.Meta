using System;

namespace restlessmedia.Module.Meta
{
  /// <summary>
  /// This doesn't register itself against TEntity.  Meta categories are stored in TCategory and the actual values are stored in TMeta - this way, entity handling is done via the category and TMeta.EntityGuid.
  /// </summary>
  public class MetaEntity : Entity
  {
    public MetaEntity() { }

    public MetaEntity(int categoryId, int entityGuid, object metaValue)
      : this()
    {
      CategoryId = categoryId;
      EntityGuid = entityGuid;
      MetaValue = metaValue;
    }

    public override EntityType EntityType
    {
      get
      {
        return EntityType.Meta;
      }
    }

    public override int? EntityId
    {
      get
      {
        return MetaId;
      }
    }

    public int? MetaId { get; set; }

    public int CategoryId { get; set; }

    public int? CategoryParentId { get; set; }

    public object MetaValue { get; set; }

    /// <summary>
    /// Returns the correctly formatted string representation of the meta value
    /// </summary>
    public string MetaValueAsString
    {
      get
      {
        object v = MetaValue;

        if (v != null)
        {
          switch (ValueType)
          {
            case MetaValueType.Boolean:
              TryParseBool(v, out bool valueAsBool);
              return valueAsBool.ToString();
            default:
              return v.ToString();
          }
        }
        else
        {
          return null;
        }
      }
    }

    public string Description { get; set; }

    public MetaValueType ValueType { get; set; }

    /// <summary>
    /// If the valuetype is a string, this routine will attempt to work out a complex value type and set it to the current object
    /// </summary>
    public void DiscoverType()
    {
      // don't bother if complex type (i.e non string) this means the type has already been discovered
      if (ValueType != MetaValueType.String)
      {
        return;
      }

      if (MetaValue != null)
      {
        string valueAsString = MetaValue.ToString();

        // dates
        if (DateTime.TryParse(valueAsString, out _))
        {
          ValueType = MetaValueType.DateTime;
          return;
        }

        // decimal
        if (decimal.TryParse(valueAsString, out _))
        {
          ValueType = MetaValueType.Decimal;
          return;
        }

        // numbers
        if (int.TryParse(valueAsString, out _))
        {
          ValueType = MetaValueType.Number;
          return;
        }

        // bool - try to parse first, then check for common bool value types (1,0,-1,yes,no etc)
        if (TryParseBool(valueAsString, out bool valueAsBool))
        {
          MetaValue = valueAsBool;
          ValueType = MetaValueType.Boolean;
          return;
        }
      }
    }

    private object ConvertValue(string value)
    {
      switch (ValueType)
      {
        case MetaValueType.Boolean:
          bool valueAsBool = false;

          if (!string.IsNullOrEmpty(value))
          {
            // if we can't parse the value, checking if it's a yes/no 0/1 combination
            if (!bool.TryParse(value, out valueAsBool))
            {
              switch (value.ToLower())
              {
                case "yes":
                case MetaValues.True:
                  valueAsBool = true;
                  break;
              }
            }
          }

          return valueAsBool;
        case MetaValueType.String:
          return value;
        case MetaValueType.Number:
          return Convert.ToInt32(value);
        case MetaValueType.Decimal:
          return Convert.ToDecimal(value);
        case MetaValueType.DateTime:
          return Convert.ToDateTime(value);
        default:
          throw new ApplicationException($"UnsupportedMetaTypeConversion {ValueType}");
      }
    }

    private bool TryParseBool(object value, out bool result)
    {
      result = false;

      if (value == null)
      {
        return false;
      }

      string valueAsString = value.ToString();

      if (!bool.TryParse(valueAsString, out result))
      {
        switch (valueAsString.ToLower())
        {
          case "true":
          case "yes":
          case MetaValues.True:
            result = true;
            return true;
          case "false":
          case "no":
          case "-1":
          case MetaValues.False:
            result = false;
            return true;
        }
      }

      return false;
    }
  }
}