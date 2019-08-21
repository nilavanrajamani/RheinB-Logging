using EarlyInitializationSample.Data.Interfaces;
using EarlyInitializationSample.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyInitializationSample.Data
{
    public class DataRepositoryCatalog : IDataRepositoryCatalog
    {
        private readonly ILogger logger;
        private DbContextCatalog dbContextCatalog;
        private IRepository<Person> _personRepository;
        private IRepository<Address> _addressRepository;
        private IRepository<Company> _companyRepository;

        public DataRepositoryCatalog(ILogger logger)
        {
            dbContextCatalog = new DbContextCatalog();
            this.logger = logger;
        }
        public IRepository<Person> PersonRepository
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository = new Repository<Person>(dbContextCatalog, logger);
                }
                return _personRepository;
            }
        }

        public IRepository<Address> AddressRepository
        {
            get
            {
                if (_addressRepository == null)
                {
                    _addressRepository = new Repository<Address>(dbContextCatalog, logger);
                }
                return _addressRepository;
            }
        }

        public IRepository<Company> CompanyRepository
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new Repository<Company>(dbContextCatalog, logger);
                }
                return _companyRepository;
            }

        }
    }
}
