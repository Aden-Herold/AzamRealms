using UnityEngine;
using System.Collections;
using SimplexNoise;
using System;
using System.IO;
using System.Text;

public class TerrainGen {

	float stoneBaseHeight = -24;
	float stoneBaseNoise = 0.05f;
	float stoneBaseNoiseHeight = 4;
	
	float stoneMountainHeight = 48;
	float stoneMountainFrequency = 0.008f;
	float stoneMinHeight = -12;
	
	float dirtBaseHeight = 1;
	float dirtNoise = 0.04f;
	float dirtNoiseHeight = 3;

	float grassFrequency = 1f;
	int grassDensity = 20;

	float thickTreeFrequency = 0.17f;
	int thickTreeDensity = 5;

	float thinTreeFrequency = 0.1f;
	int thinTreeDensity = 2;

	float pineTreeFrequency = 0.15f;
	int pineTreeDensity = 3;

	Temperature temperature = new Temperature();
	Humidity humidity = new Humidity();

public Chunk ChunkGen(Chunk chunk) {
     for (int x = chunk.pos.x-3; x < chunk.pos.x + Chunk.chunkSize + 3; x++) {
         for (int z = chunk.pos.z-3; z < chunk.pos.z + Chunk.chunkSize + 3; z++) {
             chunk = ChunkColumnGen(chunk, x, z);
         }
     }
     return chunk;
 }
	
	public Chunk ChunkColumnGen(Chunk chunk, int x, int z) {
		int stoneHeight = Mathf.FloorToInt (stoneBaseHeight);
		stoneHeight += GetNoise (x, 0, z, stoneMountainFrequency, Mathf.FloorToInt (stoneMountainHeight));

		if (stoneHeight < stoneMinHeight)
			stoneHeight = Mathf.FloorToInt (stoneMinHeight);

		stoneHeight += GetNoise (x, 0, z, stoneBaseNoise, Mathf.FloorToInt (stoneBaseNoiseHeight));

		int dirtHeight = stoneHeight + Mathf.FloorToInt (dirtBaseHeight);
		dirtHeight += GetNoise (x, 100, z, dirtNoise, Mathf.FloorToInt (dirtNoiseHeight));

		int temp = temperature.GetTemperatureHeight(x, z);
		int hum = humidity.GetHumidityHeight(x, z);

		for (int y = chunk.pos.y - 8; y < chunk.pos.y + Chunk.chunkSize; y++) {

			//Snow Biome
			if(temp <= 20 && hum <= 20) {

				if (y <= stoneHeight) {
					SetBlock(x, y, z, new Block(), chunk);
				} 
				else if (y <= dirtHeight) {
					SetBlock(x, y, z, new BlockSnow(), chunk);

					if(y == dirtHeight && GetNoise(x, 0, z, grassFrequency, 100) < grassDensity) {
						SetBlock(x, y+1, z, new BlockTallGrassSnow(), chunk);
					}
					if(y == dirtHeight && GetNoise(x, 0, z, pineTreeFrequency, 100) < pineTreeDensity) {
						CreateSprucePineTree(x, y+1, z, chunk);
					}
				} 
				else {
					SetBlock(x, y, z, new BlockAir(), chunk);
				}
			} 
			//Desert Biome
			else if(temp > 20 && hum <= 20) {

				if (y <= stoneHeight) {
					SetBlock(x, y, z, new Block(), chunk);
				} 
				else if (y <= dirtHeight) {
					SetBlock(x, y, z, new BlockSand(), chunk);
				} 
				else {
					SetBlock(x, y, z, new BlockAir(), chunk);
				}
			} 
			//Grass Biome
			else {

				if (y <= stoneHeight) {
					SetBlock(x, y, z, new Block(), chunk);
				} 
				else if (y <= dirtHeight) {
					SetBlock(x, y, z, new BlockGrass(), chunk);

					if(y == dirtHeight && GetNoise(x, 0, z, grassFrequency, 100) < grassDensity) {
						SetBlock(x, y+1, z, new BlockTallGrass(), chunk);
					}
					if(y == dirtHeight && GetNoise(x, 0, z, thinTreeFrequency, 100) < thinTreeDensity) {
						CreateBirchThinTree(x, y+1, z, chunk);
					}
					if(y == dirtHeight && GetNoise(x, 0, z, thickTreeFrequency, 100) < thickTreeDensity) {
						CreateOakThickTree(x, y+1, z, chunk);
					}
				} 
				else {
					SetBlock(x, y, z, new BlockAir(), chunk);
				}
			}
		}

		return chunk;
	}

	
	public static int GetNoise(int x, int y, int z, float scale, int max) {
		return Mathf.FloorToInt( (Noise.Generate(x * scale, y * scale, z * scale) + 1f) * (max/2f));
	}

	public void CreateSprucePineTree(int x, int y, int z, Chunk chunk) {
    	for (int xi = -3; xi <= 3; xi++) {
     		for (int zi = -3; zi <= 3; zi++) {
     			if(!((xi == -3  && zi == 3) || (xi == 3 && zi == -3) || (xi == 3 && zi == 3) || (xi == -3 && zi == -3)))
        			SetBlock(x + xi, y + 3, z + zi, new BlockLeavesSnow(), chunk, true);
        	}
     	}
    	for (int xi = -2; xi <= 2; xi++) {
    		for (int zi = -2; zi <= 2; zi++) {
    			if(!((xi == -2  && zi == 2) || (xi == 2 && zi == -2) || (xi == 2 && zi == 2) || (xi == -2 && zi == -2)))
        			SetBlock(x + xi, y + 5, z + zi, new BlockLeavesSnow(), chunk, true);
        	}
    	}
 		for (int xi = -1; xi <= 1; xi++) {
    		for (int zi = -1; zi <= 1; zi++) {
    			if(!((xi == -1  && zi == 1) || (xi == 1 && zi == -1) || (xi == 1 && zi == 1) || (xi == -1 && zi == -1)))
        			SetBlock(x + xi, y + 7, z + zi, new BlockLeavesSnow(), chunk, true);
        	}
    	}
    	for (int yt = 0; yt < 9; yt++) {
        	SetBlock(x, y + yt, z, new BlockLogSpruce(), chunk, true);
     	}
	}

	public void CreateOakThickTree(int x, int y, int z, Chunk chunk) {
    	for (int xi = -2; xi <= 2; xi++) {
    	 	for(int yi = 3; yi <= 4; yi++) {
    	 		for (int zi = -2; zi <= 2; zi++) {
    	    		SetBlock(x + xi, y + yi, z + zi, new BlockLeavesOak(), chunk, true);
    	    	}
   	    	}
   	  	}

		for (int xi = -1; xi <= 1; xi++) {
    		for(int yi = 5; yi <= 6; yi++) {
    	 		for (int zi = -1; zi <= 1; zi++) {
    	    		SetBlock(x + xi, y + yi, z + zi, new BlockLeavesOak(), chunk, true);
    	    	}
   	    	}
   	  	}

   	  	SetBlock(x, y + 7, z, new BlockLeavesOak(), chunk, true);

     	for (int yt = 0; yt < 7; yt++) {
         	SetBlock(x, y + yt, z, new BlockLogOak(), chunk, true);
     	}
	}

	public void CreateBirchThinTree(int x, int y, int z, Chunk chunk) {
    	for (int xi = -1; xi <= 1; xi++) {
    	 	for(int yi = 2; yi <= 9; yi++) {
    	 		for (int zi = -1; zi <= 1; zi++) {
    	    		SetBlock(x + xi, y + yi, z + zi, new BlockLeavesOak(), chunk, true);
    	    	}
   	    	}
   	  	}

   	  	SetBlock(x, y + 10, z, new BlockLeavesOak(), chunk, true);

     	for (int yt = 0; yt < 9; yt++) {
         	SetBlock(x, y + yt, z, new BlockLogBirch(), chunk, true);
     	}
	}

	public static void SetBlock(int x, int y, int z, Block block, Chunk chunk, bool replaceBlocks = false) {
    	x -= chunk.pos.x;
    	y -= chunk.pos.y;
     	z -= chunk.pos.z;
 
    	if (Chunk.inRange(x) && Chunk.inRange(y) && Chunk.inRange(z)) {
        	if (replaceBlocks || chunk.blocks[x, y, z] == null)
            	chunk.setBlock(x, y, z, block);
     	}
 	}
}