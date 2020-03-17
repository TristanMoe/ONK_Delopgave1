
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CraftsmanApp.Models
{
    public class Toolbox
    {
        [RegularExpression(@"[0-9]*$")]
        [StringLength(24, MinimumLength = 24)]
        [Required]
        [Display(Name = "Toolbox Id")]
        public string ToolboxId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Purchased { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Type { get; set; }
        public string OwnerId { get; set; }
        public List<Tool> Tools { get; set; } = new List<Tool>();
    }
}
