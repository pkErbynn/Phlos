using Microsoft.EntityFrameworkCore;
using Phlosales.API.Entities;

namespace Phlosales.API.DbContexts
{
    public interface IPhloSysDbContext
    {
        DbSet<ProdOrder> ProdOrders { get; set; }
    }
}