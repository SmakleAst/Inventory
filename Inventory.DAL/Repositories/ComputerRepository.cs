using Inventory.DAL.Interfaces;
using Inventory.Domain.Entity;

namespace Inventory.DAL.Repositories
{
    public class ComputerRepository : IBaseRepository<ComputerEntity>
    {
        private readonly AppDbContext _appDbContext;

        public ComputerRepository(AppDbContext appDbContext) =>
            _appDbContext = appDbContext;

        public async Task Create(ComputerEntity entity)
        {
            await _appDbContext.Computers.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(ComputerEntity entity)
        {
            _appDbContext.Computers.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<ComputerEntity> GetAll()
        {
            return _appDbContext.Computers;
        }

        public async Task<ComputerEntity> Update(ComputerEntity entity)
        {
            _appDbContext.Computers.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
