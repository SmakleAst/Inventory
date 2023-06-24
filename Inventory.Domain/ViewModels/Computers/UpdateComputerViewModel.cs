namespace Inventory.Domain.ViewModels.Computers
{
    public class UpdateComputerViewModel
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Location { get; set; }
        public DateTime AdditionDate { get; set; }
    }
}
