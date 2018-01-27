using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DNAwesome.Models
{
    [CreateAssetMenu(fileName = "NewGeneSet", menuName = "DNAwesome/Gene Set", order = 0)]
    public class GeneSet : ScriptableObject {
        public List<AlleleModel> allAlleles;

        
    }
}
