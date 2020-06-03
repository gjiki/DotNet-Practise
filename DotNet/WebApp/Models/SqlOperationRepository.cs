using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class SqlOperationRepository : IOperationRepository
    {
        private readonly AppDbContext _context;

        public SqlOperationRepository(AppDbContext context)
        {
            this._context = context;
        }

        public Operation Add(Operation operation)
        {
            _context.Operations.Add(operation);
            operation.Date = DateTime.Now;
            _context.SaveChanges();
            return operation;
        }

        public Operation Delete(int id)
        {
            Operation operation = _context.Operations.FirstOrDefault(m => m.ID == id);
            if (operation != null)
            {
                _context.Operations.Remove(operation);
                _context.SaveChanges();
            }
            return operation;
        }

        public IEnumerable<Operation> GetAllOperations()
        {
            return _context.Operations;
        }

        public Operation GetOperation(int id)
        {
            return _context.Operations.FirstOrDefault(m => m.ID == id);
        }

        public Operation Update(Operation operation)
        {
            operation.Date = DateTime.Now;
            var curr = _context.Operations.Attach(operation);
            curr.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return operation;
        }
    }
}
