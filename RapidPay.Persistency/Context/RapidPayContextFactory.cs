using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Persistency.Context
{
    public class RapidPayContextFactory :
        IDesignTimeDbContextFactory<RapidPayContext>
    {
        public RapidPayContext CreateDbContext(string[] args)
        {
          
            var optionsBuilder =
                new DbContextOptionsBuilder<RapidPayContext>();

            optionsBuilder.UseSqlServer(
                "Server=.\\SQLSERVER2017;Database=AppRapidPay;Trusted_Connection=True;");

            return new RapidPayContext(optionsBuilder.Options);
        }

    }
}
