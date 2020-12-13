using Foodly.Areas.Identity.Data;
using Foodly.Models.Administration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Foodly.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private UserManager<UserIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(UserManager<UserIdentity> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public ViewResult Index() => View(_roleManager.Roles);


        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);
        }


        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<UserIdentity> members = new List<UserIdentity>();
            List<UserIdentity> nonMembers = new List<UserIdentity>();
             foreach (var user in _userManager.Users)
             {
                 var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                 list.Add(user);
             }
            return View(new RoleEdit
            {
                Role = role,
                Members= members,
                NonMembers= nonMembers
            });
            
        }
        [HttpPost]
        public async Task<IActionResult> Update(RoleModification Model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (var userId in Model.AddIds ?? new string[] { })
                {
                    UserIdentity user = await _userManager.FindByIdAsync(userId);
                    if(user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, Model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (var userId in Model.DeleteIds ?? new string[] { })
                {
                    UserIdentity user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, Model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }
            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(Model.RoleId);
        }



        public IActionResult AccessDenied()
        {
            return View();
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}