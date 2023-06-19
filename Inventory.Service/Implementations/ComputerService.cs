using Inventory.DAL.Interfaces;
using Inventory.Domain.Entity;
using Inventory.Domain.Enum;
using Inventory.Domain.Response;
using Inventory.Domain.ViewModels.Computers;
using Inventory.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory.Service.Implementations
{
    public class ComputerService : IComputerService
    {
        private readonly IBaseRepository<ComputerEntity> _computerRepository;
        private ILogger<ComputerService> _logger;

        public ComputerService(IBaseRepository<ComputerEntity> computerRepository,
            ILogger<ComputerService> logger) => (_computerRepository, _logger) = (computerRepository, logger);

        public async Task<IComputerResponse<ComputerEntity>> Create(CreateComputerViewModel model)
        {
            try
            {
                model.Validate();

                _logger.LogInformation($"Запрос на создание компьютера - {model.InventoryNumber}");

                var computer = await _computerRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.InventoryNumber == model.InventoryNumber);

                if (computer != null)
                {
                    return new ComputerResponse<ComputerEntity>()
                    {
                        Description = "Такой компьютер уже есть",
                        StatusCode = StatusCode.ComputerAlreadyExists
                    };
                }

                computer = new ComputerEntity()
                {
                    InventoryNumber = model.InventoryNumber,
                    Description = model.Description,
                    Owner = model.Owner,
                    Location = model.Location,
                    AdditionDate = DateTime.Today,
                };

                await _computerRepository.Create(computer);

                _logger.LogInformation($"Компьютер создался: {computer.Id} {computer.AdditionDate}");
                return new ComputerResponse<ComputerEntity>()
                {
                    Description = "Компьютер создан",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[ComputerService.Create]: {exception.Message}");
                return new ComputerResponse<ComputerEntity>()
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IComputerResponse<IEnumerable<ComputerViewModel>>> GetComputers()
        {
            try
            {
                var tasks = await _computerRepository.GetAll()
                    //.WhereIf(!string.IsNullOrWhiteSpace(filter.Description),
                    //    x => x.Description.Contains(filter.Description))
                    //.WhereIf(filter.Priority.HasValue, x => x.Priority == filter.Priority)
                    .Select(x => new ComputerViewModel()
                    {
                        Id = x.Id,
                        InventoryNumber = x.InventoryNumber,
                        Description = x.Description,
                        Owner = x.Owner,
                        Location = x.Location,
                        AdditionDate = x.AdditionDate.ToLongDateString(),
                    })
                    .ToListAsync();

                return new ComputerResponse<IEnumerable<ComputerViewModel>>()
                {
                    Data = tasks,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[ComputerService.GetComputers]: {exception.Message}");
                return new ComputerResponse<IEnumerable<ComputerViewModel>>()
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
