using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using WebApiHW_8._08._22.Interfaces;
using WebApiHW_8._08._22.Interfaces.Repository;
using WebApiHW_8._08._22.Interfaces.Service;
using WebApiHW_8._08._22.Interfaces.Validation;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Services.Validation;
/*
BRL-100 Неверно введены данные пользователя
BRL-100.1 Имя не должно быть пустым
BRL-100.2 Пароль не должен быть пустым
*/
public class UserValidationService :
    FluentValidationService<User>,
    IUserValidationService
{
    private readonly IUserRepository _repository;

    public UserValidationService(IUserRepository repository)
    {
        _repository = repository;

        Regex r = new Regex("^[a-zA-Z][A-Za-z0-9_.,-]*[@][a-z0-9._-]*[.][a-z]*", RegexOptions.Multiline);
        Regex pwd = new Regex("^[A-Za-z0-9]*", RegexOptions.Multiline);

        RuleFor(x => x.Name).NotEmpty()
            .WithMessage("Name Must be NOT empty!")
            .WithErrorCode("BRL-100.1");
        RuleFor(x => x.Password).NotEmpty()
            .WithMessage("Password Must be NOT empty!")
            .WithErrorCode("BRL-100.2");
        RuleFor(x => x.Name).Custom((s, context) =>
        {
            if (_repository.Find(s) is not null)
            {
                context.AddFailure(new ValidationFailure(nameof(User.Name), "Пользователь уже существует")
                {
                    ErrorCode = "BRL-100.4"
                });
            }
        });
        RuleFor(x => x.Name).Matches(r)
            .WithMessage("must be e-mail adress")
            .WithErrorCode("BRL-100.3");
        RuleFor(x => x.Password).Matches(pwd)
            .WithMessage("Only Letters and numbers")
            .WithErrorCode("BLR-100.5");
    }
}
