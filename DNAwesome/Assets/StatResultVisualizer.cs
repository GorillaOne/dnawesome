using DNAwesome.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatResultVisualizer : MonoBehaviour {
    public PointResult result;
    public Image image;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (result)
        {
            case PointResult.Failed:
                image.color = Color.red;
                break;
            case PointResult.Passed:
                image.color = Color.white;
                break;
            case PointResult.Lucky:
                image.color = Color.green;
                break;
        }
    }
}
