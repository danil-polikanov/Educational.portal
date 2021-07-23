using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainProject.BLL.Models.Validators
{
    public class LoginValidator:AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email указан не корректно").NotEmpty();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Email указан не корректно");
        }
    }
}
