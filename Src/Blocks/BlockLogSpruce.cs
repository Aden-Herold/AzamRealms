using UnityEngine;
using System.Collections;
using System;

[Serializable] 
public class BlockLogSpruce : Block {

	public BlockLogSpruce() : base() {
		setMaterialType("Wood");
		setBlockID(7);
		setPathToIcon("icons/Spruce_Log");
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

		tile.x = 2;
		tile.y = 1;

		return tile;
	}

}
