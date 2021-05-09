using System.Threading.Tasks;

namespace ApartmentFinder.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}