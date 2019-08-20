using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Entity
{
    public class UserRoleInfo
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        public string RoleName { get; set; }

        public int SortNum { get; set; }

        public int IsDelete { get; set; }

    }
}
