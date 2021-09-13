using Domain.Dtos.Relevance;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RelevanceServices:BaseServices<Relevance,RelevanceDto>,IRelevanceServices
    {
        public RelevanceServices(AppDbContext dbContext):base(dbContext)
        {

        }
    }
}
