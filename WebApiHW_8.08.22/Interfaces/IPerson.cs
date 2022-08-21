namespace WebApiHW_8._08._22.Interfaces;

public interface IPerson : IEntity<int>
{
    public string Name { get; set; }
}
