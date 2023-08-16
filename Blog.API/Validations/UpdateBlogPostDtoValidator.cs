using Blog.API.DTOs;
using FluentValidation;

namespace Blog.API.Validations
{
    public class UpdateBlogPostDtoValidator : AbstractValidator<UpdateBlogPostDto>
    {
        public UpdateBlogPostDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();

            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
