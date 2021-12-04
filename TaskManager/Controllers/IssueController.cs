using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskManager.Controllers
{
    [Authorize]
    public class IssueController : Controller
    {
        private AppDbContext _context;
        UserManager<IdentityUser> _userManager;
        public IssueController(AppDbContext db, UserManager<IdentityUser> userManager) 
        {
            _context = db;
            _userManager = userManager;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {   
            var newList = _context.Issues.Include(t => t.IssueType).Include(s=> s.IssueStatus).ToList();
            var typeList = _context.IssueTypes.ToList();
            var statusList = _context.IssueStatuses.ToList();
            

            var newModel = new ApplicationViewModel()
            {
                Issues = newList,
                IssueTypes = typeList,
                IssueStatuses = statusList
            };
            return View("Index", newModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Issue issue)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewIssueViewModel
                {
                    Issue = issue,
                    IssueTypes = _context.IssueTypes.ToList(),
                    IssueStatuses = _context.IssueStatuses.ToList(),
                    User = issue.CreationUser,
                    PageTitle = "New Task"
                };
                return View("IssueForm", viewModel);
            }
            if (issue.Id == 0)
                _context.Issues.Add(issue);
            else
            {
                var taskInDb = _context.Issues.Single(t => t.Id == issue.Id);

                //TryValidateModel(taskInDb);
                taskInDb.Name = issue.Name;
                taskInDb.Body = issue.Body;
                taskInDb.CreationDate = issue.CreationDate;
                taskInDb.DueDate = issue.DueDate;
                taskInDb.IssueTypeId = issue.IssueTypeId;
                taskInDb.IssueStatusId = issue.IssueStatusId;
                taskInDb.CreationUser = issue.CreationUser;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Issue");
        }

        public IActionResult New()
        {
            var TaskTypes = _context.IssueTypes.ToList();
            var TaskStatuses = _context.IssueStatuses.ToList();
            var viewModel = new NewIssueViewModel()
            {
                Issue = new Models.Issue(),
                IssueTypes = TaskTypes,
                IssueStatuses = TaskStatuses,
                User = User.Identity.Name,
                PageTitle = "New Task"
            };
            return View("IssueForm", viewModel);
        }

        public IActionResult Edit(int id)
        {
            var issue = _context.Issues.SingleOrDefault(c => c.Id == id);
            var user = issue.CreationUser;
            var typeList = _context.IssueTypes.ToList();
            var typeStatus = _context.IssueStatuses.ToList();
            if (issue == null)
                return NotFound();

            var viewModel = new NewIssueViewModel()
            {
                Issue = issue,
                IssueTypes = typeList,
                IssueStatuses = typeStatus,
                User = issue.CreationUser,
                PageTitle = "Edit Task",
            };

            return View("IssueForm", viewModel);
        }

        public IActionResult Complete(int id)
        {
            var task = _context.Issues.SingleOrDefault(c => c.Id == id);
            if (task.IsDone == false) task.IsDone = true;
            else task.IsDone = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Post
        public ActionResult Delete(int id)
        {
            var task = _context.Issues.SingleOrDefault(c => c.Id == id);
            _context.Issues.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
