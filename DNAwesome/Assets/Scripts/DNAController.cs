using DNAwesome.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DNAwesome
{
	public class DNAController : MonoBehaviour
	{
		DnaModel _myDna;
		public DnaModel DNA
		{
			get
			{
				return _myDna;
			}
		}
		public event EventHandler DNAUpdated;
		public CompleteGenome CompleteGenome; 

		// Use this for initialization
		void Start()
		{
			_myDna = GenerateDefaultDNA();
			var otherDna = GenerateDefaultDNA();
			SmashDNA(otherDna); 
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void SetDNA(DnaModel dnaModel)
		{
			_myDna = dnaModel;
		}

		public void SmashDNA(DnaModel otherDna)
		{
			//We assume that everyone has the same genes. If they don't, shit breaks. Get real. Deal with it. 

			if (_myDna == null)
			{
				throw new System.Exception("WHY YOU GOT NO DNA FOO!? P.S. You need to have SetDNA before you call this method.");
			}
			if (_myDna.GeneList.Count != otherDna.GeneList.Count)
			{
				//Make genius baby. 
				throw new Exception("Number of Genes must match, will later add exception handling since we may want to change this value often as we add new genes.");
			}

			var newDna = new DnaModel();
			for (int i = 0; i < _myDna.GeneList.Count; i++)
			{
				var myGene = _myDna.GeneList[i];
				var theirGene = otherDna.GeneList[i];

				var newGene = new GeneModel();
				newGene.AlleleList.Add(SplitTheGene(myGene));
				newGene.AlleleList.Add(SplitTheGene(theirGene));

				newDna.GeneList.Add(newGene);
			}

			if (DNAUpdated != null)
			{
				DNAUpdated.Invoke(this, new EventArgs());
			}
		}

		AlleleModel SplitTheGene(GeneModel gene)
		{
			//To Implement: Awesome cracking sounds. 
			int rand = (int)Math.Round(UnityEngine.Random.value);
			return gene.AlleleList[rand];
		}

		private DnaModel GenerateDefaultDNA()
		{
			DnaModel newDna = new DnaModel(); 
			foreach(var set in CompleteGenome.TheGenome)
			{
				int max = set.allAlleles.Count;
				var allele1 = UnityEngine.Random.Range(0, max);
				var allele2 = UnityEngine.Random.Range(0, max);
				var newGene = new GeneModel();
				newGene.AlleleList.Add(set.allAlleles[allele1]);
				newGene.AlleleList.Add(set.allAlleles[allele2]);
				newDna.GeneList.Add(newGene); 
			}
			return newDna; 
		}
	}
}

