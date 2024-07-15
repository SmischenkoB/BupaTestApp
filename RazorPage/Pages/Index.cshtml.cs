using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Services;

namespace RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MOTApiService _mOTApiService;
        public IndexModel(ILogger<IndexModel> logger, MOTApiService mOTApiService)
        {
            _logger = logger;
            _mOTApiService = mOTApiService;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            var response = _mOTApiService.GetVehicleData(Request.Form["CarRegistration"], Request.Form["SecurityKey"]).Result;
            ViewData["sentence"] = response.Make + "\n" +
                response.Model + "\n" +
                response.ExpireDate + "\n" +
                response.Colour + "\n" + 
                response.Mileage;
        }
    }
}
