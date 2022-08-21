using System.ComponentModel.DataAnnotations.Schema;
using WebApiHW_8._08._22.Interfaces;

namespace WebApiHW_8._08._22.Repository.Models;

[Table("User", Schema = "Users")]
class User : BaseEntity
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Comment { get; set; }
    public bool IsDeleted { get; set; }
}

