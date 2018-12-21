using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TwitterTesting
{
    public class Log
    {
        private static Log _log;
        public static Log GetLog()
        {
            //return _log ?? (_log = new Log());
            if (_log == null)
                _log = new Log();
            return _log;
        }

        public void Info(string message)
        {
            StreamWriter writer = new StreamWriter(@"C:\Users\Public\Documents\log.txt", true);
            writer.WriteLine(message);
            writer.Close();
        }

        public void Trace()
        {

        }

        //логирование в консоль
        //имена веб-элементов
        //скриншоты при ошибке через try-catch или в setup
        //div[@name='...' and '$$имя_элемента']
    }
}
