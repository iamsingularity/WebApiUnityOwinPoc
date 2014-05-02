using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsLogger
{
    [UnityIoCTransientLifetime]
    public class UnitOfWork : IUnitOfWork
    {
        public string HelloFromUnitOfWorkExample()
        {
            return "HelloFromUnitOfWorkExample";
        }

        public void Deposit(decimal depositAmount)
        {
            var deposit = depositAmount;
        }

        public void Dispose()
        {
            
        }
    }
}
