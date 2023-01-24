using Microsoft.EntityFrameworkCore;
using InDrivoHRM.Models;
using Microsoft.EntityFrameworkCore.DataEncryption;

namespace InDrivoHRM.Data
{
    public partial class CrmContext
    {
        partial void OnModelBuilding(ModelBuilder builder)
        {
            // builder.UseEncryption(this.provider);

            builder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        }
    }
}
