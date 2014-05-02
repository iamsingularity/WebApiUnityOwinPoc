using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsLogger
{
    public interface IUnitOfWork : IDisposable
    {
        string HelloFromUnitOfWorkExample();

        void Deposit(decimal depositAmount);

    }
}
