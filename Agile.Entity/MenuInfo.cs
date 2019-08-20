using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Entity
{
    public class MenuInfo
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        public string MenuName { get; set; }
        [SugarColumn(IsNullable = true)]
        public string MenuIcon { get; set; }

        [SugarColumn(Length = 50)]
        public string MenuUrl { get; set; }

        public int MenuLevel { get; set; }

        public int ParentId { get; set; }

        [SugarColumn(Length = 50, IsNullable = true)]
        public string Path { get; set; }

        public int IsDelete { get; set; }

        public int OrderFlag { get; set; }
    }
}
