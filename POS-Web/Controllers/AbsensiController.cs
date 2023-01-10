using Microsoft.AspNetCore.Mvc;
using POS_Web.DataContext;

namespace POS_Web.Controllers;
public class AbsensiController : Controller
{
    private readonly ApplicationDbContext _context;
    public AbsensiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<AbsensiEntity> absensis = _context.AbsensiEntities.ToList();
        return View(absensis);
    }

    [HttpGet]
    public IActionResult Details(int? id)
    {
        AbsensiEntity absensi = _context.AbsensiEntities.Find(id);
        return View(absensi);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Save([Bind("EmployeeId, AbsenStartDate, AbsenEndDate, Location, Description")] AbsensiEntity request)
    {
        // add ke entity
        _context.AbsensiEntities.Add(request);
        // commit to database
        _context.SaveChanges();
        
        return Redirect("GetAll");
    }
    
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        var entity = _context.AbsensiEntities.Find(id);
        return View(entity);
    }
    
    public IActionResult Delete(int? id)
    {
        var entity = _context.AbsensiEntities.Find(id);
        if (entity == null)
        {
            return Redirect("GetAll");
        }
        // remove from entity
        _context.AbsensiEntities.Remove(entity);
        // commit to database
        _context.SaveChanges();
        return Redirect("/Absensi/GetAll");
    }

    [HttpPost]
    public IActionResult Update([Bind("Id, EmployeeId, AbsenStartDate, AbsenEndDate, Location, Description")] AbsensiEntity request)
    {
        // update entity
        _context.AbsensiEntities.Update(request);
        // commit to database
        _context.SaveChanges();
        return Redirect("GetAll");
    }
}