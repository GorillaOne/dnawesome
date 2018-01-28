
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DNAwesome
{
	public class DNAExpresser : MonoBehaviour
	{
		public DNAController DNAController;
		public Text DNADisplay;

		private void Awake()
		{
			DNAController.DNAUpdated += DNAController_DNAUpdated;
		}
		// Use this for initialization
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void DNAController_DNAUpdated(object sender, System.EventArgs e)
		{
			var dna = DNAController.DNA;
			foreach(var list in dna.GeneList)
			{
				list.AlleleList.Sort((a, b) =>
				{
					return a.GeneOrder.CompareTo(b.GeneOrder);
				}); 
			}
			DNADisplay.text = "\n " + this.gameObject.name; 
			for(int i = 0; i < dna.GeneList.Count; i++)
			{
				
				var geneList = dna.GeneList[i];
				var allele1 = dna.GeneList[i].AlleleList[0];
				var allele2 = dna.GeneList[i].AlleleList[1];
				DNADisplay.text += "\n" + geneList.GeneSet.name + ": " + allele1.name + allele1.GeneOrder + "   " + allele2.name + allele2.GeneOrder; 
			}
		}
	}
}

