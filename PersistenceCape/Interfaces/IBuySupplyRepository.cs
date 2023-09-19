using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Interfaces
{
    public interface IBuySupplyRepository
    {
        Task<IEnumerable<BuySupplyModel>> Index();
        Task<BuySupplyModel> Show(long id);
        Task<BuySupplyModel> Create(BuySupplyModel buySupply);
        Task Update(BuySupplyModel buySupply);
        Task ChangeState(long id);
    }
}
