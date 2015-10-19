using UnityEngine;
using System.Collections;
using System;

[Serializable] 
public class BlockSand : Block {

	public BlockSand() : base() {
		setMaterialType("Sand");
		setBlockID(4);
		setPathToIcon("icons/Sand");
	}

	public override Tile texturePosition(Direction direction) {
		Tile tile = new Tile ();

		tile.x = 2;
		tile.y = 1;

		return tile;
	}

}
