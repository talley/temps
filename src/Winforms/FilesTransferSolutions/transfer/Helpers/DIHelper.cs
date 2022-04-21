
using Ninject.Modules;
using Ninject;

namespace transfer.Helpers
{
    public static class DIHelper
    {
        public static void Configure()
        {
            Bind<ITransfer>().To<TransferRepository>();
        }
    }
}
