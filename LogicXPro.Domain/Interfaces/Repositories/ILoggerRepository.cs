using LogicXPro.Domain.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Interfaces.Repositories
{
   public interface ILoggerRepository
    {
        Task<List<LogModel>> GetLogs();
    }
}
