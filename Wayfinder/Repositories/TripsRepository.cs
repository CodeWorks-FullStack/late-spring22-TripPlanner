using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Wayfinder.Models;

namespace Wayfinder.Repositories
{
  public class TripsRepository
  {
    private readonly IDbConnection _db;

    public TripsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Trip> GetAll(string userId)
    {
      string sql = @"
      SELECT
        t.*,
        a.*
      FROM trips t
      JOIN accounts a ON t.creatorId = a.id
      WHERE t.creatorId = @userId";
      return _db.Query<Trip, Profile, Trip>(sql, (trip, prof) =>
      {
        trip.Creator = prof;
        return trip;
      }, new { userId }).ToList();
    }

    internal Trip GetById(int tripId)
    {
      string sql = @"
      SELECT
        t.*,
        a.*
      FROM trips t
      JOIN accounts a ON t.creatorId = a.id
      WHERE t.id = @tripId";
      return _db.Query<Trip, Profile, Trip>(sql, (trip, prof) =>
      {
        trip.Creator = prof;
        return trip;
      }, new { tripId }).FirstOrDefault();
    }

    internal Trip Create(Trip tripData)
    {
      string sql = @"
      INSERT INTO trips
      (name, notes, creatorId)
      VALUES
      (@Name, @Notes, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, tripData);
      tripData.Id = id;
      return tripData;
    }


  }
}