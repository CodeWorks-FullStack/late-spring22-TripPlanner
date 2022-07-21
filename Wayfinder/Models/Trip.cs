using System;

namespace Wayfinder.Models
{
  public class Trip
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; } = "";
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}