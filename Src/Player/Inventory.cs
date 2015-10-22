using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;
using UnityEngine.UI;

[Serializable]
public static class Inventory {

	static int maxInventorySize = 10;
	static ItemStack[] inv = new ItemStack[10];

	static int currentSlot = 1;

	public static void addToInventory(int itemID, string pathToIcon) {
		itemHUD_Controls hud = GameObject.Find ("ItemHUD").GetComponent<itemHUD_Controls>();

		for(int i = 0; i < maxInventorySize; i++) {
			if(inv[i] == null) {
				inv[i] = new ItemStack(itemID, pathToIcon);

				//Update Icon in Inventory HUD
				hud.items[i].GetComponent<Image> ().sprite = Resources.Load<Sprite> (pathToIcon);
				hud.items[i].GetComponent<Image> ().color = new Color32(255, 255, 255, 255);
				inv[i].incrementStack();
				//Update stack counter
				hud.items[i].GetComponentInChildren<Text>().text = getSlotStackSize(i).ToString();
				Resources.UnloadUnusedAssets();

				break;
			} else {
				if(inv[i].getItemID() == itemID && !inv[i].checkStackFull()) {
					inv[i].incrementStack();
					hud.items[i].GetComponentInChildren<Text>().text = getSlotStackSize(i).ToString();
					break;
				}
			}
		}	
	}

	public static bool removeFromInventory(int itemID) {
		itemHUD_Controls hud = GameObject.Find ("ItemHUD").GetComponent<itemHUD_Controls>();

		for(int i = 0; i < maxInventorySize; i++) {
			if(inv[i] != null) 
			{
				if(inv[i].getItemID() == itemID) 
				{
					if(inv[i].decrementStack()) {
						//Update stack counter
						hud.items[i].GetComponentInChildren<Text>().text = getSlotStackSize(i).ToString();

						//Reset sprite to default if stack is empty
						if (inv[i].checkStackEmpty()) {
							hud.items[i].GetComponent<Image> ().sprite = new Sprite();
							hud.items[i].GetComponent<Image> ().color = new Color32(146, 146, 146, 255);
							inv[i] = null;
							Resources.UnloadUnusedAssets();
						}

						return true;
					} 
					else {
						inv[i] = null;
						return true;
					}
				}
			}
		}
		return false;
	}

	public static void swapItems(int firstItem, int secondItem) {
		ItemStack tempStack;
		itemHUD_Controls hud = GameObject.Find ("ItemHUD").GetComponent<itemHUD_Controls>();

		tempStack = inv [firstItem];
		inv [firstItem] = inv [secondItem];
		inv [secondItem] = tempStack;

		swapUpdateIcons (firstItem);
		swapUpdateIcons (secondItem);
	}

	private static void swapUpdateIcons (int itemPos) {
		itemHUD_Controls hud = GameObject.Find ("ItemHUD").GetComponent<itemHUD_Controls>();

		if (inv [itemPos] != null) {
			hud.items [itemPos].GetComponent<Image> ().sprite = Resources.Load<Sprite> (inv [itemPos].getPathToIcon ());
			hud.items [itemPos].GetComponentInChildren<Text> ().text = getSlotStackSize (itemPos).ToString ();
		}
		else {
			hud.items [itemPos].GetComponent<Image> ().sprite = new Sprite();
			hud.items[itemPos].GetComponent<Image> ().color = new Color32(146, 146, 146, 255);
			hud.items [itemPos].GetComponentInChildren<Text> ().text = "0";
		}
	}

	public static bool isEmpty() {
		bool empty = true;

		for (int x = 0; x < inv.Length; x++) {
			if (inv[x] != null) {
				empty = false;
			}
		}

		return empty;
	}

	public static bool slotEmpty(int index) {
		bool empty = true;

		if (inv[index] != null) {

			empty = false;
		}

		return empty;
	}

	public static int getSlotID(int index) {
		return inv[index].getItemID();
	}

	public static int getSlotStackSize(int index) {
		return inv[index].getStackSize();
	}

	public static string getSlotPathToIcon(int index) {
		return inv[index].getPathToIcon();
	}

	public static void setCurrentSlot(int slot) {
		currentSlot = slot;
	}

	public static int getCurrentSlot() {
		return currentSlot;
	}

}
