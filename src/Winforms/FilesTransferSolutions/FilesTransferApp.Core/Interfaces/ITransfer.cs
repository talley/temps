using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesTransferApp.Core.Interfaces
{
    public interface ITransfer
    {
        Task TransferFilesAsync(IList<string> files);
        void TransferFiles(IList<string> files);
    }
}
