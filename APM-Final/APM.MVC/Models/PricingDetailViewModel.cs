using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APM.MVC.Models
{
  public class ProductViewModel
  {
    public string Category { get; set; }
    public string Cost { get; set; }
    public int Id { get; private set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:d}")]
    public DateTimeOffset EffectiveDate { get; set; }

    public string Name { get; set; }

    public string Price { get; set; }
    public string Reason { get; set; }

  }
}
