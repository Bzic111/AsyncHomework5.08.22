using WebApiHW_8._08._22.Interfaces.Validation;

namespace WebApiHW_8._08._22.Services.Validation;

public sealed class OperationFailure : IOperationFailure
{
    public string PropertyName { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
}
