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
        public long? descr_date { get; set; }
        public bool? hasdescr { get; set; }
        public double? doubledescr { get; set; }
        public double? decimaldescr { get; set; }
        public long? bigintdescr { get; set; }
    }

}
