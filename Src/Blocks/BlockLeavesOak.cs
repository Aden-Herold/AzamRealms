using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockLeavesOak : Block {

	public BlockLeavesOak() : base() {
		setMaterialType("Leaves");
		setBlockID(8);
		setPathToIcon("icons/Oak_Leaves");
	}

	public override Tile texturePosition (Direction direction) {
		Tile tile = new Tile ();

		tile.x = 0;
		tile.y = 1;
		return tile;
	}

	     public override bool isSolid(Direction direction) {
         return false;
     }
}
