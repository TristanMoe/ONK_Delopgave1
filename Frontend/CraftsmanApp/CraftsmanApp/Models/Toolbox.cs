
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CraftsmanApp.Models
{
    public class Toolbox
    {
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
