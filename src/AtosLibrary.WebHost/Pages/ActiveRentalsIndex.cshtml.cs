using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.ReturnBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Record;
using AtosLibrary.Presentation.Record;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AtosLibrary.WebHost.Pages
{
    public class ActiveRentalsIndexModel : PageModel
    {
        private readonly IRecordPresentationRepository _presentationRepository;
        private readonly ICommandHandler<ReturnBookCommand> _commandHandler;

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public IList<RecordModel> Records { get; set; }

        public ActiveRentalsIndexModel(IRecordPresentationRepository presentationRepository,
            ICommandHandler<ReturnBookCommand> commandHandler)
        {
            _presentationRepository = presentationRepository;
            _commandHandler = commandHandler;
        }

        public void OnGet()
        {
            try
            {
                Records = _presentationRepository.GetList().Where(x => x.Status == "Rented")
                    .ToList();
            }
            catch (NullReferenceException exception)
            {
                //list empty
            }

            Records = SearchString is null
                ? _presentationRepository.GetList().Where(x => x.Status == "Rented").ToList()
                : _presentationRepository.Search(SearchString).Where(x => x.Status == "Rented")
                    .ToList();
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/ActiveRentalsIndex", new {SearchString});
        }

        public IActionResult OnPostReturn(int id)
        {
            _commandHandler.Handle(new ReturnBookCommand(id));
            return RedirectToPage("/ActiveRentalsIndex");
        }
    }
}