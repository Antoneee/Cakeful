using Cakeful.Models;
using Microsoft.EntityFrameworkCore;

namespace Cakeful.Repositories
{
    public class CakeRepository : ICakeRepository
    {
        private readonly CakefulDbContext _cakefulDbContext;

        public CakeRepository(CakefulDbContext cakefulDbContext)
        {
            _cakefulDbContext = cakefulDbContext;
        }
        public Cake GetCake(int? cakeId)
        {
            var cake = _cakefulDbContext.Cakes.FirstOrDefault(c => c.CakeId == cakeId);
            return cake;
        }

        public IEnumerable<Cake> GetCakes()
        {
            var cakes = _cakefulDbContext.Cakes;
            return cakes;
        }

        public IEnumerable<Cake> GetFeaturedCakes()
        {
            var featuredCakes = _cakefulDbContext.Cakes.Where(c => c.IsFeaturedCake);
            return featuredCakes;
        }

        public IEnumerable<Cake> Cakes { 
            get
            {
                return _cakefulDbContext.Cakes.Include(c => c.Category);
            }
        }
    }
}
