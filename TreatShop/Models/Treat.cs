using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreatShop.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "A description is required")]
    public string Description { get; set; }
    public List<TreatFlavor> JoinEntities { get; }
    public ApplicationUser User { get; set; }
  }
}