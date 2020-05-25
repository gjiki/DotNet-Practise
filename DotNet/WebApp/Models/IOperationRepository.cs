using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public interface IOperationRepository
    {
        Operation GetOperation(int id);
        IEnumerable<Operation> GetAllOperations();
        Operation Add(Operation operation);
        Operation Update(Operation operation);
        Operation Delete(int id);
    }
}
