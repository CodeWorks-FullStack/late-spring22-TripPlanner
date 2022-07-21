using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wayfinder.Models;
using Wayfinder.Services;

namespace Wayfinder.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class ReservationsController : ControllerBase
  {
    private readonly ReservationsService _rs;

    public ReservationsController(ReservationsService rs)
    {
      _rs = rs;
    }

    // get by trip id

    // create
    [HttpPost]
    public async Task<ActionResult<Reservation>> Create([FromBody] Reservation reservationData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Reservation reservation = _rs.Create(reservationData, userInfo.Id);
        return Ok(reservation);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // delete


  }
}