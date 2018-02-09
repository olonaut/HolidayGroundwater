using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

	public GameObject grass_prefab, rudi_prefab, dirt_prefab, dirtRock01_prefab;
	
	public float blockSize;
	public float holeChance;
	public float rockChance, rockMultiplyer;

	public int playingfieldsize_x, playingfieldsize_y;
	void Start () {
	    // TODO REMOVE THIS BEFORE RELEASE
		// UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));

		// Define Block Array
		Block[,] bl = new Block[playingfieldsize_x, playingfieldsize_y];
		Debug.Log(bl.Length);

		// Generate World
		for(int x = 0;x<playingfieldsize_x-1;x++){
			for(int y = 0;y<playingfieldsize_y-1;y++){
				bl[x,y] = new Block(); // Init block
				if(y == playingfieldsize_y-2) bl[x,y].setType(1); //Top is grass
				else{
					if(Random.value <= holeChance && x != 0 && x != playingfieldsize_x-2 && y != 0) bl[x,y].setType(0); // If there is a hole, set type to 1
					if(Random.Range(0,rockMultiplyer)*playingfieldsize_x <= rockChance){
						bl[x,y].setType(3);
					}
					else bl[x,y].setType(2); //Set everything else to 2
				}
			}
		}

		// Place Rudi
		bl[Random.Range(0,playingfieldsize_x),Random.Range(5,playingfieldsize_y)].setType(6);
		
		// Instantiate blocks
		for(int x = 0;x<playingfieldsize_x-1;x++){
			for(int y = 0;y<playingfieldsize_y-1;y++){
				if(bl[x,y].getType() == 1) MonoBehaviour.Instantiate(grass_prefab,new Vector3(x*blockSize,y*blockSize,1),new Quaternion(0,0,0,0));
				else if(bl[x,y].getType() == 0 ) ;
				else if(bl[x,y].getType() == 3 ) MonoBehaviour.Instantiate(dirtRock01_prefab,new Vector3(x*blockSize,y*blockSize,1),new Quaternion(0,0,0,0));
				else if(bl[x,y].getType() == 6 ) MonoBehaviour.Instantiate(rudi_prefab,new Vector3(x*blockSize,y*blockSize,1),new Quaternion(0,0,0,0));
				else MonoBehaviour.Instantiate(dirt_prefab,new Vector3(x*blockSize,y*blockSize,1),new Quaternion(0,0,0,0));
			}
		}
	}

}

