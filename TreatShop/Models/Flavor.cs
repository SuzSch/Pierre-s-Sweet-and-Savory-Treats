using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreatShop.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    [Required(ErrorMessage = "A flavor profile is required")]
    public string Profile { get; set; }
    public List<TreatFlavor> JoinEntities { get;}
    public ApplicationUser User { get; set; }
  }
}