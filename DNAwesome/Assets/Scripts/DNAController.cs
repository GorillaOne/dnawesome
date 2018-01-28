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
		public Dictionary<AttributeType, int> CharacterAttributes = new Dictionary<AttributeType, int>();

		// Use this for initialization
		void Start()
		{
			LoadDefaultAttributes();
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void ResetDNA()
		{
			_myDna = GenerateDefaultDNA();
			SumAttributes(); 
			if (DNAUpdated != null)
			{
				DNAUpdated(this, new EventArgs());
			}
		}

		public void SetDNA(DnaModel dnaModel)
		{
			_myDna = dnaModel;
			SumAttributes();
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
				newGene.GeneSet = myGene.GeneSet;
				newDna.GeneList.Add(newGene);
			}
			_myDna = newDna;
			SumAttributes(); 

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
			foreach (var set in CompleteGenome.TheGenome)
			{
				int max = set.allAlleles.Count;
				var allele1 = UnityEngine.Random.Range(0, max);
				var allele2 = UnityEngine.Random.Range(0, max);
				var newGene = new GeneModel();
				newGene.AlleleList.Add(set.allAlleles[allele1]);
				newGene.AlleleList.Add(set.allAlleles[allele2]);
				newGene.GeneSet = set;
				newDna.GeneList.Add(newGene);
			}
			return newDna;
		}

		private void LoadDefaultAttributes()
		{
			foreach (var value in Enum.GetNames(typeof(AttributeType)))
			{
				var attType = (AttributeType)Enum.Parse(typeof(AttributeType), value);
				CharacterAttributes.Add(attType, 0);
			}
		}

		private void SumAttributes()
		{
			ClearAttributes(); 

			foreach (var gene in _myDna.GeneList)
			{
				gene.AlleleList.Sort((a, b) =>
				{
					return a.GeneOrder.CompareTo(b.GeneOrder);
				});

				foreach (var att in gene.AlleleList[0].AttributeList)
				{
					CharacterAttributes[att.Attribute] += att.Strength;
				}
			}
		}

		private void ClearAttributes()
		{
			List<AttributeType> keys = new List<AttributeType>(CharacterAttributes.Keys); 

			foreach (var key in keys)
			{
				CharacterAttributes[key] = 0;
			}
		}

	}
}

