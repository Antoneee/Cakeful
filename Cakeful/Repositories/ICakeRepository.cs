using Cakeful.Models;

namespace Cakeful.Repositories
{
    public interface ICakeRepository
    {
        IEnumerable<Cake> GetCakes();
        IEnumerable<Cake> GetFeaturedCakes();
        Cake GetCake(int? cakeId);
        IEnumerable<Cake> Cakes { get; }
    }
}
