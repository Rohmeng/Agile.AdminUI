using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Entity
{
    public class UserRoleRelateMenu
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        public int UserRoleId { get; set; }

        public int MenuId { get; set; }
    }
}
