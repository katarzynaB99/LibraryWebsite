using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.EditBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;
using AtosLibrary.Presentation.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost.Pages
{
    public class EditBookModel : PageModel
    {
        private readonly IBookPresentationRepository _presentationRepository;
        private readonly ICommandHandler<EditBookCommand> _commandHandler;

        [BindProperty] public BookModel BookModel { get; set; }

        public EditBookModel(IBookPresentationRepository presentationRepository, ICommandHandler<EditBookCommand> commandHandler)
        {
            _presentationRepository = presentationRepository;
            _commandHandler = commandHandler;
        }
        public void OnGet(int id)
        {
            BookModel = _presentationRepository.Get(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _commandHandler.Handle(new EditBookCommand(BookModel.Id,
                                                        BookModel.Name,
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