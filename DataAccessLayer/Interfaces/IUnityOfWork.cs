using Shared;

namespace DataAccessLayer.Interfaces
{
    public interface IUnityOfWork
    {
        ICarroDAL CarroDAL { get; }
        ISaidasCarroDAL SaidasCarroDAL { get; }
        Task<Response> Commit();
    }
}
