using Google.Cloud.Dialogflow.V2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace PlenoChatBot.DialogFlow.Controllers
{
	[ApiController, Route("[controller]")]
	public class ApiController : ControllerBase
	{
		private readonly ILogger<ApiController> _logger;
		public ApiController(ILogger<ApiController> logger) { _logger = logger; }

		[HttpGet]
		public ActionResult Index()
		{
			return Ok("Ok");
		}


		// POST dialogflow/testing
		/// <summary>
		/// This method receives the post request from dialog flow and binds the json to the value object.
		/// You then use the JsonResponse class to build a reponse to return for dialog flow.
		/// </summary>
		/// <returns>The Json of the JsonResponse object for dialog to use</returns>
		/// <param name="value">Value.</param>
		[HttpPost]
		public JsonResult Post([FromBody] WebhookRequest value)
		{
			var response = new WebhookResponse
			{
				FulfillmentText = "Estou consultando uma informação no banco de dados. A hora do servidor é -> " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff"),
				Source = "sample fullfillment api",
			};
			return new JsonResult(response);
		}
	}
}