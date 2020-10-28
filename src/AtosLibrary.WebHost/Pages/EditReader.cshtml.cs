using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.EditReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost
{
    public class EditReaderModel : PageModel
    {
        private readonly IReaderPresentationRepository _presentationRepository;
        private readonly ICommandHandler<EditReaderCommand> _commandHandler;

        public EditReaderModel(IReaderPresentationRepository presentationRepository, ICommandHandler<EditReaderCommand> commandHandler)
        {
            _presentationRepository = presentationRepository;
            _commandHandler = commandHandler;
        }

        public void OnGet(int id)
        {
            ReaderModel = _presentationRepository.Get(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _commandHandler.Handle(new EditReaderCommand(ReaderModel.Id, 
                                                         ReaderModel.Name, 
                                                         ReaderModel.Surname, 
                                                         ReaderModel.Gender, 
                                                         ReaderModel.Birthday, 
                                                         ReaderModel.Email, 
                                                         ReaderModel.PhoneNumber, 
                                                         ReaderModel.Country, 
                                                         ReaderModel.City));

            return RedirectToPage("/ReaderIndex");
        }

        [BindProperty]
        public ReaderModel ReaderModel { get; set; }
    }
}