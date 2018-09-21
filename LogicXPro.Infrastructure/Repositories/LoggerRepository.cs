using LogicXPro.Domain;
using LogicXPro.Domain.BusinessModel;
using LogicXPro.Domain.Interfaces.Repositories;
using LogicXPro.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Infrastructure.Repositories
{
    public class LoggerRepository: ILoggerRepository
    {
        private DbContext _context;

        public LoggerRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<List<LogModel>> GetLogs()
        {
            var logs = await _context.Set<Log>().ToListAsync();
            return logs.Select(l => new LogModel().Assign(l)).ToList();
        }
    }
}
