using Agile.BaseLib.Repositories;
using Agile.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agile.Repository
{
    public class MenuInfoRepository : BaseSugarRepository<MenuInfo>, IMenuInfoRepository
    {

    }

    public class UserInfoRepository : BaseSugarRepository<UserInfo>, IUserInfoRepository
    {

    }

    public class UserRoleInfoRepository : BaseSugarRepository<UserRoleInfo>, IUserRoleInfoRepository
    {

    }

    public class UserRelationRoleRepository : BaseSugarRepository<UserRelationRole>, IUserRelationRoleRepository
    {

    }

    public class UserRoleRelateMenuRepository : BaseSugarRepository<UserRoleRelateMenu>, IUserRoleRelateMenuRepository
    {

    }

}
