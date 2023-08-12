using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreatShop.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    public string Profile { get; set; }
    public List<TreatFlavor> JoinEntities { get;}
  }
}