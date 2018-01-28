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

        public List<int> Stats; //Indexed by AttributeType

        public void UpdateStats()
        {
            Stats = new List<int>() { 1, 1, 1, 1, 1, 1 };
            foreach(GeneModel gm in GeneList)
            {
                foreach(AlleleModel am in gm.AlleleList)
                {
                    foreach(var al in am.AttributeList)
                    {
                        Stats[(int)al.Attribute] += al.Strength;
                    }
                }
            }

            for(int i=0; i<Stats.Count;i++)
            {
                Stats[i] = Math.Max(0, Stats[i]);
            }
        }
    }
}
