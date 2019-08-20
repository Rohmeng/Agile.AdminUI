using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Entity
{
    public class UserInfo
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string LoginPassWord { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Email { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Tel { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Address { get; set; }
        [SugarColumn(IsNullable = true)]
        public string CompanyName { get; set; }
        public int UserType { get; set; }
        public int Status { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Source { get; set; }
        [SugarColumn(IsNullable = true)]
        public string LoginToken { get; set; }
        [SugarColumn(IsNullable = true)]
        public string RegionIp { get; set; }

        public DateTime CreateDate { get; set; }
        [SugarColumn(IsNullable = true)]
        public string RealName { get; set; }
        [SugarColumn(IsNullable = true)]
        public string HeadImage { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Country { get; set; }
        [SugarColumn(IsNullable = true)]
        public string Province { get; set; }
        [SugarColumn(IsNullable = true)]
        public string City { get; set; }
    }
}
