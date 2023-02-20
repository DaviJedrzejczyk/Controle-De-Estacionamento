using DataAccessLayer.Interfaces;
using Shared;

namespace DataAccessLayer.Implements
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly EstacionamentoDB _db;
        private ICarroDAL carro = null;
        private ISaidasCarroDAL saidasCarro = null;
        public UnityOfWork(EstacionamentoDB db, ICarroDAL carroDAL, ISaidasCarroDAL saidasCarroDAL)
        {
            _db = db;
            carro = carroDAL;
            saidasCarro = saidasCarroDAL;
        }

        public async Task<Response> Commit()
        {
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }
        public ICarroDAL CarroDAL
        {
            get
            {
                carro ??= new CarroDAL(_db);
                return carro;
            }
        }
        public ISaidasCarroDAL SaidasCarroDAL
        {
            get
            {
                saidasCarro ??= new SaidasCarroDAL(_db);
                return saidasCarro;
            }
        }
        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
