using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.RegistrationBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Book;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost.Pages
{
    public class CreateBookModel : PageModel
    {
        private readonly ICommandHandler<RegistrationBookCommand> _commandHandler;

        [BindProperty] public BookModel BookModel { get; set; }

        public CreateBookModel(ICommandHandler<RegistrationBookCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _commandHandler.Handle(new RegistrationBookCommand(BookModel.Name, 
                                                                BookModel.Description,
                                                                BookModel.Number,
                                                                BookModel.Genre,
                                                                BookModel.Author,
                                                                BookModel.PageNumber,
                                                                BookModel.PublicationYear,
                                                                BookModel.Publisher));
            return RedirectToPage("/BookIndex");
        }
    }
}