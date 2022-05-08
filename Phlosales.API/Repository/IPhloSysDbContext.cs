using Microsoft.EntityFrameworkCore;
using Phlosales.API.Entities;

namespace Phlosales.API.Repository
{
    public interface IPhloSysDbContext
    {
        DbSet<ProdOrder> ProdOrders { get; set; }
    }
}