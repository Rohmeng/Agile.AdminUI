using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Entity
{
    public class UserRelationRole
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int UserRoleId { get; set; }

        public DateTime ValidityDate { get; set; }

        public string RoleName { get; set; }

    }
}
