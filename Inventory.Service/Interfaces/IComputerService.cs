using Inventory.Domain.Entity;
using Inventory.Domain.Filters;
using Inventory.Domain.Response;
using Inventory.Domain.ViewModels.Computers;
using System.Threading.Tasks;

namespace Inventory.Service.Interfaces
{
    public interface IComputerService
    {
        Task<IComputerResponse<ComputerEntity>> Create(CreateComputerViewModel model);

        Task<IComputerResponse<ComputerEntity>> Delete(CreateComputerViewModel model);

        Task<IComputerResponse<ComputerEntity>> Update(UpdateComputerViewModel model);

        Task<IComputerResponse<IEnumerable<ComputerViewModel>>> GetComputers(DeviceFilter filter);

        ComputerViewModel GetOneComputer(int id);
    }
}
