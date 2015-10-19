using UnityEngine;
using System.Collections;

public class itemHUD_Controls : MonoBehaviour {

	public GameObject[] items = new GameObject[10];
	public GameObject selectedItemObj;
	private int selectedItem = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			selectedItem = 1;
			Inventory.setCurrentSlot(selectedItem);
			selectedItemObj.transform.position = items[selectedItem-1].transform.position;
			Debug.Log("Slot # " + selectedItem + " - Item ID: " + Inventory.getSlotID(selectedItem - 1) + " - Stack Size: " + Inventory.getSlotStackSize(selectedItem - 1));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2)) {
			selectedItem = 2;
			Inventory.setCurrentSlot(selectedItem);
			selectedItemObj.transform.position = items[selectedItem-1].transform.position;
			Debug.Log("Slot # " + selectedItem + " - Item ID: " + Inventory.getSlotID(selectedItem - 1) + " - Stack Size: " + Inventory.getSlotStackSize(selectedItem - 1));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3)) {
			selectedItem = 3;
			Inventory.setCurrentSlot(selectedItem);
			selectedItemObj.transform.position = items[selectedItem-1].transform.position;
			Debug.Log("Slot # " + selectedItem + " - Item ID: " + Inventory.getSlotID(selectedItem - 1) + " - Stack Size: " + Inventory.getSlotStackSize(selectedItem - 1));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4)) {
			selectedItem = 4;
			Inventory.setCurrentSlot(selectedItem);
			selectedItemObj.transform.position = items[selectedItem-1].transform.position;
			Debug.Log("Slot # " + selectedItem + " - Item ID: " + Inventory.getSlotID(selectedItem - 1) + " - Stack Size: " + Inventory.getSlotStackSize(selectedItem - 1));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5)) {
			selectedItem = 5;
			Inventory.setCurrentSlot(selectedItem);
			selectedItemObj.transform.position = items[selectedItem-1].transform.position;
			Debug.Log("Slot # " + selectedItem + " - Item ID: " + Inventory.getSlotID(selectedItem - 1) + " - Stack Size: " + Inventory.getSlotStackSize(selectedItem - 1));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6)) {
			selectedItem = 6;
			Inventory.setCurrentSlot(selectedItem);
			selectedItemObj.transform.position = items[selectedItem-1].transform.position;
			Debug.Log("Slot # " + selectedItem + " - Item ID: " + Inventory.getSlotID(selectedItem - 1) + " - Stack Size: " + Inventory.getSlotStackSize(selectedItem - 1));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha7)) {
			selectedItem = 7;
			Inventory.setCurrentSlot(selectedItem);
			selectedItemObj.transform.position = items[selectedItem-1].transform.position;
			Debug.Log("Slot # " + selectedItem + " - Item ID: " + Inventory.getSlotID(selectedItem - 1) + " - Stack Size: " + Inventory.getSlotStackSize(selectedItem - 1));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha8)) {
			selectedItem = 8;
			Inventory.setCurrentSlot(selectedItem);
			selectedItemObj.transform.position = items[selectedItem-1].transform.position;
			Debug.Log("Slot # " + selectedItem + " - Item ID: " + Inventory.getSlotID(selectedItem - 1) + " - Stack Size: " + Inventory.getSlotStackSize(selectedItem - 1));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha9)) {
			selectedItem = 9;
			Inventory.setCurrentSlot(selectedItem);
			selectedItemObj.transform.position = items[selectedItem-1].transform.position;
			Debug.Log("Slot # " + selectedItem + " - Item ID: " + Inventory.getSlotID(selectedItem - 1) + " - Stack Size: " + Inventory.getSlotStackSize(selectedItem - 1));
		}
		else if (Input.GetKeyDown(KeyCode.Alpha0)) {
			selectedItem = 10;
			Inventory.setCurrentSlot(selectedItem);
			selectedItemObj.transform.position = items[selectedItem-1].transform.position;
			Debug.Log("Slot # " + selectedItem + " - Item ID: " + Inventory.getSlotID(selectedItem - 1) + " - Stack Size: " + Inventory.getSlotStackSize(selectedItem - 1));
		}

	}
}
