using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesTransferApp.Infrastructure.Exts
{
    public static class ExceptionExtensions
    {
        public static void LogExceptionToDatabase(this Exception ex)
        {
            //log exception to database exception table here
            if (ex != null)
            {

            }
        }

        public static void LogExceptionToFile(this Exception ex)
        {
            //log exception to database exception table here
            if (ex != null)
            {

            }
        }

        public static bool IsNull(this Exception ex)
        {
            return ex == null && ex?.Message.Length == 0;
        }

        public static bool IsNotNull(this Exception ex)
        {
            return ex != null && ex?.Message.Length >1;
        }
    }
}
