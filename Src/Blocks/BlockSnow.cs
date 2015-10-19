using UnityEngine;
using System.Collections;
using System;

[Serializable] 
public class BlockSnow : Block {

	public BlockSnow() : base() {
		setMaterialType("Dirt");
		setBlockID(3);
		setPathToIcon("icons/Snow");
	}

	public override Tile texturePosition(Direction direction) {
		Tile tile = new Tile ();

		switch (direction) {
		case Direction.up:
			tile.x = 3;
			tile.y = 1;
			return tile;
		case Direction.down:
			tile.x = 2;
			tile.y = 0;
			return tile;
		}

		tile.x = 0;
		tile.y = 3;

		return tile;
	}

}
