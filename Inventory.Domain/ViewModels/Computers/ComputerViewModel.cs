using System.ComponentModel.DataAnnotations;

namespace Inventory.Domain.ViewModels.Computers
{
    public class ComputerViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Инвентаризационный номер")]
        public string InventoryNumber { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Владелец")]
        public string Owner { get; set; }

        [Display(Name = "Локация")]
        public string Location { get; set; }

        [Display(Name = "Дата добавления")]
        public string AdditionDate { get; set; }
    }
}
