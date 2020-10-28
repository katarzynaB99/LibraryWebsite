using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Presentation.Book;
using AtosLibrary.Presentation.Reader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost.Pages
{
    public class ViewBookModel : PageModel
    {
        private readonly IBookPresentationRepository _presentationRepository;

        [BindProperty]
        public BookModel BookModel { get; set; }

        public ViewBookModel(IBookPresentationRepository presentationRepository)
        {
            _presentationRepository = presentationRepository;
        }

        public void OnGet(int id)
        {
            BookModel = _presentationRepository.Get(id);

        }

        public IActionResult OnPostEdit()
        {
            return RedirectToPage("/EditBook", new {BookModel.Id});

        }
    }
}