using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NewsFeed.Data;
using NewsFeed.Models;

namespace NewsFeed.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(/*string returnUrl*/)
        {
            /*ViewBag.ReturnUrl = returnUrl; */
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model /*string returnUrl*/)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("GetUserCategoryNews", "Account");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    return RedirectToAction("PersonalizePage", "Account");
                }

                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }


        public ActionResult PersonalizePage()
        {
            var dbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

            var model = dbContext.Categories.ToList();

            return View(model);
        }

        public ActionResult GetUserCategoryNews ()
        {
            var id = User.Identity.GetUserId();
            var dbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var user = dbContext.Users.FirstOrDefault(m => m.Id == id);
            var categoryId = user.CategoryId;
            var category = dbContext.Categories.FirstOrDefault(m => m.Id == categoryId);
            return Redirect("/apis/" + category.Name);
        }
        
        [HttpPost]
        public ActionResult PersonalizePage(int categoryId)
        {
            var id = User.Identity.GetUserId();
            var dbContext = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            var user = dbContext.Users.FirstOrDefault(m => m.Id == id);
            user.CategoryId = categoryId;
            dbContext.SaveChanges();
            var category = dbContext.Categories.FirstOrDefault(m => m.Id == categoryId);
            return Redirect("/apis/" + category.Name);
        }


        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public string GetAftonbladet()
        {
            var client = new WebClient();

            return client.DownloadString("https://www.aftonbladet.se/");
        }
    }
}

