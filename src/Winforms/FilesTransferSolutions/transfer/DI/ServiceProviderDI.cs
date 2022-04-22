using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transfer.DI
{
    public static class ServiceProviderDI
    {
        public static ServiceProvider GetProvider()
        {
            var serviceProvider = new ServiceCollection()
             .AddSingleton<ITransfer, TransferRepository>()
             .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
