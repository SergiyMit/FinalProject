using FinalProject.BLL.Interfaces;
using FinalProject.DAL.Interfaces;
using FinalProject.DAL.Repositories;

namespace FinalProject.BLL.Services
{
    public class DiveService : IDiveService
    {
        IUnitOfWork Database { get; set; }

        public DiveService()
        {
            Database = new EFUnitOfWork();
        }

    }

}
