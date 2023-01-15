using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        //public ICourseRepository Courses { get; private set; }
        //public ICompanyRepository Companies { get; private set; }
        //public IStockPriceRepository StockPrice { get; private set; }

        public ApplicationUnitOfWork(IApplicationDbContext dbContext
            //ICourseRepository courseRepository,
           /* ICompanyRepository companyRepository, IStockPriceRepository stockPriceRepository*/) : base((DbContext)dbContext)
        {
            //Courses = courseRepository;
            //Companies = companyRepository;
            //StockPrice = stockPriceRepository;
        }
    }
}
