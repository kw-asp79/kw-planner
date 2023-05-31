using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlingLibrary
{
    public class CrawlingStatus
    {
        public enum Status
        {
            BeforeLogin,
            LoginProcess,
            LoginSuccess,
            LoginFailure,
            CrawlingSuccess,
            CrawlingError,
            AllSuccess
        }



    }
}
