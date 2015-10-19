using UnityEngine;
using System.Collections;

public class DaynightController : MonoBehaviour {

    public Light sun;
	public Light subLight;
	public Material skyDay;
	public Material skyNight;
	
	public float moonIntensity = 0.6f;

	private float timeInDay = 120f, currentTime = 0f;
    private GameObject sunPOS, player;
    private bool night = false;
    private Vector3 cameraPos;

	private bool skyboxNight = false;

    private float intesity, IntensityMultiplier, sunPosX, sunPosY, temp;
    
	void Start () {

		//Default to Sun
		GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
		subLight.color = new Color32(255, 69, 0, 255);
		subLight.intensity = 0.5f;

        sunPOS = GameObject.Find("Sun_Moon");
        player = GameObject.Find("Main Camera");

        sunPosX = 0f; sunPosY = 0f;
        sun = sunPOS.GetComponent<Light>();

        sunPOS.transform.Translate(new Vector3(sunPosX, sunPosY, cameraPos.z));
	    sun.intensity = intesity;
	}
	
	void Update () {
        UpdateRotation();
        IntensityModifier();
        UpdateLocation();

        currentTime += (Time.deltaTime / timeInDay) * 10f;

        if (currentTime >= 1) {
            currentTime = 0;
            sunPosX = 0f; sunPosY = 0f;

            if (!night)
            {
                sun.color = Color.white;

				if (!skyboxNight) {

					//Change Sun to Moon
					GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
					subLight.color = new Color32(111, 165, 255, 255);
					subLight.intensity = 2.11f;

					RenderSettings.ambientIntensity = 0.3f;
					RenderSettings.skybox = skyNight;
					skyboxNight = true;
				}

            }
            else {
				sun.color = Color.white;

				if (skyboxNight) {

					//Change Moon to Sun
					GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 255);
					subLight.color = new Color32(255, 153, 0, 255);
					subLight.intensity = 0.5f;


					RenderSettings.skybox = skyDay;
					skyboxNight = false;
				}
            }

            night = !night;
        }
    }

    private void UpdateRotation() {

        sun.transform.LookAt(player.transform);
		subLight.transform.LookAt (sun.transform);
    }

    private void IntensityModifier() {

        IntensityMultiplier = 4;

        if (night) {
			IntensityMultiplier = IntensityMultiplier / 2;
		}

        if (currentTime > 0.5) {
			if (night) {
				RenderSettings.ambientIntensity = (0.3f+0.5f*moonIntensity) - (currentTime - 0.5f) * moonIntensity;
			} 
			else {
				RenderSettings.ambientIntensity = 1f - (currentTime - 0.5f) * 1.4f;
				subLight.intensity -= 0.01f;
			}

			//Decrease Moon size as it moves away from the player
			transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);


		} 
		else if (currentTime < 0.5) {

			if (night) {
				RenderSettings.ambientIntensity = 0.3f + currentTime * moonIntensity;
			} 
			else {
				RenderSettings.ambientIntensity = 0.3f + currentTime * 1.5f;
				subLight.intensity += 0.01f;
			}
			//Increase Moon size as it moves nearer the player in the sky
			transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);

		}

		temp = (0.05f + currentTime)/5;

		IntensityMultiplier = IntensityMultiplier * temp;

        sun.intensity = IntensityMultiplier;
    }

    private void UpdateLocation() {
        GetCameraLocation();

        sunPosX = (300 - (600f*currentTime));

        temp = (float)((sunPosX*sunPosX)/600);
        sunPosY = 150 - ((sunPosX * sunPosX) / 600);

        if (player.transform.position.y > 0) {
            sunPosY += player.transform.position.y;
        }

        sunPOS.transform.position = new Vector3(sunPosX + player.transform.position.x, sunPosY, player.transform.position.z);
    }

    private void GetCameraLocation() {
        cameraPos = player.transform.position;        
    }
}