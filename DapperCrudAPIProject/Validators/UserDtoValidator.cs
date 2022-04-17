using DapperCrudAPIProject.DataAccess.DTOs;
using DapperCrudAPIProject.DataAccess.Repositories;
using FluentValidation;

namespace DapperCrudAPIProject.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("İsim alanı boş olamaz");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Lütfen Geçerli Bir Email Giriniz.");
            RuleFor(x => x.Phone).NotNull().WithMessage("Telefon alanı boş olamaz");
            RuleFor(x => x.Password).NotNull().WithMessage("Şifre alanı boş olamaz");
        }
    }
}