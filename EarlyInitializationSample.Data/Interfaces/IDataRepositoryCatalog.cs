using EarlyInitializationSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlyInitializationSample.Data.Interfaces
{
    public interface IDataRepositoryCatalog
    {
        IRepository<Person> PersonRepository { get; }
        IRepository<Address> AddressRepository { get; }
        IRepository<Company> CompanyRepository { get; }
    }
}
