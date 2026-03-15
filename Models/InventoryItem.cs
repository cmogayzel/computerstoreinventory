using System.ComponentModel.DataAnnotations;

namespace ComputerStoreInventory.Models;

public enum EquipmentType
{
    Desktop,
    Laptop,
    Tablet,
    Phone
}

public enum InventoryStatus
{
    Accepted,
    Repairing,
    Testing,
    Available
}

public enum ItemGrade
{
    A,
    B,
    C
}

public class InventoryItem
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Date Acquired")]
    [DataType(DataType.Date)]
    public DateTime DateAcquired { get; set; }

    [Required]
    [Display(Name = "Equipment Type")]
    public EquipmentType EquipmentType { get; set; }

    [Required]
    [Display(Name = "Status")]
    public InventoryStatus Status { get; set; }

    [Required]
    [Display(Name = "Manufacturing Year")]
    [Range(1980, 2100, ErrorMessage = "Please enter a valid year.")]
    public int ManufacturingYear { get; set; }

    [Required]
    [StringLength(100)]
    public string Condition { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Manufacturer { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Model { get; set; } = string.Empty;

    [Display(Name = "Screen Size (inches)")]
    [Range(0, 100)]
    public decimal? ScreenSize { get; set; }

    [Required]
    [Display(Name = "Storage (GB)")]
    [Range(0, int.MaxValue)]
    public int StorageSizeGB { get; set; }

    [Required]
    [Display(Name = "Memory (GB)")]
    [Range(0, int.MaxValue)]
    public int MemoryGB { get; set; }

    [Required]
    public ItemGrade Grade { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
    public decimal Price { get; set; }
}
