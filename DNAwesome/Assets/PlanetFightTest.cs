using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DNAwesome.Models
{
    public class PlanetFightTest : MonoBehaviour {
        public bool run = false;

        public PlanetModel planet;
        public DnaModel DNA;
        public PlanetFightResult result;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (run)
            {
                RunPlanet();
                run = false;
            }
        }

        private void RunPlanet()
        {
            planet = PlanetModel.GeneratePlanet(PlanetDifficulty.BabyMode);
            result = planet.FightMe(DNA);
        }
    }
}
