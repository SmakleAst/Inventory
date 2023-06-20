using Inventory.Domain.Entity;
using Inventory.Domain.Response;
using Inventory.Domain.ViewModels.Computers;

namespace Inventory.Service.Interfaces
{
    public interface IComputerService
    {
        Task<IComputerResponse<ComputerEntity>> Create(CreateComputerViewModel model);

        Task<IComputerResponse<IEnumerable<ComputerViewModel>>> GetComputers();

        ComputerViewModel GetOneComputer(int id);
    }
}
