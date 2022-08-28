
using WebApiHW_8._08._22.Interfaces.Validation;

namespace WebApiHW_8._08._22.Services.Validation
{
    public class OperationResult : IOperationResult
    {
        public IReadOnlyList<IOperationFailure> Failures { get; init; }// => throw new NotImplementedException();

        public bool Succeed { get; init; }// => throw new NotImplementedException();
    }
}
