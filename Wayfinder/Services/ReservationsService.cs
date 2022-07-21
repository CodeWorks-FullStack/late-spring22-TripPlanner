using System.Collections.Generic;
using Wayfinder.Models;
using Wayfinder.Repositories;

namespace Wayfinder.Services
{
  public class ReservationsService
  {
    private readonly TripsService _ts;
    private readonly ReservationsRepository _repo;

    public ReservationsService(TripsService ts, ReservationsRepository repo)
    {
      _ts = ts;
      _repo = repo;
    }

    internal Reservation Create(Reservation reservationData, string userId)
    {
      _ts.GetById(reservationData.TripId, userId);
      return _repo.Create(reservationData);
    }

    internal List<Reservation> GetByTripId(int tripId, string userId)
    {
      _ts.GetById(tripId, userId);
      return _repo.GetByTripId(tripId);
    }
  }
}