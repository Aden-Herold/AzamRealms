using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

[Serializable]
public static class Inventory {
	static ItemStack itemStack;

	static int maxInventorySize = 10;
	static ItemStack[] inv = new ItemStack[10];

	static int currentSlot = 1;

	public static void addToInventory(int itemID, string pathToIcon) {
		for(int i = 0; i < maxInventorySize; i++) {
			if(inv[i] == null) {
				inv[i] = new ItemStack(itemID, pathToIcon);
				inv[i].incrementStack();
				break;
			} else {
				if(inv[i].getItemID() == itemID && !inv[i].checkStackFull()) {
					inv[i].incrementStack();
					break;
				}
			}
		}	
	}

	public static bool removeFromInventory(int itemID) {
		for(int i = 0; i < maxInventorySize; i++) {
			if(inv[i] != null) {
				if(inv[i].getItemID() == itemID) {
					if(inv[i].decrementStack()) {
						return true;
					} else {
						inv[i] = null;
						return true;
					}
				}
			}
		}
		return false;
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
