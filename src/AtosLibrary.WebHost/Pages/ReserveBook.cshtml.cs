using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.ReserveBook;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Reader;
using AtosLibrary.Presentation.Record;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AtosLibrary.WebHost.Pages
{
    public class ReserveBookModel : PageModel
    {
        private readonly ICommandHandler<ReserveBookCommand> _commandHandler;

        [BindProperty]
        public RecordModel RecordModel { get; set; }

        public ReserveBookModel(ICommandHandler<ReserveBookCommand> commandHandler) => _commandHandler = commandHandler;

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

            _commandHandler.Handle(new ReserveBookCommand(RecordModel.ReaderName, RecordModel.ReaderSurname, RecordModel.BookName));
            return RedirectToPage("/ReservationsIndex");
        }
    }
}
