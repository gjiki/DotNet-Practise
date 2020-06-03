using System.Collections.Generic;

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
