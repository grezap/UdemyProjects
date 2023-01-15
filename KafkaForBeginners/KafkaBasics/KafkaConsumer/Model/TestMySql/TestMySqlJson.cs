using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer.Model.TestMySql
{

    public class TestMySqlJson
    {
        public Before before { get; set; }
        public After after { get; set; }
        public Source source { get; set; }
        public string op { get; set; }
        public long ts_ms { get; set; }
        public object transaction { get; set; }
    }


}
