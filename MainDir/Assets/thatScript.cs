using System;
using UnityEngine;
using System.Collections;

public class thatScript : ScriptableObject {


 public static   int windowWidth = 800;// Screen.currentResolution.width;
	 public static  int windowHeight = 600;//Screen.currentResolution.height;
	    public    Vector2 gameRes = new Vector2(windowWidth, windowHeight);
	    public   uint[] myUint; //for collision sampling
	   public   Boolean reDraw = true;        
	  public   int coordY, coordX, lastY, lastX, counterX, counterY;

	   public   int tileHeight, tileWidth; //these are the same, condense later
	   

	   public   void setup()
	   {

	   }

	   public   void refreshSize() //call after changing resolution or tiles will still scale to old res
	   {
		windowWidth = Screen.currentResolution.width;
		windowHeight =Screen.currentResolution.height;
	  gameRes = new Vector2(windowWidth, windowHeight);
	  setTileSize();  //update tile sizes according to new res
	//  Actor.updateStep(); //update step size according to new res
//TODO if player is not centered on rectangle, then center him.  needed for if res changes, or errors will accumulate over time
	   }

	   public   void setTileSize()  //tiles should be 40x40 in 800x600
	   {
		   tileHeight = windowHeight/60;  //4:3 ratio to preserve tiles as square
		   tileWidth = windowWidth/80;
	   }

	   public   int getTileLength()
	   {
		   return tileHeight;
	   }

	 


  public   void layoutTiles()
	   {
		Debug.Log("Starting to layout tiles");
        Debug.Log(Lists.TileList.Count);
		/*   foreach (Tile tile in Lists.TileList)
		   {
			   tile.isActive = false;
		   }
		   GarbageCollection.CollectGarbage(); //removes inactive tiles and resets TileList
		   Lists.TileList.Clear();//clean out the list to prevent excessive buildup
*/
		   int count = 0;
		   int totalCount = 60*45; //300. Total number of tiles.
		   while (count != totalCount)
		   {
			   count++;
			  Tile tile = new Tile(count);
		       ScriptableObject.CreateInstance(Tile tile)
		       
			   Lists.TileList.Add(tile);
		   }
		   
		   foreach (Tile tile in Lists.TileList)   //add elses you fuckwad //Done :^)
		   {
			   if (!tile.isInitialized)
			   {
				   
				   tile.isInitialized = true;
				   tile.isActive = true; //sets tile as active so it isnt removed by garbage collector
				   tile.coordX = tileWidth*counterX;
				   tile.coordY = tileWidth*counterY;
				   counterX++;
				   //counterY++; <- broke it, keeping as a reminder of misdeeds past
				   if (counterX > 58)
				   {
					   counterX = 0;
					   counterY++;
				   }

				   tile.coordX -= tileWidth/2;
				   tile.coordY -= tileHeight/2; //adjust for xna being stupid and positioning by top-left corner
				   tile.centerCoord.x = tile.coordX + tileWidth/2; // center is at 20x20 relative in 800x600  
				   tile.centerCoord.y = tile.coordY + tileHeight/2;
					   //maybe ditch this or switch to two int's instead of vector
				   //Sample the color of the collision map at the center point of the tile and determine tile type
				   // ImageLoader.st_00.GetData(0, new Rectangle(tile.coordX+tileWidth/2, tile.coordY+tileHeight/2, 1, 1),myUint , 0, 1);  //set tile type according to data found //TODO: REENABLE
				   //Determine whether tile is passable based on second collision map
				   //Draw tiles on top of everything and unload maps to save memory
			   }

		   } //end of foreach
		   count = 0;
			Debug.Log("Done Generating Tiles!");
			Debug.Log(Lists.TileList.Count + " at end.");

	   }

   public thatScript()
    {
        layoutTiles();
    }






	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
