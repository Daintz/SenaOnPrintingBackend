using DataCape.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PersistenceCape.Interfaces;


namespace persistencecape.repositories
{
    public class SupplyDetailsRepository : ISupplyDetailsRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public SupplyDetailsRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplyDetailModel>> GetAllAsync()
        {
            return await _context.SupplyDetails
                .Include(d => d.Supplies)
                .ToListAsync();
        }

        public async Task<SupplyDetailModel> GetByIdAsync(long id)
        {
            var supplyDetail = await _context.SupplyDetails
                .Include(d => d.Supplies)
                .ThenInclude(d => d.Supply)
                .FirstOrDefaultAsync(d => d.Id == id);
            
            return supplyDetail;
        }


        public async Task UpdateAsync(SupplyDetailModel supplyDetail)
        {
            _context.Entry(supplyDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SupplyDetailModel>> GetSuppplySupplyAsync()
        {
            var supplyDetails = await _context.SupplyDetails
                .Include(ss => ss.Supplies)
                    .ThenInclude(ssd => ssd.Supply)
                .Select(ss => new SupplyDetailModel
                {
                    Id = ss.Id,
                    ProviderId = ss.ProviderId,
                    Description = ss.Description,
                    EntryDate = ss.EntryDate,
                    FullValue = ss.FullValue,
                    StatedAt = ss.StatedAt,
                })
                .ToListAsync();

            var supplySupplyDetails = await _context.SupplySupplyDetails
                .Select(ssd => new SupplySupplyDetailsModel
                {
                    Id = ssd.Id,
                    SupplyId = ssd.SupplyId,
                    supplydetails_id = ssd.supplydetails_id,
                    Quantity = ssd.Quantity,
                    SupplyCost = ssd.SupplyCost,
                    SupplyName = ssd.Supply.Name,
                })
                .ToListAsync();



            // Combina las propiedades en la lista de cotizaciones cliente
            foreach (var supplyDetail in supplyDetails)
            {
                supplyDetail.Supplies = supplySupplyDetails
                    .Where(ssd => ssd.supplydetails_id == supplyDetail.Id)
                    .ToList();
            }

            return supplyDetails;
        }

        public async Task<SupplyDetailModel> AddAsync(SupplyDetailModel supplyDetail)
        {
            await _context.SupplyDetails.AddAsync(supplyDetail);
            await _context.SaveChangesAsync();
            return supplyDetail;
        }

        //public async Task<IEnumerable<SupplySupplyDetailsModel>> GetSupplySupplyDetailsForSupplyAsync(long supplyDetailsId)
        //{
        //    // Crea una consulta para unir las tablas `SupplySupplyDetails` y `Supplies`.
        //    var query = from det in _context.SupplySupplyDetails
        //                join com in _context.Supplies on det.SupplyId equals com.Id
        //                select new SupplySupplyDetailsModel
        //                {
        //                    supplydetails_id = det.supplydetails_id,
        //                    SupplyId = det.SupplyId,
        //                    Quantity = det.Quantity,
        //                    SupplyCost = det.SupplyCost,
        //                    Supply = com
        //                };

        //    // Filtra la consulta para que solo devuelva los registros que coincidan con el `supplyDetailsId` especificado.
        //    query = query.Where(d => d.supplydetails_id == supplyDetailsId);

        //    // Devuelve los resultados de la consulta.
        //    return await query.ToListAsync();
        //}



        public async Task ChangeState(long id)
        {
            var supplyDetailsRepository = await _context.SupplyDetails.FindAsync(id);

            supplyDetailsRepository.StatedAt = !supplyDetailsRepository.StatedAt;
            await _context.SaveChangesAsync();
        }

        
    }
}
