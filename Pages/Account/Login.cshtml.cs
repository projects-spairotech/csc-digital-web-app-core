using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace csc_digital_web_app.Pages.Account
{
	public class LoginModel : PageModel
	{
		private readonly ILogger<LoginModel> _logger;
		public LoginModel(ILogger<LoginModel> logger)
		{
			_logger = logger;
		}
		public void OnGet()
		{
		}
	}
}
