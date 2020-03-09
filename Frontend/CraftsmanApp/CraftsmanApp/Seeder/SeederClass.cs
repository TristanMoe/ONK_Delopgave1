using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftsmanApp.Models;

namespace CraftsmanApp.Seeder
{
    public static class SeederClass
    {
        public static CraftsmanApp.Models.Craftsman CraftsmanObj() => new Craftsman()
        {
            ID = "hey",
            EmploymentDate = DateTime.Now,
            Surname = "Jespersen",
            SubjectArea = "Shit",
            Firstname = "Martin",
            ToolBoxes = new List<Toolbox> {
                    ToolBoxObj()
                }
        };

        public static CraftsmanApp.Models.Toolbox ToolBoxObj() => new Toolbox()
        {
            ID = "heyToolBox",
            Purchased = DateTime.Now,
            Brand = "godtBrand",
            Model = "godMeodel",
            SerialNumber  = "123454678",
            Type = "Hammer",
            OwnerId = "1234id",
            Tools = new List<Tool>() { ToolObj()}
        };

        public static CraftsmanApp.Models.Tool ToolObj() => new Tool()
        {
            ID = "heyTool",
            Purchased = DateTime.Now,
            Owner = CraftsmanObj(),
            Brand = "toolbrand",
            Color = "rod",
            Model = "godmodel",
            SerialNumber = "serialnumber",
            ToolBoxId = "toolboxid"
    };

    }
}
