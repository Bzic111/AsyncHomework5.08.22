namespace WebApiHW_8._08._22.Interfaces;
public interface IOperationFailure
{
    string PropertyName { get; }
    string Description { get; }
    string Code { get; }
}
public interface IValidationService<TEntity> where TEntity : class
{
    IReadOnlyList<IOperationFailure> ValidateEntity(TEntity item);
}
