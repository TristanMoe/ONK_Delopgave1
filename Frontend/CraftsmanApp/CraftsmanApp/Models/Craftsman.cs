using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CraftsmanApp.Models
{
    public class Craftsman
    {
        [RegularExpression(@"[0-9]*$")]
        [StringLength(24, MinimumLength = 24)]
        [Required]
        [Display(Name = "Craftsman Id")]
        public string CraftsmanId { get; set; }

        [DataType(DataType.Date)]
        public DateTime EmploymentDate { get; set; }
        public string Surname { get; set; }
        public string SubjectArea { get; set; }
        public string Firstname { get; set; }


        public List<Toolbox> ToolBoxes { get; set; } = new List<Toolbox>();
    }
}
