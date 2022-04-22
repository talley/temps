




namespace FilesTransferApp.Infrastructure.Repositories
{
    public class TransferRepository : ITransfer
    {
        public void TransferFiles(IList<string> files)
        {

        }

        public async Task TransferFilesAsync(IList<string> files)
        {
            try
            {
                if (files?.Any() != true)
                {
                    throw new ArgumentNullException("There no files to process.");
                }
                else
                {
                    var sourcePath = files.FirstOrDefault();
                    var destinationPath = files.LastOrDefault();
                    using (BlockingCollection<string> filesQueue = new BlockingCollection<string>())
                    {
                        var populateFiles = Task.Run(() =>
                        {
                            filesQueue.Add(sourcePath!);
                            filesQueue.Add(destinationPath!);
                            filesQueue.CompleteAdding();
                        });
                        var consumeFiles = Task.Run(async () =>
                          {
                              try
                              {
                                  var bufferSize = 1024 * 128;
                                  var queueFiles = filesQueue.GetConsumingEnumerable();
                                  var queueSourcePath= queueFiles.FirstOrDefault();
                                  var queueDestinationPath= queueFiles.LastOrDefault();
                                  using (var SourceStream = File.Open(queueSourcePath!, FileMode.Open,FileAccess.ReadWrite))
                                  {
                                      using (var DestinationStream = File.Create(queueDestinationPath!))
                                      {
                                          await SourceStream.CopyToAsync(DestinationStream, bufferSize).ConfigureAwait(false);
                                      }
                                  }
                              }
                              catch (InvalidOperationException ex) when(ex!=null)
                              {
                                  throw ex;
                              }
                          });
                        await Task.WhenAll(populateFiles, consumeFiles);
                    }
                }
            }
            catch (Exception ex) when(ex!=null)
            {
                ex.LogExceptionToDatabase();
                throw;
            }

        }
    }
}
