using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiHW_8._08._22.Repository.Models;

[Table("User", Schema = "Users")]
public class User : BaseEntity
{
    public string Comment { get; set; }
    //public string Name { get; set; }
    //public int Id { get; set; }
    //public bool IsDeleted { get; set; }
}

