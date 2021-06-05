using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solution_CrudProduto.Domain;

namespace Solution_CrudProduto.Data
{
    public class BaseContext : IdentityDbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }

    }
}
