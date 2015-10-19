using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockTallGrass : Block {

	public BlockTallGrass() : base() {
		setMaterialType("Foliage");
		setBlockID(10);
		setPathToIcon("icons/TallGrass");
	}

	public override Tile texturePosition (Direction direction)
	{
		Tile tile = new Tile ();

		switch (direction) {
			case Direction.up:
				tile.x = 2;
				tile.y = 3;
				return tile;
			case Direction.down:
				tile.x = 2;
				tile.y = 3;
				return tile;
		}

		tile.x = 2;
		tile.y = 2;
		return tile;
	}

	     public override bool isSolid(Direction direction) {
         return false;
     }

     	public override MeshData blockData (Chunk chunk, int x, int y, int z, MeshData meshData) {
		meshData.useRenderDataForCol = false;

		if (!chunk.getBlock (x, y + 1, z).isSolid (Direction.up)) {
			meshData = FaceDataUp (chunk, x, y, z, meshData);
		}

		if (!chunk.getBlock (x, y - 1, z).isSolid (Direction.down)) {
			meshData = FaceDataDown (chunk, x, y, z, meshData);
		}

		if (!chunk.getBlock (x, y, z + 1).isSolid (Direction.north)) {
			meshData = FaceDataNorth (chunk, x, y, z, meshData);
		}

		if (!chunk.getBlock (x, y, z - 1).isSolid (Direction.south)) {
			meshData = FaceDataSouth (chunk, x, y, z, meshData);
		}

		if (!chunk.getBlock (x + 1, y, z).isSolid (Direction.east)) {
			meshData = FaceDataEast (chunk, x, y, z, meshData);
		}

		if (!chunk.getBlock (x - 1, y, z).isSolid (Direction.west)) {
			meshData = FaceDataWest (chunk, x, y, z, meshData);
		}

		return meshData;
	}

}
