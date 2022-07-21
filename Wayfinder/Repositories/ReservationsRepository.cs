using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Wayfinder.Models;

namespace Wayfinder.Repositories
{
  public class ReservationsRepository
  {
    private readonly IDbConnection _db;

    public ReservationsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Reservation Create(Reservation reservationData)
    {
      string sql = @"
      INSERT INTO reservations
      (name, category, date, confirmationCode, cost, address, tripId)
      VALUES
      (@Name, @Category, @Date, @ConfirmationCode, @Cost, @Address, @TripId);
      SELECT LAST_INSERT_ID();";

      int id = _db.ExecuteScalar<int>(sql, reservationData);
      reservationData.Id = id;
      return reservationData;
    }

    internal List<Reservation> GetByTripId(int tripId)
    {
      string sql = "SELECT * FROM reservations WHERE tripId = @tripId";
      return _db.Query<Reservation>(sql, new { tripId }).ToList();
    }
  }
}