using UnityEngine;
using System.Collections;

public class btn_playGame : MonoBehaviour {

	private bool changeScene = false;
	
	//BUTTON SPRITES
	public Sprite Default;
	public Sprite Active;
	public Sprite Clicked;

	private RaycastHit hit;
	private Ray ray;
	private bool hovering = false; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast (ray, out hit, 100f);
		
		if (hit.collider != null) {
			if (hit.collider.gameObject.name == "playBtn") {
				this.GetComponent<SpriteRenderer>().sprite = Active;
				hovering = true;
			}	                   
			else {
				this.GetComponent<SpriteRenderer>().sprite = Default;
				hovering = false;
			}
		}
		else {
			this.GetComponent<SpriteRenderer>().sprite = Default;
			changeScene = false;
		}

		Debug.DrawRay(ray.origin, ray.direction * 40f, Color.red);


		if (Input.GetMouseButton(0)) {
			if (hovering) {
				changeScene = true;
				this.GetComponent<SpriteRenderer>().sprite = Clicked;
			}
			else {
				changeScene = false;
			}
		}
		else if (Input.GetMouseButtonUp (0)) {
			
			if (changeScene) {
				
				Application.LoadLevel ("AzamRealms");
			}
		}
	}
}
