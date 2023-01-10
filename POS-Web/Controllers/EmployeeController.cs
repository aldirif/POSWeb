using Microsoft.AspNetCore.Mvc;
using POS_Web.DataContext;

namespace POS_Web.Controllers;
public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;
    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<EmployeeEntity> employees = _context.EmployeeEntities.ToList();
        return View(employees);
    }

    [HttpGet]
    public IActionResult Details(int? id)
    {
        EmployeeEntity employee = _context.EmployeeEntities.Find(id);
        return View(employee);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Save([Bind("Name, Gender, Address, City, Position")] EmployeeEntity request)
    {
        // add ke entity
        _context.EmployeeEntities.Add(request);
        // commit to database
        _context.SaveChanges();

        return Redirect("GetAll");
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        var entity = _context.EmployeeEntities.Find(id);
        return View(entity);
    }

    public IActionResult Delete(int? id)
    {
        var entity = _context.EmployeeEntities.Find(id);
        if (entity == null)
        {
            return Redirect("GetAll");
        }
        // remove from entity
        _context.EmployeeEntities.Remove(entity);
        // commit to database
        _context.SaveChanges();
        return Redirect("/Employee/GetAll");
    }

    [HttpPost]
    public IActionResult Update([Bind("Id, Name, Gender, Address, City, Position")] EmployeeEntity request)
    {
        // update entity
        _context.EmployeeEntities.Update(request);
        // commit to database
        _context.SaveChanges();
        return Redirect("GetAll");
    }
}