using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Rune {
	public byte[] ID;
	[HideInInspector]public Tile tile;
	[HideInInspector]public int hexTile;
	[HideInInspector]public TileType type;
	[HideInInspector]public int glyph;
	[HideInInspector]public List<int> tileTargets;
    public RuneHex runeHex;

	public Rune(){}
	
	public Rune(byte[] id)
	{
		ID = id;
		tile = new Tile(0,0);
		foreach(byte b in ID)
		{
            //randomize initializations
			UnityEngine.Random.InitState((int)b);
            float castDensity = 
            tile.uvx += UnityEngine.Random.Range(-20,20);
			tile.uvy += UnityEngine.Random.Range(-20,20);
            if (UnityEngine.Random.Range(0, 1f) > castDensity)
            { }
		}
		tile.uvx = Mathf.Abs(tile.uvx % 16) + 1;
		type = (TileType)tile.uvx;
		tile.uvy = Mathf.Abs(tile.uvy % 16) + 5;
		glyph = tile.uvy;
		//determine runehex
		//waterattacki test
		type = TileType.Water;
		glyph = 5;
        /*
		switch(type) 
		{
			case 0: break;
			case TileType.Water:
				switch(glyph)
				{
					//case 5: runeHex = new WaterBurstI(); runeHex.Initialize(tileTargets); break;
				} 
			break;
		}
		*/
	}
	
	public GameObject RuneGO()
	{
		Zone zone = new Zone(1);
		zone.tiles[0,0] = tile;
		GameObject rr = GameObject.Find("RuneRenderer");
		ZoneRenderer zr = rr.GetComponent<ZoneRenderer>();
		ZoneManager zm = rr.GetComponent<ZoneManager>();
		return zr.RenderZone(zone, zm.regularTileSet)[0];
	}
}
