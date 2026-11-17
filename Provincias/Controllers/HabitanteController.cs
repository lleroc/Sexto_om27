
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Provincias.Models;

public class HabitanteController : Controller
{
    private readonly ProvinciasDbCntext _context;

    public HabitanteController(ProvinciasDbCntext context)
    {
        _context = context;
    }

    // GET: HABITANTES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Habitantes.Include(c => c.Canton).ToListAsync());
    }

    // GET: HABITANTES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var habitante = await _context.Habitantes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (habitante == null)
        {
            return NotFound();
        }

        return View(habitante);
    }

    // GET: HABITANTES/Create
    public IActionResult Create()
    {
        ViewBag.Provincias = new SelectList(
            _context.Provincias.OrderBy(p => p.Nombre), "Id", "Nombre");
        return View();
    }

    [HttpGet]
    public IActionResult GetCantones(int provinciaId) { 
        var cantones = _context.Cantones
            .Where(c => c.ProvinciaId == provinciaId)
            .OrderBy(c => c.Nombre)
            .Select(c => new { c.Id, c.Nombre })
            .ToList();
        return Json(cantones);
    }

    // POST: HABITANTES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Fecha_Nacimiento,email,Fecha_Registro,Edad,CantonId,Canton")] Habitante habitante)
    {
        if (ModelState.IsValid)
        {
            _context.Add(habitante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(habitante);
    }

    // GET: HABITANTES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var habitante = await _context.Habitantes.FindAsync(id);
        if (habitante == null)
        {
            return NotFound();
        }
        return View(habitante);
    }

    // POST: HABITANTES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Apellido,Fecha_Nacimiento,email,Fecha_Registro,Edad,CantonId,Canton")] Habitante habitante)
    {
        if (id != habitante.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(habitante);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitanteExists(habitante.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(habitante);
    }

    // GET: HABITANTES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var habitante = await _context.Habitantes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (habitante == null)
        {
            return NotFound();
        }

        return View(habitante);
    }

    // POST: HABITANTES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var habitante = await _context.Habitantes.FindAsync(id);
        if (habitante != null)
        {
            _context.Habitantes.Remove(habitante);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HabitanteExists(int? id)
    {
        return _context.Habitantes.Any(e => e.Id == id);
    }
}
