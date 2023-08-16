using Blog.API.DTOs;
using FluentValidation;

namespace Blog.API.Validations
{
    public class UpdateBlogPostDtoValidator : AbstractValidator<UpdateBlogPostDto>
    {
        public UpdateBlogPostDtoValidator()
        {
            RuleFor(x => x.Title).MinimumLength(3);

            RuleFor(x => x.Content).MinimumLength(5);
        }
    }
}
