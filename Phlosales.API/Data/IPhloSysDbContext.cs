using Microsoft.EntityFrameworkCore;
using Phlosales.API.Entities;

namespace Phlosales.API.Data
{
    public interface IPhloSysDbContext
    {
        DbSet<ProdOrder> ProdOrders { get; set; }
    }
}