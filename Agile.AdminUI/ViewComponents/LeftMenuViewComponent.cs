using Agile.AdminUI.Models;
using Agile.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.AdminUI.ViewComponents
{
    public class LeftMenuViewComponent : ViewComponent
    {
        private readonly IMenuInfoRepository _menuInfoRepository;
        public LeftMenuViewComponent(IMenuInfoRepository menuInfo)
        {
            _menuInfoRepository = menuInfo;
        }
        public async Task<IViewComponentResult> InvokeAsync(string mname)
        {
            List<MenuModel> menuModels = new List<MenuModel>();
            var menuList = await _menuInfoRepository.Query(x => x.IsDelete != 1, x => x.OrderFlag);
            foreach (var item in menuList)
            {
                var child = menuList.Where(x => x.ParentId == item.Id).ToArray();
                var active = mname == item.MenuName ? true : false;
                var temp = new MenuModel() { HasChild = child.Length > 0 ? true : false, IsActive = active, IsCloseItem = active == true ? false : true, MenuIcon = item.MenuIcon, MenuName = item.MenuName, MenuLevel = item.MenuLevel, Id = item.Id, ParentId = item.ParentId, MenuUrl = item.MenuUrl };
                menuModels.Add(temp);
            }
            return View(menuModels);
        }
    }
}
