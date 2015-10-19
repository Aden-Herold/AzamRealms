using UnityEngine;
using System.Collections;
using SimplexNoise;

public class Temperature {
	
	float temperatureBaseHeight = 0;
	float temperatureMaxHeight = 80;
	float temperatureFrequency = 0.0005f;

	public int GetTemperatureHeight (int x, int z) {
		int temperatureHeight = Mathf.FloorToInt (temperatureBaseHeight);
		temperatureHeight += GetNoise (x, 0, z, temperatureFrequency, Mathf.FloorToInt (temperatureMaxHeight));
		return temperatureHeight;
	}

	public static int GetNoise(int x, int y, int z, float scale, int max) {
		return Mathf.FloorToInt ((Noise.Generate (x * scale, y * scale, z * scale) + 1f) * (max / 2f));
	}

}
