using Domain.Dtos.Configuration;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ConfigurationServices:BaseServices<Configurations,ConfigurationDto>,IConfigurationsServices
    {
        public ConfigurationServices(AppDbContext dbContext):base(dbContext)
        {

        }
    }
}
