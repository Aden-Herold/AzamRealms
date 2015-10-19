using UnityEngine;
using System.Collections;
using SimplexNoise;

public class Humidity {
	
	float humidityBaseHeight = 0;
	float humidityMaxHeight = 80;
	float humidityFrequency = 0.0005f;

	public int GetHumidityHeight (int x, int z) {
		int humidityHeight = Mathf.FloorToInt (humidityBaseHeight);
		humidityHeight += GetNoise (x, 0, z, humidityFrequency, Mathf.FloorToInt (humidityMaxHeight));
		return humidityHeight;
	}

	public static int GetNoise(int x, int y, int z, float scale, int max) {
		return Mathf.FloorToInt ((Noise.Generate (x * scale, y * scale, z * scale) + 1f) * (max / 2f));
	}

}
