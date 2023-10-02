using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface ISupplyDetailsRepository
    {
        Task<IEnumerable<SupplyDetailModel>> GetAllAsync();
        Task<IEnumerable<SupplyDetailModel>> GetSuppplySupplyAsync();
        Task<SupplyDetailModel> GetByIdAsync(long id);
        Task<SupplyDetailModel> AddAsync(SupplyDetailModel supplyDetail);
        Task UpdateAsync(SupplyDetailModel supplyDetail);

        // Este método nuevo se agrega a la interfaz para que el servicio pueda llamarlo.
        //Task<IEnumerable<SupplyDetailModel>> GetSupplySupplyDetailsForSupplyAsync(long supplyDetailsId);
        //Task<IEnumerable<SupplySupplyDetailsModel>> GetSupplyDetailsForSupplyAsync(long supplyDetail);
        //Task<IEnumerable<SupplyDetailModel>> GetSupplySupplyDetailsForSupplyAsync(long supplyDetailsId)
        //{
        //    throw new NotImplementedException();
        //}

        Task ChangeState(long id);
    }
}
