using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockLeavesSnow : Block {


	public BlockLeavesSnow() : base() {
		setMaterialType("Leaves");
		setBlockID(9);
		setPathToIcon("icons/Snow_Leaves");
	}

	public override Tile texturePosition (Direction direction)
	{
		Tile tile = new Tile ();

	switch (direction) {
		case Direction.up:
			tile.x = 3;
			tile.y = 3;
			return tile;
		case Direction.down:
			tile.x = 3;
			tile.y = 2;
			return tile;
		}

		tile.x = 1;
		tile.y = 1;
		return tile;
	}

	     public override bool isSolid(Direction direction)
     {
         return false;
     }
}
