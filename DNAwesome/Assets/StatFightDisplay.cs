using System.Collections;
using System.Collections.Generic;
using DNAwesome.Models;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatFightDisplay : MonoBehaviour {
    public ChallengeResult ChallengeResult;
    public Text Text;
    public StatResultVisualizer StatResultPrefab;
    // Use this for initialization
    void Start () {
        int i = 0;
		foreach(PointResult pr in ChallengeResult.pointresult)
        {
            StatResultVisualizer srv = Instantiate(StatResultPrefab, transform);
            srv.result = pr;
            srv.transform.localPosition += Vector3.right * i * 40;
            i++;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Text.text = Enum.GetName(typeof(AttributeType), ChallengeResult.theChallenge.type);
	}
}
