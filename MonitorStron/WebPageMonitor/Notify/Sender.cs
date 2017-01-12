using Comparator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPageMonitor.Notify
{
    interface Sender
    {
        void send(Diff diff);
     
    }
}
