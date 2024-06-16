using Microsoft.AspNetCore.Mvc;
using ParserName;

[ApiController]
[Route("api/[controller]")]
public class ParseNameController : ControllerBase
{
    private readonly INameParser _nameParser;

    public ParseNameController(INameParser nameParser)
    {
        _nameParser = nameParser;
    }

    [HttpPost("parse-name")]
    public IActionResult ParseName([FromBody] FullNameRequest request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.FullName))
        {
            return BadRequest(new { Message = "Full name is required." });
        }

        try
        {
            var result = _nameParser.ParseFullName(request.FullName);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}