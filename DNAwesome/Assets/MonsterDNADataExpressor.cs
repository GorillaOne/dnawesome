﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DNAwesome.Models
{
    public class MonsterDNADataExpressor : MonoBehaviour {

        public DnaModel myDNA;
        public SpriteRenderer Head;
        public SpriteRenderer Body;
        public SpriteRenderer Legs;
        public SpriteRenderer Eyes;
        public SpriteRenderer Arm;
        public SpriteRenderer OtherArm;
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            foreach(GeneModel gs in myDNA.GeneList)
            {
                switch (gs.GeneSet.GenePart)
                {
                    case PartValue.Body:
                        Body.sprite = gs.AlleleList[0].sprite;
                        break;
                    case PartValue.Head:
                        Head.sprite = gs.AlleleList[0].sprite;
                        break;
                    case PartValue.Eyes:
                        Eyes.sprite = gs.AlleleList[0].sprite;
                        break;
                    case PartValue.Arms:
                        Arm.sprite = gs.AlleleList[0].sprite;
                        OtherArm.sprite = gs.AlleleList[0].sprite;
                        break;
                    case PartValue.Legs:
                        Legs.sprite = gs.AlleleList[0].sprite;
                        break;
                }
            }
        }
    }
}
