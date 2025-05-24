using Microsoft.AspNetCore.Mvc;

namespace TWD.NotCasino.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> PlayOneArmedBandit([FromQuery] int playersCount)
    {
        var rand = new Random();

        var bet = 1000;
        var betsCount = 1000;
        var count = 0;
        var lastWin = 0;

        var needToEnd = 2 * betsCount * bet;
        while (lastWin < needToEnd)
        {
            var win = 0;

            for (int i = 0; i < betsCount; i++)
            {
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

                win += bet * multiplier;

            }
            lastWin= win;
            count++;
        }


        return Ok(new
        {
            Win = lastWin,
            Count = count,
            Chance = 1 / count,
            TowardsMillion = 1_000_000 / count
        });
    }
}
