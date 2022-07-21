using System;
using System.Collections.Generic;
using Wayfinder.Models;
using Wayfinder.Repositories;

namespace Wayfinder.Services
{
  public class TripsService
  {
    private readonly TripsRepository _repo;

    public TripsService(TripsRepository repo)
    {
      _repo = repo;
    }

    internal List<Trip> GetAll(string userId)
    {
      return _repo.GetAll(userId);
    }

    internal Trip Create(Trip tripData)
    {
      return _repo.Create(tripData);
    }

    internal Trip GetById(int tripId, string userId)
    {
      // find
      Trip found = _repo.GetById(tripId);
      // validate not null
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      // validate is yours
      if (found.CreatorId != userId)
      {
        throw new Exception("Forbidden");
      }
      // return
      return found;
    }
  }
}