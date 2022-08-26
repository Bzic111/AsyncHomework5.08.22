using FluentValidation;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Services.Validation;
public class UserValidationService:AbstractValidator<User>
{
    public UserValidationService()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name Must be NOT empty!");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password Must be NOT empty!");
    }
}