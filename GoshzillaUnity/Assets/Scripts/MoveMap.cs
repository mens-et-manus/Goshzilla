using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveMap : MonoBehaviour {
    private Vector3 distance;
    private Vector3 originalDistance;
    public Text distanceTravelled;
	// Use this for initialization
	void Start () {
        originalDistance = transform.position;
        distanceTravelled.text = "Distance Travelled: 0";
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(0f, 0f, 1f)*Time.deltaTime;
        distance = transform.position;
        distanceTravelled.text = "Distance Travelled: " + Mathf.RoundToInt((distance - originalDistance).magnitude).ToString();
	}
}
