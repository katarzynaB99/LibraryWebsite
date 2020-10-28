using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.DeleteBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost.Pages
{
    public class BookIndexModel : PageModel
    {
        private readonly IBookPresentationRepository _presentationRepository;
        private readonly ICommandHandler<DeleteBookCommand> _commandHandler;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public BookIndexModel(IBookPresentationRepository presentationRepository, ICommandHandler<DeleteBookCommand> commandHandler)
        {
            _presentationRepository = presentationRepository;
            _commandHandler = commandHandler;
        }

        public IList<BookModel> Books { get; set; }

        public void OnGet()
        {
            try
            {
                Books = _presentationRepository.GetList().ToList();
            }
            catch (NullReferenceException exception)
            {
                //list empty
            }

            Books = SearchString is null 
                ? _presentationRepository.GetList().ToList() 
                : _presentationRepository.Search(SearchString).ToList();
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/BookIndex", new { SearchString });
        }

        public IActionResult OnPostDelete(int id)
        {
            _commandHandler.Handle(new DeleteBookCommand(id));
            return RedirectToPage("/BookIndex");
        }
    }
}