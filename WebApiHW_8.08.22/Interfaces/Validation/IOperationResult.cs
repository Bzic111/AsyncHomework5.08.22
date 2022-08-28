namespace WebApiHW_8._08._22.Interfaces.Validation;

public interface IOperationResult
{
    IReadOnlyList<IOperationFailure> Failures { get; }
    bool Succeed { get; }
}
