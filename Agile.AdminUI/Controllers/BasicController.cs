using Agile.BaseLib.Models;
using Agile.Entity;
using Agile.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Agile.AdminUI.Controllers
{
    /// <summary>
    /// 后台基础功能控制器
    /// </summary>
    [Authorize] 
    public class BasicController : Controller
    {
        private readonly IMenuInfoRepository _menuInfoRepository;
        public BasicController(IMenuInfoRepository menuInfo)
        {
            _menuInfoRepository = menuInfo;
        }

        public async Task<IActionResult> Menu()
        {
            var menuSelectData = new Dictionary<int, string>();
            var menuList = await _menuInfoRepository.Query(x => x.MenuLevel == 1 || x.MenuLevel == 2, x => x.OrderFlag);

            foreach (var item in menuList)
            {
                if (item.ParentId == 0)
                {
                    menuSelectData.Add(item.Id, item.MenuName);
                }
                else
                {
                    var parentMenu = await _menuInfoRepository.QueryById(item.ParentId);
                    menuSelectData.Add(item.Id, parentMenu.MenuName + ">>" + item.MenuName);
                }
            }
            return View(menuSelectData);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMenu(MenuInfo model)
        {
            ExcutedResult result = ExcutedResult.FailedResult("");
            try
            {
                if (model.Id == 0)
                {
                    if (model.ParentId == 0)
                    {
                        model.MenuLevel = 1;
                        model.Path = "";
                    }
                    else
                    {
                        var parentModel = await _menuInfoRepository.QueryById(model.ParentId);
                        model.MenuLevel = parentModel.MenuLevel + 1;
                        if (string.IsNullOrWhiteSpace(parentModel.Path))
                        {
                            model.Path = parentModel.Id.ToString();
                        }
                        else
                        {
                            model.Path = parentModel.Path + "," + parentModel.Id;
                        }
                    }

                    model.IsDelete = 0;

                    var key = await _menuInfoRepository.Add(model);
                    if (key > 0)
                    {
                        model.Id = key;
                        result.success = true;
                    }
                }
            }
            catch (Exception e)
            {
                result.msg = e.Message;
            }
            return Json(result);
        }

        public async Task<IActionResult> TestAsync()
        {
            var menu = await _menuInfoRepository.Query(x => x.MenuLevel == 1 || x.MenuLevel == 2);
            return Json(menu);
        }

    }
}
