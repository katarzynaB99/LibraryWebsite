using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtosLibrary.Presentation.Record;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AtosLibrary.WebHost.Pages
{
    public class AllRecordsIndexModel : PageModel
    {
        private readonly IRecordPresentationRepository _presentationRepository;

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public IList<RecordModel> Records { get; set; }

        public AllRecordsIndexModel(IRecordPresentationRepository presentationRepository) =>
            _presentationRepository = presentationRepository;

        public void OnGet()
        {
            try
            {
                Records = _presentationRepository.GetList().ToList();
            }
            catch (NullReferenceException exception)
            {
                //list empty
            }

            Records = SearchString is null
                ? _presentationRepository.GetList().ToList()
                : _presentationRepository.Search(SearchString).ToList();
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/AllRecordsIndex", new {SearchString});
        }
    }
}