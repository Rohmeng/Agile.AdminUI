using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.AdminUI.Models
{
    public class MenuModel
    {
        public bool IsActive { get; set; }
        public string MenuIcon { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public int MenuLevel { get; set; }
        public int Id { get; set; }
        public int ParentId { get; set; }
        public bool HasChild { get; set; }
        public bool IsCloseItem { get; set; }
    }
}
