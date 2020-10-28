using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.PrepareBook;
using AtosLibrary.Application.Features.ReadyBook;
using AtosLibrary.Application.Features.RentBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Record;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AtosLibrary.WebHost.Pages
{
    public class ReservationsIndexModel : PageModel
    {
        private readonly IRecordPresentationRepository _presentationRepository;
        private readonly ICommandHandler<PrepareBookCommand> _prepareCommandHandler;
        private readonly ICommandHandler<ReadyBookCommand> _readyCommandHandler;
        private readonly ICommandHandler<RentBookCommand> _rentCommandHandler;

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public IList<RecordModel> Records { get; set; }

        public ReservationsIndexModel(IRecordPresentationRepository presentationRepository,
            ICommandHandler<PrepareBookCommand> prepareCommandHandler,
            ICommandHandler<ReadyBookCommand> readyCommandHandler,
            ICommandHandler<RentBookCommand> rentCommandHandler)
        {
            _presentationRepository = presentationRepository;
            _prepareCommandHandler = prepareCommandHandler;
            _readyCommandHandler = readyCommandHandler;
            _rentCommandHandler = rentCommandHandler;
        }

        public void OnGet()
        {
            try
            {
                Records = _presentationRepository.GetList()
                    .Where(x => x.Status == "New" || x.Status == "In preparation" || x.Status == "Ready").ToList();
            }
            catch (NullReferenceException exception)
            {
                //list empty
            }

            Records = SearchString is null
                ? _presentationRepository.GetList()
                    .Where(x => x.Status == "New" || x.Status == "In preparation" || x.Status == "Ready").ToList()
                : _presentationRepository.Search(SearchString)
                    .Where(x => x.Status == "New" || x.Status == "In preparation" || x.Status == "Ready").ToList();
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/ReservationsIndex", new {SearchString});
        }

        public IActionResult OnPostPrepare(int id)
        {
            _prepareCommandHandler.Handle(new PrepareBookCommand(id));
            return RedirectToPage("/ReservationsIndex");
        }

        public IActionResult OnPostReady(int id)
        {
            _readyCommandHandler.Handle(new ReadyBookCommand(id));
            return RedirectToPage("/ReservationsIndex");
        }

        public IActionResult OnPostRent(int id)
        {
            _rentCommandHandler.Handle(new RentBookCommand(id));
            return RedirectToPage("/ReservationsIndex");
        }
    }
}