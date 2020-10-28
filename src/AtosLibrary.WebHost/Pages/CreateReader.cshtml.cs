using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.RegistrationReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost
{
    public class CreateReaderModel : PageModel
    {
        private readonly ICommandHandler<RegistrationReaderCommand> _commandHandler;

        public CreateReaderModel(ICommandHandler<RegistrationReaderCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ReaderModel ReaderModel { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _commandHandler.Handle(new RegistrationReaderCommand(ReaderModel.Name, 
                                                                ReaderModel.Surname,
                                                                ReaderModel.Gender, 
                                                                ReaderModel.Birthday,
                                                                ReaderModel.Email, 
                                                                ReaderModel.PhoneNumber, 
                                                                ReaderModel.Country, 
                                                                ReaderModel.City));

            return RedirectToPage("/ReaderIndex");
        }
    }
}