﻿using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockGrass : Block {


	public BlockGrass() : base() {
		setMaterialType("Dirt");
		setBlockID(2);
		setPathToIcon("icons/Grass");
	}

	public override Tile texturePosition (Direction direction)
	{
		Tile tile = new Tile ();

		switch (direction) {
			case Direction.up:
				tile.x = 1;
				tile.y = 0;
				return tile;
			case Direction.down:
				tile.x = 2;
				tile.y = 0;
				return tile;
		}

		tile.x = 0;
		tile.y = 0;
		return tile;
	}
}
