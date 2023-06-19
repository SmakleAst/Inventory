using Inventory.Domain.Enum;

namespace Inventory.Domain.Response
{
    public class ComputerResponse<T> : IComputerResponse<T>
    {
        public string InventoryNumber { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Location { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }

    public interface IComputerResponse<T>
    {
        string InventoryNumber { get; }
        string Description { get; }
        string Owner { get; }
        string Location { get; }
        public StatusCode StatusCode { get; }
        T Data { get; set; }
    }
}
