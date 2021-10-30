using Microsoft.AspNetCore.Mvc;
using WebApiConvertTemperature.Enties;

namespace WebApiConvertTemperature.Controllers
{
    [ApiController]
    [Route("api/v1/convertTemperature/")]
    public class ConvertController : Controller
    {
        [HttpPost]
        public ActionResult<dynamic> Convert(ConvertEntie _obj)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            switch (_obj.In + "|" + _obj.To)
            {
                case "celsius|fahrenheit":
                    return Ok(_obj.ValueConvert * 1.8 + 32);
                case "celsius|kelvin":
                    return Ok(_obj.ValueConvert + 273.15);

                case "fahrenheit|celsius":
                    return Ok((_obj.ValueConvert - 32) * 5 / 9);
                case "fahrenheit|kelvin":
                    return Ok((_obj.ValueConvert - 32) * 5 / 9 + 273.15);

                case "kelvin|celsius":
                    return Ok(_obj.ValueConvert - 273.15);
                case "kelvin|fahrenheit":
                    return Ok((_obj.ValueConvert - 273.15) * 9 / 5 + 32);
            }

            return NotFound();
        }

    }
}
