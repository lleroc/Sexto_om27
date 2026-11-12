
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Provincias.Models;

public class CantonController : Controller
{
    private readonly ProvinciasDbCntext _context;

    public CantonController(ProvinciasDbCntext context)
    {
        _context = context;
    }

    // GET: CANTONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Cantones
            .Include(pr => pr.Provincia)
            .OrderBy(pr => pr.Provincia.Nombre)
            .ToListAsync());
    }

    // GET: CANTONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var canton = await _context.Cantones
            .FirstOrDefaultAsync(m => m.Id == id);
        if (canton == null)
        {
            return NotFound();
        }

        return View(canton);
    }

    // GET: CANTONS/Create
    public IActionResult Create()
    {
        var provincias = _context.Provincias
            .OrderBy(p => p.Nombre)
            .ToList();
        ViewBag.Provincias = new SelectList(provincias, "Id", "Nombre");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Extension,Numero_Habitantes,ProvinciaId,Provincia")] Canton canton)
    {
        ModelState.Remove("Provincia");
        if (ModelState.IsValid)
        {
            _context.Add(canton);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        var provincias = _context.Provincias
            .OrderBy(p => p.Nombre)
            .ToList();
        ViewBag.Provincias = new SelectList(provincias, "Id", "Nombre");
        return View(canton);
    }

    // GET: CANTONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var canton = await _context.Cantones.FindAsync(id);
        if (canton == null)
        {
            return NotFound();
        }
        var provincias = _context.Provincias
            .OrderBy(p => p.Nombre)
            .ToList();
        ViewBag.Provincias = new SelectList(provincias, "Id", "Nombre");

        return View(canton);
    }

    // POST: CANTONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Extension,Numero_Habitantes,ProvinciaId,Provincia")] Canton canton)
    {
        if (id != canton.Id)
        {
            return NotFound();
        }

        ModelState.Remove("Provincia");

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(canton);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CantonExists(canton.Id))
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
        var provincias = _context.Provincias
            .OrderBy(p => p.Nombre)
            .ToList();
        ViewBag.Provincias = new SelectList(provincias, "Id", "Nombre");
        return View(canton);
    }

    // GET: CANTONS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var canton = await _context.Cantones
            .FirstOrDefaultAsync(m => m.Id == id);
        if (canton == null)
        {
            return NotFound();
        }

        return View(canton);
    }

    // POST: CANTONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var canton = await _context.Cantones.FindAsync(id);
        if (canton != null)
        {
            _context.Cantones.Remove(canton);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CantonExists(int? id)
    {
        return _context.Cantones.Any(e => e.Id == id);
    }
}
