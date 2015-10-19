using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemHUD_Controls : MonoBehaviour {

	public GameObject[] items = new GameObject[10];
	public GameObject selectedItemObj;
	public GameObject swappingItemObj;
	private int selectedItem = 1;

	private bool swappingItems = false;
	private float holdTime = 0.5f;
	private int firstItemSwap;
	private int secondItemSwap;


	// Use this for initialization
	void Start () {
		swappingItemObj.GetComponent<Image> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Alpha1)) {

			performKeyAction(KeyCode.Alpha1, 0);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2)) {

			performKeyAction(KeyCode.Alpha2, 1);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3)) {

			performKeyAction(KeyCode.Alpha3, 2);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4)) {

			performKeyAction(KeyCode.Alpha4, 3);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5)) {

			performKeyAction(KeyCode.Alpha5, 4);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6)) {

			performKeyAction(KeyCode.Alpha6, 5);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha7)) {

			performKeyAction(KeyCode.Alpha7, 6);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha8)) {

			performKeyAction(KeyCode.Alpha8, 7);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha9)) {

			performKeyAction(KeyCode.Alpha9, 8);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha0)) {

			performKeyAction(KeyCode.Alpha0, 9);
		}
	}

	private void performKeyAction (KeyCode key, int position) {
		if (swappingItems) {
			secondItemSwap = position;
			Inventory.swapItems(firstItemSwap, secondItemSwap);
			swappingItemObj.GetComponent<Image> ().enabled = false;
			swappingItems = false;
		}
		else {
			//Check for swap
			StartCoroutine(checkForHold(key, position));
		}

		selectedItem = position+1;
		Inventory.setCurrentSlot(selectedItem);
		selectedItemObj.transform.position = items[position].transform.position;
	}

	IEnumerator checkForHold (KeyCode key, int firstItem) {
		yield return new WaitForSeconds(holdTime);

		if (Input.GetKey (key)) {
			firstItemSwap = firstItem;
			swappingItems = true;
			swappingItemObj.transform.position = items[firstItem].transform.position;
			swappingItemObj.GetComponent<Image> ().enabled = true;
		}
	}
}
