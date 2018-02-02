using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

	public GameObject grass_prefab;
	public GameObject dirt_prefab;
	
	public float blockSize;
	public int playingfieldsize_x, playingfieldsize_y;
	void Start () {

		Block[,] bl = new Block[playingfieldsize_x, playingfieldsize_y];
		Debug.Log(bl.Length);


		for(int x = 0;x<playingfieldsize_x-1;x++){
			for(int y = 0;y<playingfieldsize_y-1;y++){
				bl[x,y] = new Block();
				bl[x,y].setType(1);
			}
		}
			//bl[0,i].setType(0);
		
		for(int x = 0;x<playingfieldsize_x-1;x++){
			for(int y = 0;y<playingfieldsize_y-1;y++){
				if(y == 23) MonoBehaviour.Instantiate(grass_prefab,new Vector3(x*blockSize,y*blockSize,1),new Quaternion(0,0,0,0));
				else MonoBehaviour.Instantiate(dirt_prefab,new Vector3(x*blockSize,y*blockSize,1),new Quaternion(0,0,0,0));
			}
		}
		


		


	}
	
	// Update is called once per frame
	void Update () {
		
	}


}

