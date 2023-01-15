using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer.Model
{
    public class Source
    {
        public string version { get; set; }
        public string connector { get; set; }
        public string name { get; set; }
        public long ts_ms { get; set; }
        public string snapshot { get; set; }
        public string db { get; set; }
        public object sequence { get; set; }
        public string rs { get; set; }
        public string collection { get; set; }
        public int ord { get; set; }
        public object lsid { get; set; }
        public object txnNumber { get; set; }
    }
}
