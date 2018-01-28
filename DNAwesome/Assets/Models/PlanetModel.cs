using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DNAwesome.Models
{
    [Serializable]
    public class PlanetModel : Model
    {
        public List<PlanetChallenge> challenges;
        
        public static PlanetModel GeneratePlanet(PlanetDifficulty pd)
        {
            PlanetModel pm = new PlanetModel();
            pm.challenges = new List<PlanetChallenge>();
            int challenge = (int)pd;
            while(challenge>0)
            {
                int random = UnityEngine.Random.Range(1,challenge+1);
                challenge -= random;
                pm.challenges.Add(new PlanetChallenge(random));
            }
            return pm;
        }

        public PlanetFightResult FightMe(DnaModel monsterToFight)
        {
            monsterToFight.UpdateStats();
            PlanetFightResult result = new PlanetFightResult();
            List<int> stats = monsterToFight.Stats;
            foreach(PlanetChallenge pc in challenges)
            {
                if(stats[(int)pc.type]>=pc.Difficulty)
                {
                    result.challengeResult.Add(new ChallengeResult(pc,true));
                }
                else
                {
                    int luck = 0;
                    while(UnityEngine.Random.Range(0,2)==1)
                    {
                        luck++;
                    }
                    result.challengeResult.Add(new ChallengeResult(pc, stats[(int)pc.type],luck));
                }
            }
            return result;
        }

    }

    [Serializable]
    public enum PlanetDifficulty
    {
        CakeWalk = 2,
        BabyMode = 4,
        MaybeNotEasy = 6,
        UhOh = 8,
        BuckleUrSafteyBelts = 10
    }

    [Serializable]
    public class PlanetChallenge
    {
        public AttributeType type;
        public int Difficulty;

        public PlanetChallenge(int Difficulty)
        {
            this.Difficulty = Difficulty;
            type = (AttributeType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(AttributeType)).Length);
        }
    }

    [Serializable]
    public class PlanetFightResult
    {
        public List<ChallengeResult> challengeResult;
        public bool Success { get
            {
                foreach(ChallengeResult cr in challengeResult)
                {
                    if (cr.pointresult.Contains(PointResult.Failed))
                        return false;
                }
                return true;
            }
        }

        public PlanetFightResult()
        {
            challengeResult = new List<ChallengeResult>();
        }
    }

    [Serializable]
    public class ChallengeResult
    {
        public PlanetChallenge theChallenge;
        public List<PointResult> pointresult;

        public ChallengeResult(PlanetChallenge pc, int statcount,int luck)
        {
            theChallenge = pc;
            pointresult = new List<PointResult>();
            int i = 0;
            for(i=0; i<statcount;i++)
            {
                pointresult.Add(PointResult.Passed);
            }
            for(;i<pc.Difficulty;i++)
            {
                if(luck>0)
                {
                    luck--;
                    pointresult.Add(PointResult.Lucky);
                }
                else
                    pointresult.Add(PointResult.Failed);
            }
        }

        public ChallengeResult(PlanetChallenge pc, bool passed)
        {
            pointresult = new List<PointResult>();
            theChallenge = pc;
            for(int i=0; i<pc.Difficulty; i++)
            {
                pointresult.Add((passed) ? PointResult.Passed : PointResult.Failed);
            }
        }
    }

    [Serializable]
    public enum PointResult
    {
        Failed,
        Passed,
        Lucky
    }
}