using FluentValidation;
using UploadFile.Data.Models;

namespace UploadFile.Data.ValidationRules
{
    public class FileModelValidator : AbstractValidator<FileInfoModel>
    {
        public FileModelValidator()
        {
            RuleFor(x => x.Name).Length(5, 50);
            RuleFor(x => x.LastModifiedDate).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Size).GreaterThan(0);
        }
    }
}