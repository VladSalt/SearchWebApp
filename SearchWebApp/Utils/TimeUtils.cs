using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchWebApp.Utils
{
    public static class TimeUtils
    {
        /// <summary>
        /// Конвертирование даты с Unix в DateTime
        /// </summary>
        /// <param name="unixTime"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(int unixTime)
        {
            return DateTime.UnixEpoch.AddSeconds(unixTime);
        }
    }
}
