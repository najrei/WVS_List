using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WVS_List.Models;

namespace WVS_List.Controllers
{
    public class LoginController : Controller
    {
        private DBContext db = new DBContext();


        public ActionResult Index()
        {
            ViewBag.UserID = new SelectList(db.Admins, "AdminID", "AdminID");
            return View();
        }
        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserID,Username,Firstname,Lastname,Email,Salt,Password,Status,AdminID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Admins, "AdminID", "AdminID", user.UserID);
            return View(user);
        }


        // GET: Login/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Admins, "AdminID", "AdminID");
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Username,Firstname,Lastname,Email,Salt,Password,Status,AdminID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Admins, "AdminID", "AdminID", user.UserID);
            return View(user);
        }

       
    }
}
