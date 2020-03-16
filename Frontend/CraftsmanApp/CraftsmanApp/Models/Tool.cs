using System;
using System.ComponentModel.DataAnnotations;

namespace CraftsmanApp.Models
{
    public class Tool
    {
        public string ToolId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Purchased { get; set; }
        public Craftsman Owner { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string ToolBoxId { get; set; }
    }
}
