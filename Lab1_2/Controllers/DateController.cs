using System.Globalization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Lab_1.Controllers;

[ApiController]
[Route("Date")]
public class DateController : ControllerBase
{

    [HttpGet("Get")]
    public IActionResult Get([FromHeader] string languagce)
    {
        try
        {
            var acceptedLanguage = Request.Headers[HeaderNames.AcceptLanguage]; // en-US,en;q=0.9,es;q=0.8

            var AccLang = acceptedLanguage.ToString().Split(',')[0];

            //var spanish = "es-ES";
            //var french = "fr-FR";

            //curl - X 'GET' 'https://localhost:7160/Date/Get' - H "Accept-Language: es-ES"

            var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var culture = supportedCultures.FirstOrDefault(x => x.Name == languagce);
            

            if (culture is null)
            {
                throw new CultureNotFoundException("Language Not Supported");
            }

            return Ok(DateTime.Now.ToString("yyyy MMMM dd", culture));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}