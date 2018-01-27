using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNAwesome.Models
{
    [Serializable]
    public class DnaModel : Model
    {
        public List<GeneModel> GeneList = new List<GeneModel>(); 
    }
}
