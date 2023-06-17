using Inventory.Domain.Entity;
using Inventory.Domain.Response;
using Inventory.Domain.ViewModels.Computers;
using Inventory.Service.Interfaces;

namespace Inventory.Service.Implementations
{
    public class ComputerService : IComputerService
    {
        public Task<IComputerResponse<ComputerEntity>> Create(CreateComputerViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IComputerResponse<IEnumerable<ComputerViewModel>>> GetComputers()
        {
            throw new NotImplementedException();
        }
    }
}
