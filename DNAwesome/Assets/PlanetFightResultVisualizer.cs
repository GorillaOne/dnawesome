using DNAwesome.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFightResultVisualizer : MonoBehaviour {
    public PlanetFightResult result;
    public StatFightDisplay statdisplayPrefab;
    private List<GameObject> challengeResultObjects;
	// Use this for initialization
	void Start () {
        challengeResultObjects = new List<GameObject>();
        this.enabled = false;
	}

    private void OnEnable()
    {
        if (challengeResultObjects == null)
            return;
        int i = 0;
        challengeResultObjects.Clear();
        foreach(ChallengeResult cr in result.challengeResult)
        {
            StatFightDisplay sfd = Instantiate(statdisplayPrefab,transform);
            challengeResultObjects.Add(sfd.gameObject);
            sfd.ChallengeResult = cr;
            RectTransform rt = sfd.transform as RectTransform;
            rt.localPosition += Vector3.up * i * 40;
            i++;
        }
    }

    private void OnDisable()
    {
        foreach(GameObject go in challengeResultObjects)
        {
            Destroy(go);
        }
        challengeResultObjects.Clear();
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
