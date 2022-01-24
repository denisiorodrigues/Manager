using FluentValidation;
using Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")
                
                .NotNull()
                .WithMessage("A entidde não pode ser nula");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo")
                
                .NotEmpty()
                .WithMessage("O Nome não pode ser vazio")
                
                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres")

                .MaximumLength(80)
                .WithMessage("O nome deve ter no máximo 80 caracteres");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O e-mail não pode ser nulo")

                .NotEmpty()
                .WithMessage("O e-mail não pode ser vazio")

                .MinimumLength(10)
                .WithMessage("O e-mail deve ter no mínimo 10 caracteres")

                .MaximumLength(180)
                .WithMessage("O e-mail deve ter no máximo 180 caracteres")
                
                .Matches("^[A-Z0-9._%+-]{1,64}@(?:[A-Z0-9-]{1,63}\\.){1,125}[A-Z]{2,63}$")
                .WithMessage("E-mail inválido pelo regex")
                
                .EmailAddress()
                .WithMessage("E-amil inválido pelo flunet validation");

            RuleFor(x => x.Password)
               .NotNull()
               .WithMessage("A senha não pode ser nula")

               .NotEmpty()
               .WithMessage("A senha não pode ser vazia")

               .MinimumLength(3)
               .WithMessage("A senha  deve ter no mínimo 3 caracteres")

               .MaximumLength(15)
               .WithMessage("A senha deve ter no máximo 80 caracteres");

        }
    }
}
