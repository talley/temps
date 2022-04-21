using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transfer.Helpers
{
    public static class MapHelper
    {
        public static IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ITransfer, TransferRepository>();
            });

            // only during development, validate your mappings; remove it before release
            configuration.AssertConfigurationIsValid();

            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            IMapper mapper = configuration.CreateMapper();
            return mapper;
        }
    }
}
