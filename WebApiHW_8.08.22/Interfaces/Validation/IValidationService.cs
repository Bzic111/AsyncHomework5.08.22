namespace WebApiHW_8._08._22.Interfaces.Validation;

public interface IValidationService<TEntity> where TEntity : class
{
    IReadOnlyList<IOperationFailure> ValidateEntity(TEntity item);
}