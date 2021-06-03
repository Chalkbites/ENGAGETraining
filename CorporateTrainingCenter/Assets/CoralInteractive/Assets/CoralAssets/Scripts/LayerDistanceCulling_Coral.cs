using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerDistanceCulling_Coral : MonoBehaviour {

	[SerializeField] float ObjectCullDistance;

	// Use this for initialization
	void Start () {
		var distances = new float[32];
		distances[8] = ObjectCullDistance;
		GetComponent<Camera>().layerCullDistances = distances;
		GetComponent<Camera> ().layerCullSpherical = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
