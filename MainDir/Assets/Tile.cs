using System;
using UnityEngine;
using System.Collections;

public class Tile : ScriptableObject {

    public  enum TileTypesEnum
        {
            Black = 0,         //0,0,0
            Dirt = 1,         //127,51,0
            Grass = 2,        //76,255,0
            Road = 3,         //128,128,128
            Sand = 4,         //255,255
            ShallowWater = 5, //0,255,255
            Wall = 6,         //64,64,64
            Water = 7,        //0,0,255

           
        };

        public TileTypesEnum tileTypesEnum = new TileTypesEnum();


       new public string name;
        public Boolean isActive = false;
        public Boolean isPassable = false;
        public Boolean isEventTrigger = false;
        public Boolean isInitialized = false;
        public int eventId = 0;
        public int position;
        public int coordX, coordY;
        public int tileSizeX, tileSizeY;
        public Vector2 centerCoord = new Vector2();
        public Texture2D sprite;
        public Boolean isDrawn = false;



        public Tile(int newPosition)
        {
            position = newPosition;
            isActive = true;
            tileTypesEnum = TileTypesEnum.Water ; //TODO remove 4 and instead have it determined by color value
            Debug.Log("Gen Tile #" + position);
        }


        public void delete(Tile victimTile )
        {
             victimTile = null;
        }

        public void setPassable(Tile targetTile)
        {
            targetTile.isPassable = true;
        }

        public void setEvent(Tile targetTile, int targetEventId)
        {
            targetTile.isEventTrigger = true;
            targetTile.eventId = targetEventId;
        }
}
