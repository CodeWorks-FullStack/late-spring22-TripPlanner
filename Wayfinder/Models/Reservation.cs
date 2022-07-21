namespace Wayfinder.Models
{
  public class Reservation
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Date { get; set; }
    public string ConfirmationCode { get; set; }
    public float Cost { get; set; }
    public string Address { get; set; }
    public int TripId { get; set; }
  }
}