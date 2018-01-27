
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DNAwesome
{
	public class DNAExpresser : MonoBehaviour
	{

		public Text A;
		public Text B;
		public Text C;
		public DNAController DNAController;

		// Use this for initialization
		void Start()
		{
			DNAController.DNAUpdated += DNAController_DNAUpdated;
		}

		// Update is called once per frame
		void Update()
		{

		}

		private void DNAController_DNAUpdated(object sender, System.EventArgs e)
		{
			var dna = DNAController.DNA;
			A.text = dna.GeneList[0].AlleleList[0] + "   " + dna.GeneList[0].AlleleList[1];
			B.text = dna.GeneList[1].AlleleList[0] + "   " + dna.GeneList[1].AlleleList[1];
			C.text = dna.GeneList[2].AlleleList[0] + "   " + dna.GeneList[2].AlleleList[1];
		}
	}
}

