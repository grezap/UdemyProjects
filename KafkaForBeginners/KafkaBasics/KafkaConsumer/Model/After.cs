using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer.Model
{
    public class After
    {
        public AfterId _id { get; set; }
        
        //public JObject _id { get; set; }
        public string desc { get; set; }
        public string subscription { get; set; }
        public List<string> apps { get; set; }
    }
}
