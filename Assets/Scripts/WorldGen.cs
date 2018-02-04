using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

	public GameObject grass_prefab;
	public GameObject dirt_prefab;
	
	public float blockSize;
	public float holeChance;
	public int playingfieldsize_x, playingfieldsize_y;
	void Start () {
	    // TODO REMOVE THIS BEFORE RELEASE
		UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));

		// Define Block Array
		Block[,] bl = new Block[playingfieldsize_x, playingfieldsize_y];
		Debug.Log(bl.Length);

		// Generate World
		for(int x = 0;x<playingfieldsize_x-1;x++){
			for(int y = 0;y<playingfieldsize_y-1;y++){
				bl[x,y] = new Block();
				if(y == playingfieldsize_y-2) bl[x,y].setType(1);
				else{
					if(Random.value <= holeChance && x != 0 && x != playingfieldsize_x-2 && y != 0) bl[x,y].setType(0);
					else bl[x,y].setType(2);
				}
			}
		}
		
		// Instantiate blocks
		for(int x = 0;x<playingfieldsize_x-1;x++){
			for(int y = 0;y<playingfieldsize_y-1;y++){
				if(bl[x,y].getType() == 1) MonoBehaviour.Instantiate(grass_prefab,new Vector3(x*blockSize,y*blockSize,1),new Quaternion(0,0,0,0));
				else if(bl[x,y].getType() == 0 ) ;
				else MonoBehaviour.Instantiate(dirt_prefab,new Vector3(x*blockSize,y*blockSize,1),new Quaternion(0,0,0,0));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}

