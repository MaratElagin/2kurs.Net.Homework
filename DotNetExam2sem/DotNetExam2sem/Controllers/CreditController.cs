using DotNetExam2sem.Dto;
using DotNetExam2sem.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetExam2sem.Controllers;


[ApiController]
[Route("credit")]
public class CreditController : ControllerBase
{
    private readonly CreditService _creditService;

    public CreditController(CreditService creditService)
    {
        _creditService = creditService;
    }

    [HttpPost("take")]
    public IActionResult TakeCredit([FromBody] CreditDto data)
    {
        var result = _creditService.GetCreditResult(data);
        return Ok(result);
    }
}