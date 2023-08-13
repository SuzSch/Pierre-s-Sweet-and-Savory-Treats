using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreatShop.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    public string Description { get; set; }
    public List<TreatFlavor> JoinEntities { get; }
    public ApplicationUser User { get; set; }
  }
}