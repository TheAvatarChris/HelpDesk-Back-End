using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class PostItem
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int State { get; set; }
        public int UpArrow { get; set; }
        public int Number { get; set; }
        public string Letters { get; set; }
        public string Owner { get; set; }
    }
}
