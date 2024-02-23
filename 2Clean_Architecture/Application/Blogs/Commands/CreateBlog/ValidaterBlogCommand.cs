//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Blogs.Commands.CreateBlog
//{
//    public class ValidaterBlogCommand : AbstractValidator<CreateBlogCommand>
//    {
//        public ValidaterBlogCommand()
//        {
//            RuleFor(v => v.Name)
//                .NotEmpty().WithMessage("Name is required.");
//               // .MaximumLength(200).WithMessage("Name Must Not exceed 200 characters.");

//            RuleFor(v => v.Description)
//               .NotEmpty().WithMessage("Description is required.");

//            RuleFor(v => v.Author)
//               .NotEmpty().WithMessage("Author is required.");
//             //  .MaximumLength(20).WithMessage("Author Must Not exceed 20 characters.");
//        }
//    }
//}
