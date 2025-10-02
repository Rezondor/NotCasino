using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TWD.NotCasino.Api.Core.Enums.Users;
using TWD.NotCasino.Api.Core.Requests.Games;

namespace TWD.NotCasino.Api.Controllers;

[Route("api/[controller]")]
[Authorize]
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

    [HttpPost(nameof(Add))]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public async Task<IActionResult> Add(AddGameRequest addGame, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet(nameof(GetAllByServer))]
    public async Task<IActionResult> GetAllByServer(CancellationToken cancellationToken)
    {
        return Ok();
    }

    //TODO: Id игры, Ставка, доп данные (на подобии на какую клетку поставил и тд) (Парсить в нужной игре )
    [HttpGet(nameof(Play))]
    public async Task<IActionResult> Play(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet(nameof(GetRulesByGameId))]
    public async Task<IActionResult> GetRulesByGameId(long gameId, CancellationToken cancellationToken)
    {
        return Ok();
    }
}
