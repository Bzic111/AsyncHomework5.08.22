using WebApiHW_8._08._22.Interfaces;

namespace WebApiHW_8._08._22.Repository.Models;

public class BaseEntity : IEntity<int>
{
    public string Name { get; set; }
    public int Id { get; set; }
    public bool IsDeleted { get; set; } = false;
}
