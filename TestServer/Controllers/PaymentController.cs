using TestServer.Services.VNPAY;
using Microsoft.AspNetCore.Mvc;
using TestServer.Models.VNPAY;

namespace TestServer.Controllers
{
    public class PaymentController : Controller
{
	
	private readonly IVnPayService _vnPayService;
	public PaymentController(IVnPayService vnPayService)
	{
		
		_vnPayService = vnPayService;
	}
    [HttpPost]
	public IActionResult CreatePaymentUrlVnpay([FromForm] PaymentInformationModel model)
	{
		var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

		return Redirect(url);
	}
	[HttpGet]
    public IActionResult PaymentCallbackVnpay()
{
	var response = _vnPayService.PaymentExecute(Request.Query);

	return Json(response);
}


}

}