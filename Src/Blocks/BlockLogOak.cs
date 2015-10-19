using UnityEngine;
using System.Collections;
using System;

[Serializable] 
public class BlockLogOak : Block {

	public BlockLogOak() : base() {
		setMaterialType("Wood");
		setBlockID(5);
		setPathToIcon("icons/Oak_Log");
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

		tile.x = 3;
		tile.y = 0;

		return tile;
	}

}
