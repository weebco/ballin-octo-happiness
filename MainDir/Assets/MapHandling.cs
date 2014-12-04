using UnityEngine;
using System.Collections;

using System;
using UnityEngine;
using System.Collections;

public class MapHandling : MonoBehaviour
{

	private static int windowWidth = 800;// Screen.currentResolution.width;
	private static int windowHeight = 600;//Screen.currentResolution.height;
	   private static Vector2 gameRes = new Vector2(windowWidth, windowHeight);
	   private static uint[] myUint; //for collision sampling
	   public static Boolean reDraw = true;        
	  public static int coordY, coordX, lastY, lastX, counterX, counterY;

	   public static int tileHeight, tileWidth; //these are the same, condense later
	   

	   public static void setup()
	   {

	   }

	   public static void refreshSize() //call after changing resolution or tiles will still scale to old res
	   {
		windowWidth = Screen.currentResolution.width;
		windowHeight =Screen.currentResolution.height;
	  gameRes = new Vector2(windowWidth, windowHeight);
	  setTileSize();  //update tile sizes according to new res
	//  Actor.updateStep(); //update step size according to new res
//TODO if player is not centered on rectangle, then center him.  needed for if res changes, or errors will accumulate over time
	   }

	   public static void setTileSize()  //tiles should be 40x40 in 800x600
	   {
		   tileHeight = windowHeight/60;  //4:3 ratio to preserve tiles as square
		   tileWidth = windowWidth/80;
	   }

	   public static int getTileLength()
	   {
		   return tileHeight;
	   }

	 


  public static void layoutTiles()
	   {
		Debug.Log("Starting to layout tiles");
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
		   reDraw = false;
			Console.WriteLine("Done Generating Tiles!");
			Console.WriteLine(Lists.TileList.Count);

	   }







	   
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

