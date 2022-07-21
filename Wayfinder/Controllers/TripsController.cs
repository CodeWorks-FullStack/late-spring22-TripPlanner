using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wayfinder.Models;
using Wayfinder.Services;

namespace Wayfinder.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class TripsController : ControllerBase
  {
    private readonly TripsService _ts;
    private readonly ReservationsService _rs;

    public TripsController(TripsService ts, ReservationsService rs)
    {
      _ts = ts;
      _rs = rs;
    }

    [HttpGet]
    public async Task<ActionResult<List<Trip>>> Get(string query = "")
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Trip> trips = _ts.GetAll(userInfo.Id);

        return Ok(trips);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Trip>> Get(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Trip trip = _ts.GetById(id, userInfo.Id);

        return Ok(trip);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/reservations")]
    public async Task<ActionResult<List<Reservation>>> GetReservations(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        List<Reservation> reservations = _rs.GetByTripId(id, userInfo.Id);
        return Ok(reservations);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public async Task<ActionResult<Trip>> CreateAsync([FromBody] Trip tripData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        tripData.CreatorId = userInfo.Id;
        Trip newTrip = _ts.Create(tripData);
        // fake the populate
        newTrip.Creator = userInfo;
        newTrip.CreatedAt = new DateTime();
        newTrip.UpdatedAt = new DateTime();

        return Ok(newTrip);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}