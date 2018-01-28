using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwipeBehaviour : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public Vector3 StartPosition;
    public float DistanceFromStart { get { return StartPosition.x - transform.localPosition.x; } }
    public float thresholdDistance;
    public float maxRotationAtThreshold;
    public UnityEvent Like;
    public UnityEvent Reject;
    public bool snapback;
    public bool flyoff;
    public float snapbacktime;
    private float elapsedtime;
    private Vector3 DropPosition;
    private Quaternion DropRotation;
    private Vector3 FlyoffSecond;

    // Use this for initialization
    void Start () {
        StartPosition = transform.localPosition;
        snapback = false;
        elapsedtime = 0;
        FlyoffSecond = new Vector3(1000, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {
		if(snapback)
        {
            elapsedtime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(DropPosition, StartPosition, elapsedtime/snapbacktime);
            transform.localRotation = Quaternion.Lerp(DropRotation, Quaternion.Euler(0,0,0), elapsedtime / snapbacktime);
            if(elapsedtime > snapbacktime)
            {
                snapback = false;
                elapsedtime = 0;
            }
        }
        if(flyoff)
        {
            elapsedtime += Time.deltaTime;
            transform.localPosition += Time.deltaTime * FlyoffSecond;
            if(elapsedtime>snapbacktime)
            {
                Destroy(gameObject);
            }
        }
	}

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += new Vector3 (eventData.delta.x,eventData.delta.y, 0);
        transform.localRotation = Quaternion.Euler(0,0,DistanceFromStart / thresholdDistance * maxRotationAtThreshold);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Math.Abs(DistanceFromStart) > thresholdDistance)
        {
            if (transform.localPosition.x - StartPosition.x < 0)
            {
                Debug.Log("Mate!!!");
                Like.Invoke();
                flyoff = true;
                FlyoffSecond *= -1;
            }
            else
            {
                Debug.Log("Rejected");
                Reject.Invoke();
                flyoff = true;
            }
        }
        else
            SnapBack();
    }

    private void SnapBack()
    {
        snapback = true;
        DropPosition = transform.localPosition;
        DropRotation = transform.localRotation;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
