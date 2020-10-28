using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Application.Features.EditReader;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost.Pages
{
    public class ViewReaderModel : PageModel
    {
        private readonly IReaderPresentationRepository _presentationRepository;
        [BindProperty] public ReaderModel ReaderModel { get; set; }

        public ViewReaderModel(IReaderPresentationRepository presentationRepository)
        {
            _presentationRepository = presentationRepository;
        }

        public void OnGet(int id)
        {
            ReaderModel = _presentationRepository.Get(id);
        }

        public IActionResult OnPostEdit()
        {
            return RedirectToPage("/EditReader", new { ReaderModel.Id });
        }
    }
}