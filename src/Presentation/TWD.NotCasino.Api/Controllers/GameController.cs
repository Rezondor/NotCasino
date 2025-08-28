using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TWD.NotCasino.Api.Core.Enums.User;

namespace TWD.NotCasino.Api.Controllers;

[Route("api/[controller]")]
[Authorize(Roles = nameof(UserRoles.Base))]
[ApiController]
public class GameController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> PlayOneArmedBandit([FromQuery] int bet)
    {
        var rand = new Random();

        int[] nums = { rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10) };

        int multiplier = 0;

        if (nums[0] == nums[1] && nums[1] == nums[2])
        {
            multiplier = 41; // 1% вероятность (10 комбинаций)
        }
        else if (nums[0] == nums[1] || nums[0] == nums[2] || nums[1] == nums[2])
        {
            multiplier = 2; // 27% вероятность (270 комбинаций)
        }

        var win = bet * multiplier;

        return Ok(win);
    }
}
