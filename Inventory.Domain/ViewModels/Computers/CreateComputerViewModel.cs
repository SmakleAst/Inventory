namespace Inventory.Domain.ViewModels.Computers
{
    public class CreateComputerViewModel
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Location { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(InventoryNumber))
            {
                throw new ArgumentNullException(InventoryNumber, "Укажите инвентаризационный номер");
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                throw new ArgumentNullException(Description, "Укажите описание компьютера");
            }

            if (string.IsNullOrWhiteSpace(Owner))
            {
                throw new ArgumentNullException(Owner, "Укажите владельца");
            }

            if (string.IsNullOrWhiteSpace(Location))
            {
                throw new ArgumentNullException(Location, "Укажите местонахождение");
            }
        }
    }
}
