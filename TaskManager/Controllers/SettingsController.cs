using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize(Roles = "admin")]
    public class SettingsController : Controller
    {
        private AppDbContext _context;
        public SettingsController(AppDbContext db)
        {
            _context = db;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var viewModel = new Settings()
            {
                IssueTypes = _context.IssueTypes.ToList(),
                IssueStatuses = _context.IssueStatuses.ToList(),
            };
            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult AddNewType(Settings model)
        {
            var type = _context.IssueTypes.SingleOrDefault(m => m.Name == model.TypeName);

            if (type == null)
            {
                var newType = new IssueType
                {
                    Name = model.TypeName
                };
                _context.IssueTypes.Add(newType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"]="This type is already exists!";
            };
            return RedirectToAction("Index",TempData);
        }

        [HttpPost]
        public ActionResult AddNewStatus(Settings model)
        {
            var status = _context.IssueStatuses.SingleOrDefault(m => m.Name == model.StatusName);

            if (status == null)
            {
                var newStatus = new IssueStatus
                {
                    Name = model.StatusName
                };
                _context.IssueStatuses.Add(newStatus);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "This status is already exists!";
            };
            return RedirectToAction("Index",TempData);
        }


        public ActionResult DeleteType(int id)
        {
            var type = _context.IssueTypes.SingleOrDefault(m => m.Id == id);
            var issueList = _context.Issues.Include(s => s.IssueStatus).ToList();
            var typeListCount = _context.IssueTypes.ToList().Count();
            var Message = "";

            foreach (Issue i in issueList)
            {
                if (i.IssueType.Name == type.Name)
                {
                    Message = "We have a task with this type";
                    return Json(Message);
                }
            }
            if (typeListCount <= 1)
            {
                Message = "We should have at least one type!";
                return Json(Message);
            }
            else
            {
                _context.Remove(type);
                _context.SaveChanges();
                return Json(Message);
            }
        }

        public ActionResult DeleteStatus(int id)
        {
            var status = _context.IssueStatuses.SingleOrDefault(m => m.Id == id);
            var issueList = _context.Issues.Include(s => s.IssueStatus).ToList();
            var statusListCount = _context.IssueStatuses.ToList().Count();
            var Message = "";

            foreach (Issue i in issueList) 
            {
                if (i.IssueStatus.Name == status.Name) 
                {
                    Message = "We have a task with this status";
                    return Json(Message);
                }             
            }
            if (statusListCount <= 1)
            {
                Message = "We should have at least one status!";
                return Json(Message);
            }
            else
            {
                _context.Remove(status);
                _context.SaveChanges();
                return Json(Message);
            }
            
        }
    }
}
