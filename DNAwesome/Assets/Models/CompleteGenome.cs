using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DNAwesome.Models
{
    [CreateAssetMenu(fileName = "CompleteGenome", menuName ="DNAwesome/CompleteGenome", order = 2)]
    public class CompleteGenome : ScriptableObject
    {
        public List<GeneSet> TheGenome;

    }
}
