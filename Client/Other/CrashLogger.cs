using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Client.Other
{
    class CrashLogger
    {
        public async Task CreateCrashLog(String CrashMessage, IDictionary CrashError)
        {   
            using (Stream st = new FileStream(@".\Crashes\" + DateTime.Now + ".txt", FileMode.CreateNew))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(CrashMessage);
                sb.Append("\n");
                sb.Append(CrashError);
                Byte[] bytes = Encoding.ASCII.GetBytes(sb.ToString());
                await st.WriteAsync(bytes,0, bytes.Length);
            }
        }
    }
}
