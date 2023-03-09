using Microsoft.AspNetCore.Mvc;
using Poolit.Models.Requests;
using Poolit.Services.Interfaces;
using Poolit.Models.Responses;
using Poolit.Models;

namespace Poolit.Controllers;

[Route("[controller]")]
[ApiController]
public class FileController : Controller
{
    private readonly IFileService _fileService;
    private readonly ILogger<FileController> _logger;

    public FileController(IFileService fileService, ILogger<FileController> logger)
    {
        _fileService = fileService;
        _logger = logger;
    }

    /// <summary>
    /// File uploading
    /// </summary>
    /// <param name="file">File to upload.</param>
    /// <param name="id">User's id.</param>
    /// <returns>Url to file</returns>
    [Route("/upload")]
    [HttpPost]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response>> Upload(IFormFile file, ulong id)
    {
        try
        {
            string path = "./" + file.FileName;
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var dataEntry = new DataEntry<string>()
            {
                Data = path,
                Type = "string"
            };

            var response = new Response
            {
                Data = new DataEntry<string>[] { dataEntry }
            };
            return response;
        }
        catch (Exception e)
        {
            var response = new Response { Error = "Something went wrong. Please try again later. We are sorry." };
            return BadRequest(response);
        }
    }
}
