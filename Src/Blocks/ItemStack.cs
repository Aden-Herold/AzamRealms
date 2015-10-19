using UnityEngine;
using System.Collections;
using System;

public class ItemStack {

	private int itemID;
	private int stackSize;
	private string pathToIcon;
	private int maxStackSize = 100;

	public ItemStack(int itemID, string itemIcon) {
		this.itemID = itemID;
		this.pathToIcon = itemIcon;
	}

	public int getItemID() {
		return itemID;
	}

	public string getPathToIcon() {
		return pathToIcon;
	}

	public int getStackSize() {
		return stackSize;
	}

	public int getMaxStackSize() {
		return maxStackSize;
	} 

	public bool checkStackFull() {
		if(stackSize >= maxStackSize) {
			return true;
		}
		return false;
	}

	public bool checkStackEmpty() {
		if(stackSize <= 0) {
			return true;
		}
		return false;
	}

	public void incrementStack() {
		if(!checkStackFull()) {
			stackSize++;
		}
	}

	public bool decrementStack() {
		if(!checkStackEmpty()) {
			stackSize--;
			return true;
		}
			return false;
	}


}
