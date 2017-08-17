using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VolunteerSystem.Data;
using VolunteerSystem.Models;

namespace VolunteerSystem.Controllers
{
    public class VolunteersController : Controller
    {
        private readonly VolunteerContext _context;

        public VolunteersController(VolunteerContext context)
        {
            _context = context;    
        }

        // GET: Volunteers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Volunteers.ToListAsync());
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
                .SingleOrDefaultAsync(m => m.ID == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        // GET: Volunteers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Volunteers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,UserName,Password,Address,HomePhone,WorkPhone,CellPhone,Email,LicenseOnFile,SSCardOnFile,Approved")] Volunteer volunteer)
        {
            try {

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
            return View(volunteer);
        }

        // GET: Volunteers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteers.SingleOrDefaultAsync(m => m.ID == id);
            if (volunteer == null)
            {
                return NotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,UserName,Password,Address,HomePhone,WorkPhone,CellPhone,Email,LicenseOnFile,SSCardOnFile,Approved")] Volunteer volunteer)
        {
            if (id != volunteer.ID)
            {
                return NotFound();
            }

            var volunteerToUpdate = await _context.Volunteers.SingleOrDefaultAsync(v => v.ID == id);

            if (await TryUpdateModelAsync<Volunteer>(
                volunteerToUpdate, 
                "",
                v => volunteer.FirstName, v => volunteer.LastName, v => volunteer.UserName, v => volunteer.Password, 
                v => volunteer.Address, v => volunteer.HomePhone, v => volunteer.WorkPhone, v => volunteer.CellPhone,
                v => volunteer.Email, v => volunteer.LicenseOnFile, v => volunteer.SSCardOnFile, v => volunteer.Approved))
                {
                try 
                {
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
            }
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
                .SingleOrDefaultAsync(m => m.ID == id);
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
                .SingleOrDefaultAsync(m => m.ID == id);
            
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
            return _context.Volunteers.Any(e => e.ID == id);
        }
    }
}
