using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer.Model
{
    public class TestJson
    {
        public object before { get; set; }
        //public After after { get; set; }
        public string after { get; set; }
        public object patch { get; set; }
        public object filter { get; set; }
        public Updatedescription updateDescription { get; set; }
        public Source source { get; set; }
        public string op { get; set; }
        public long ts_ms { get; set; }
        public object transaction { get; set; }
    }
}
