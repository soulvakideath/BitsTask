using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CsvController : ControllerBase
{
    private readonly CsvDataService _csvDataService;

    public CsvController(CsvDataService csvDataService)
    {
        _csvDataService = csvDataService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadCsv( IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File is not selected or is empty.");
        }

        await _csvDataService.ProcessCsvData(file);
        return Ok("File uploaded and processed successfully.");
    }

    [HttpGet("data")]
    public IActionResult GetData()
    {
        var csvDataDtos = _csvDataService.GetCsvData();
        return Ok(csvDataDtos);
    }
}