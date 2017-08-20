using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VolunteerSystem.Data;
using VolunteerSystem.Models;
using System.Collections;

namespace VolunteerSystem.Controllers
{
    public class VolunteersController : Controller
    {
        private readonly VolunteerContext _context;

        public VolunteersController(VolunteerContext context)
        {
            _context = context;
        }

        private void SetViewBagStatusType(Status selectedStatus = Status.Pending)
        {

            IEnumerable<Status> values = Enum.GetValues(typeof(Status))
                                             .Cast<Status>();

            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem
                                                {

                                                    Text = value.ToString(),
                                                    Value = value.ToString(),
                                                    Selected = value == selectedStatus,

                                                };

            ViewBag.Status = items;

        }


        // GET: Volunteers
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["UsernameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "uname_desc" : "";
            ViewData["StatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "status" : "";
            ViewData["currentFilter"] = searchString;

            if (searchString != null)
            {

            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["currentFilter"] = searchString;


            var volunteers = from v in _context.Volunteers
                             select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                volunteers = volunteers.Where(v => v.LastName.Contains(searchString)
                        || v.FirstName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    volunteers = volunteers.OrderByDescending(v => v.LastName);
                    break;
                case "uname_desc":
                    volunteers = volunteers.OrderByDescending(v => v.UserName);
                    break;
                case "status":
                    volunteers = volunteers.OrderBy(v => v.Status);
                    break;
                default:
                    volunteers = volunteers.OrderBy(v => v.LastName);
                    break;
            }

            return View(await volunteers.AsNoTracking().ToListAsync());

        }

        // GET: Volunteers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteers
                .Include(v => v.AvailableTimes)
                .Include(v => v.EmergencyContacts)
                .Include(v => v.Background)
                .Include(v => v.Centers)
                .Include(v => v.InterestsSkills)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.VolunteerID == id);
            if (volunteer == null)
            {
                return NotFound();
            }


            return View(volunteer);
        }

        // GET: Volunteers/Create
        public IActionResult Create()
        {
            SetViewBagStatusType();

            return View();
        }

        // POST: Volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,UserName,Password" +
            ",Address,HomePhone,WorkPhone,CellPhone,Email,LicenseOnFile,SSCardOnFile,Status")] Volunteer volunteer)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _context.Add(volunteer);

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");

            }

            SetViewBagStatusType();


            return View(volunteer);
        }

        // GET: Volunteers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteers
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.VolunteerID == id);

            if (volunteer == null)
            {
                return NotFound();
            }

            SetViewBagStatusType(volunteer.Status);


            return View(volunteer);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VolunteerID,FirstName,LastName,UserName,Password,Address," +
            "HomePhone,WorkPhone,CellPhone,Email,LicenseOnFile,SSCardOnFile,Status")] Volunteer volunteer)
        {
            if (id != volunteer.VolunteerID)
            {
                return NotFound();
            }

            try
            {
                _context.Update(volunteer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");


            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists, " +
                "see your system administrator.");
            }

            SetViewBagStatusType(volunteer.Status);

            return View(volunteer);
    }



    // GET: Volunteers/Delete/5
    public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
    {
        if (id == null)
        {
            return NotFound();
        }

        var volunteer = await _context.Volunteers
            .AsNoTracking()
            .SingleOrDefaultAsync(m => m.VolunteerID == id);
        if (volunteer == null)
        {
            return NotFound();
        }
        if (saveChangesError.GetValueOrDefault())
        {
            ViewData["ErrorMessage"] =
            "Delete failed. Try again, and if the problem persists " +
            "see your system administrator.";
        }


        return View(volunteer);
    }

    // POST: Volunteers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id, bool? saveChangesError = false)
    {
        var volunteer = await _context.Volunteers
            .AsNoTracking()
            .SingleOrDefaultAsync(m => m.VolunteerID == id);

        if (volunteer == null)
        {
            return RedirectToAction("Index");
        }

        try
        {
            _context.Volunteers.Remove(volunteer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.)
            return RedirectToAction("Delete", new { id = id, saveChangesError = true });

        }
    }

    private bool VolunteerExists(int id)
    {
        return _context.Volunteers.Any(e => e.VolunteerID == id);
    }
}
}
