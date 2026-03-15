using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComputerStoreInventory.Data;
using ComputerStoreInventory.Models;

namespace ComputerStoreInventory.Controllers;

public class InventoryItemsController : Controller
{
    private readonly InventoryContext _context;

    public InventoryItemsController(InventoryContext context)
    {
        _context = context;
    }

    // GET: InventoryItems
    public async Task<IActionResult> Index()
    {
        return View(await _context.InventoryItems.ToListAsync());
    }

    // GET: InventoryItems/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inventoryItem = await _context.InventoryItems.FirstOrDefaultAsync(m => m.Id == id);
        if (inventoryItem == null)
        {
            return NotFound();
        }

        return View(inventoryItem);
    }

    // GET: InventoryItems/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: InventoryItems/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,DateAcquired,EquipmentType,Status,ManufacturingYear,Condition,Manufacturer,Model,ScreenSize,StorageSizeGB,MemoryGB,Grade,Price")] InventoryItem inventoryItem)
    {
        if (ModelState.IsValid)
        {
            _context.Add(inventoryItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(inventoryItem);
    }

    // GET: InventoryItems/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inventoryItem = await _context.InventoryItems.FindAsync(id);
        if (inventoryItem == null)
        {
            return NotFound();
        }
        return View(inventoryItem);
    }

    // POST: InventoryItems/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,DateAcquired,EquipmentType,Status,ManufacturingYear,Condition,Manufacturer,Model,ScreenSize,StorageSizeGB,MemoryGB,Grade,Price")] InventoryItem inventoryItem)
    {
        if (id != inventoryItem.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(inventoryItem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemExists(inventoryItem.Id))
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
        return View(inventoryItem);
    }

    // GET: InventoryItems/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var inventoryItem = await _context.InventoryItems.FirstOrDefaultAsync(m => m.Id == id);
        if (inventoryItem == null)
        {
            return NotFound();
        }

        return View(inventoryItem);
    }

    // POST: InventoryItems/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var inventoryItem = await _context.InventoryItems.FindAsync(id);
        if (inventoryItem != null)
        {
            _context.InventoryItems.Remove(inventoryItem);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool InventoryItemExists(int id)
    {
        return _context.InventoryItems.Any(e => e.Id == id);
    }
}
