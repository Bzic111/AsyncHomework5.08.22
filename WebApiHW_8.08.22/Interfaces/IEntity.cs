using System.Xml;

namespace WebApiHW_8._08._22.Interfaces;

public interface IEntity<TUniqueId> where TUniqueId : struct
{
    public TUniqueId Id { get; set; }
    public bool IsDeleted { get; set; }
}
