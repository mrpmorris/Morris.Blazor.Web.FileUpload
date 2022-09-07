using Microsoft.AspNetCore.Mvc;

namespace Morris.Blazor.Web.FileUpload.Server.Controllers;

public class TestController : ControllerBase
{
    [HttpPost]
    [Route("/api/test/upload")]
    public IActionResult Upload()
    {
        Console.WriteLine(Request.Form.Files.Count);
        //foreach(IFormFile file in Request.Form.Files)
        //{
        //    Console.WriteLine($"{file.Name} {file.Length}");
        //}
        return Ok();
    }
}
