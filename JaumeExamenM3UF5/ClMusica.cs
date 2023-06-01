using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaumeExamenM3UF5
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    internal class ClMusica
    {
        public string song { get; set; }
        public string emotion { get; set; }
        public object tpc { get; set; }
    }
            
        
    
}
