using DataCape.Models;
using persistencecape.repositories;
using PersistenceCape.Interfaces;
using PersistenceCape.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class SupplySupplyDetailsService
    {

    private readonly ISupplySupplyDetailsRepository _supplySupplyDetailRepository;

    public SupplySupplyDetailsService(ISupplySupplyDetailsRepository supplySupplyDetailRepository)
    {
        _supplySupplyDetailRepository = supplySupplyDetailRepository;
    }

    public async Task<IEnumerable<SupplySupplyDetailsModel>> GetAllAsync()
    {
        return await _supplySupplyDetailRepository.GetAllAsync();
    }

    public async Task<SupplySupplyDetailsModel> GetByIdAsync(long id)
    {
        return await _supplySupplyDetailRepository.GetByIdAsync(id);
    }

    //public async Task<IEnumerable<SupplySupplyDetailsModel>> GetSuppplySupplyAsync()
    //{
    //    return await _supplySupplyDetailRepository.GetSuppplySupplyAsync();
    //}

    public async Task AddAsync(SupplySupplyDetailsModel supplySupplyDetail)
    {
        await _supplySupplyDetailRepository.AddAsync(supplySupplyDetail);
    }

    public async Task UpdateAsync(SupplySupplyDetailsModel supplySupplyDetail)
    {
        await _supplySupplyDetailRepository.UpdateAsync(supplySupplyDetail);
 
    }

    }
}
