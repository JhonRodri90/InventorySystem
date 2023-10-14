using Context.Entities;
using Repository.GenericRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SpecificRepository.Interfaces
{
    public interface IwineryRepository : IGenericRepository<Winery>
    {
    }
}
