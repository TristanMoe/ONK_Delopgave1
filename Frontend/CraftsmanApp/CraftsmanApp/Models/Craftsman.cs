using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CraftsmanApp.Models
{
    public class Craftsman
    {
        public string ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime EmploymentDate { get; set; }
        public string Surname { get; set; }
        public string SubjectArea { get; set; }
        public string Firstname { get; set; }
        public List<Toolbox> ToolBoxes { get; set; }
    }
}
