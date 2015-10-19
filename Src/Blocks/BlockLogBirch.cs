using UnityEngine;
using System.Collections;
using System;

[Serializable] 
public class BlockLogBirch : Block {


	public BlockLogBirch() : base() {
		setMaterialType("Wood");
		setBlockID(6);
		setPathToIcon("icons/Birch_Log");
	}

	public override Tile texturePosition(Direction direction) {
		Tile tile = new Tile ();

		switch (direction) {
		case Direction.up:
			tile.x = 0;
			tile.y = 2;
			return tile;
		case Direction.down:
			tile.x = 0;
			tile.y = 2;
			return tile;
		}

		tile.x = 1;
		tile.y = 3;

		return tile;
	}

}
