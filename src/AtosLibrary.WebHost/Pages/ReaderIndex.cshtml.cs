using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.DeleteReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost
{
    public class ReaderIndexModel : PageModel
    {
        private readonly IReaderPresentationRepository _presentationRepository;
        private readonly ICommandHandler<DeleteReaderCommand> _commandHandler;

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }
        public IList<ReaderModel> Readers { get; set; }

        public ReaderIndexModel(IReaderPresentationRepository presentationRepository, ICommandHandler<DeleteReaderCommand> commandHandler)
        {
            _presentationRepository = presentationRepository;
            _commandHandler = commandHandler;
        }

        
        public void OnGet()
        {
            Readers = SearchString is null ? _presentationRepository.GetList().ToList() : _presentationRepository.Search(SearchString).ToList();
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/ReaderIndex", new { SearchString });
        }

        public IActionResult OnPostDelete(int id)
        {
            _commandHandler.Handle(new DeleteReaderCommand(id));
            return RedirectToPage("/ReaderIndex");
        }
    }
}