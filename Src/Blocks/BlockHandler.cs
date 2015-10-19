using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BlockHandler {

	private Dictionary<int, Block> blocks;

	//Constructor
	public BlockHandler() {
		//registerBlocks();
	}

	public void createDictionary() {
		blocks = new Dictionary<int, Block>();
	}

	public void registerBlock(int blockID, Block block) {
		blocks.Add(blockID, block);
	}

	public Block findBlock(int blockID) {
		return blocks[blockID];
	}

	public void registerBlocks() {
		registerBlock(0, new Block());
		registerBlock(1, new BlockAir());
		registerBlock(2, new BlockGrass());
		registerBlock(3, new BlockSnow());
		registerBlock(4, new BlockSand());
		registerBlock(5, new BlockLogOak());
		registerBlock(6, new BlockLogBirch());
		registerBlock(7, new BlockLogSpruce());
		registerBlock(8, new BlockLeavesOak());
		registerBlock(9, new BlockLeavesSnow());
		registerBlock(10, new BlockTallGrass());
		registerBlock(11, new BlockTallGrassSnow());
	}
	
}
