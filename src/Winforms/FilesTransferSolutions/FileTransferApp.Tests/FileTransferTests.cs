using FilesTransferApp.Core.Interfaces;
using FilesTransferApp.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesTransferApp.Infrastructure.Exts;

namespace FileTransferApp.Tests
{
    [TestClass]
    public class FileTransferTests
    {
        private ITransfer _transfer = new TransferRepository();

        [TestMethod]
        public async Task Transfer_Files_Must_Pass()
        {
            var exception = new Exception();
            var sourcePath = @"C:\Users\ourota\Downloads\Transfer\Files";
            var destinationPath = @"C:\Users\ourota\Downloads\Transfer\output";
            var folders=new List<string> { sourcePath, destinationPath };
            try
            {
               await _transfer.TransferFilesAsync(folders);
            }
            catch (Exception ex)when(ex!=null)
            {
                exception = ex;
            }
            Assert.IsNull(exception);
        }

        [TestMethod]
        public async Task Transfer_Files_Must_Fail()
        {
            var exception = new Exception();
            var sourcePath = @"c:\temp\files";
            var destinationPath = @"c:\temp\files\output";
            var folders = new List<string> { sourcePath, destinationPath };
            try
            {
                await _transfer.TransferFilesAsync(folders);
            }
            catch (Exception ex) when (ex != null)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
        }

    }
}
