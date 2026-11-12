
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Factura.Models;

public class FacturasController : Controller
{
    private readonly FacturasDbContext _context;

    public FacturasController(FacturasDbContext context)
    {
        _context = context;
    }

    // GET: FACTURAMODELS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.FacturaModel.ToListAsync());
    }

    // GET: FACTURAMODELS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var facturamodel = await _context.FacturaModel
            .FirstOrDefaultAsync(m => m.id == id);
        if (facturamodel == null)
        {
            return NotFound();
        }

        return View(facturamodel);
    }

    // GET: FACTURAMODELS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: FACTURAMODELS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,cedula,nombre,direccion,telefono,mail")] FacturaModel facturamodel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(facturamodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(facturamodel);
    }

    // GET: FACTURAMODELS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var facturamodel = await _context.FacturaModel.FindAsync(id);
        if (facturamodel == null)
        {
            return NotFound();
        }
        return View(facturamodel);
    }

    // POST: FACTURAMODELS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("id,cedula,nombre,direccion,telefono,mail")] FacturaModel facturamodel)
    {
        if (id != facturamodel.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(facturamodel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaModelExists(facturamodel.id))
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
        return View(facturamodel);
    }

    // GET: FACTURAMODELS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var facturamodel = await _context.FacturaModel
            .FirstOrDefaultAsync(m => m.id == id);
        if (facturamodel == null)
        {
            return NotFound();
        }

        return View(facturamodel);
    }

    // POST: FACTURAMODELS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var facturamodel = await _context.FacturaModel.FindAsync(id);
        if (facturamodel != null)
        {
            _context.FacturaModel.Remove(facturamodel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FacturaModelExists(int? id)
    {
        return _context.FacturaModel.Any(e => e.id == id);
    }
}
