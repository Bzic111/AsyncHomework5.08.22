namespace WebApiHW_8._08._22.Interfaces.Validation;
public interface IOperationFailure
{
    string PropertyName { get; }
    string Description { get; }
    string Code { get; }
}
