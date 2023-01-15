using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer.Model.TestMySql
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
        public string table { get; set; }
        public int server_id { get; set; }
        public string gtid { get; set; }
        public string file { get; set; }
        public int pos { get; set; }
        public int row { get; set; }
        public int thread { get; set; }
        public string query { get; set; }
    }
}
