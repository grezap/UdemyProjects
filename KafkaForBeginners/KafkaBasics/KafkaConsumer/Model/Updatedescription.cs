using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer.Model
{
    public class Updatedescription
    {
        public object removedFields { get; set; }
        public string updatedFields { get; set; }
        public object truncatedArrays { get; set; }
    }
}
