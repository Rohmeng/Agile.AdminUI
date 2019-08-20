using Agile.BaseLib.Repositories;
using Agile.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Repository
{
    public interface IMenuInfoRepository : IBaseRepository<MenuInfo>
    {
    }

    public interface IUserInfoRepository : IBaseRepository<UserInfo>
    {
    }
    public interface IUserRelationRoleRepository : IBaseRepository<UserRelationRole>
    {
    }
    public interface IUserRoleInfoRepository : IBaseRepository<UserRoleInfo>
    {
    }
    public interface IUserRoleRelateMenuRepository : IBaseRepository<UserRoleRelateMenu>
    {
    }
}
