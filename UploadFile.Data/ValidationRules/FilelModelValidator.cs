using FluentValidation;
using UploadFile.Domain.Models;

namespace UploadFile.Data.ValidationRules
{
    public class FilelModelValidator : AbstractValidator<FileInfoModel>
    {
        public FilelModelValidator()
        {
            RuleFor(x => x.Name).Length(5, 50);
            RuleFor(x => x.LastModifiedDate).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Size).GreaterThan(0);
        }
    }
}
