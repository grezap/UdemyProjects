using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer.Model.TestMySql
{
    public class Before
    {
        public int id { get; set; }
        public string descr { get; set; }
        public long descr_date { get; set; }
        public int hasdescr { get; set; }
        public float doubledescr { get; set; }
        public decimal decimaldescr { get; set; }
        public int bigintdescr { get; set; }
    }

}
