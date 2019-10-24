using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrizeDrawTool
{
    public class Spinner
    {
        private static char[] spinner = { '|', '/', '-', '\\' };

        private int _index = 0;

        public void PrintToConsole()
        {
            Console.Write(spinner[_index]);

            _index = (_index < spinner.Length - 1) ? _index + 1 : 0;

            Task.Delay(100).Wait();

            Console.Write('\b');
        }
    }
}
