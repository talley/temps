
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesTransferApp.Infrastructure.Repositories
{
    public class TransferRepository : ITransfer
    {
        public void TransferFiles(IList<string> files)
        {
            throw new NotImplementedException();
        }

        public async Task TransferFilesAsync(IList<string> files)
        {
            if(files == null || !files.Any())
            {
                throw new ArgumentNullException("There no files to process.");
            }
            else
            {
                var sourcePath=files.FirstOrDefault();
                var destinationPath = files.LastOrDefault();
                using (var SourceStream = File.Open(sourcePath!, FileMode.Open))
                {
                    using (var DestinationStream = File.Create(destinationPath!))
                    {
                        await SourceStream.CopyToAsync(DestinationStream).ConfigureAwait(false);
                    }
                }
            }

        }
    }
}
