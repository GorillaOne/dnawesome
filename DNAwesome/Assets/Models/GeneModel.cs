using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNAwesome.Models
{
    [Serializable]
    public class GeneModel : Model
    {
        public List<AlleleModel> AlleleList = new List<AlleleModel>();
        public GeneSet GeneSet;
    }
}
