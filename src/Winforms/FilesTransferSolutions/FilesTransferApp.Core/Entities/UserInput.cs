using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesTransferApp.Core.Entities
{
    public record UserInput
    {
        public string Source { get; set; }
        public string Destination { get; set; }

    }
}
