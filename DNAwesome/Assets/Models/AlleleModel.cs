using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DNAwesome.Models
{
	[Serializable]
	public class AlleleModel : Model
	{
		/// <summary>
		/// Lower = more dominant. 
		/// High = more recessive. 
		/// </summary>
		public int GeneOrder;
		public string name;
		public Sprite sprite;
		public List<AttributeHolder> AttributeList; 
	}

	[Serializable]
	public struct AttributeHolder
	{
		public AttributeType Attribute;
		public int Strength;
		public AttributeHolder(AttributeType type, int strength)
		{
			Attribute = type;
			Strength = strength; 
		}
	}

	[Serializable]
	public enum AttributeType
	{
		Beefy,
		Slick,
		Moxy,
		Woke,
		Snark,
		Mime,
		Aloof,
	}
}
