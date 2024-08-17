

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Movies.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class IdentityController : ControllerBase
{

    [HttpGet("[action]", Name = "GetClaims")]
    public ActionResult GetClaims()
    {
        return new JsonResult(User.Claims.Select(c => new { c.Type, c.Value }));
    }



}
