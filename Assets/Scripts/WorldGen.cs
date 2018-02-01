using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

	public GameObject grass_prefab;
	// Use this for initialization
	void Start () {
		
		MonoBehaviour.Instantiate(grass_prefab,new Vector3(1,1,1),new Quaternion(0,0,0,0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}

