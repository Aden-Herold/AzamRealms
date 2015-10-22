using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

public class Modify : MonoBehaviour {
	Vector2 rot;
	public Texture2D crosshairImage;
	public GameObject blockParticles;
	private BlockHandler bh;

	void Start () {
		Cursor.visible = false;
		bh = new BlockHandler();
		bh.createDictionary();
		bh.registerBlocks();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			performDestructiveAction();
		}
		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			placeBlockFromInventory();
		}
		
		moveCameraWithMouseAction ();
	}

	private void performDestructiveAction () {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward,out hit, 5 ))
		{
			if (hit.collider.gameObject.tag == "Enemy") {
				hit.collider.gameObject.GetComponent<fleshgolem_AI>().takeDamage(20);
			}
			else
			{
				matchParticlesToBlockType(hit);
				
				Instantiate(blockParticles, hit.point, blockParticles.transform.rotation);
				Inventory.addToInventory(EditTerrain.getBlock(hit).getBlockID(), EditTerrain.getBlock(hit).getPathToIcon());
				EditTerrain.setBlock(hit, new BlockAir());
			}
		}
	}

	private void matchParticlesToBlockType (RaycastHit hit) {
		if(EditTerrain.getBlock(hit).getMaterialType().Equals("Wood")) 
		{
			blockParticles.GetComponent<ParticleSystem>().GetComponent<Renderer>().sharedMaterial.SetColor("_Color", new Color32(137, 115, 71, 255));
		} 
		else if(EditTerrain.getBlock(hit).getMaterialType().Equals("Dirt")) 
		{
			blockParticles.GetComponent<ParticleSystem>().GetComponent<Renderer>().sharedMaterial.SetColor("_Color", new Color32(102, 51, 0, 255));
		} 
		else if(EditTerrain.getBlock(hit).getMaterialType().Equals("Leaves")) 
		{
			blockParticles.GetComponent<ParticleSystem>().GetComponent<Renderer>().sharedMaterial.SetColor("_Color", new Color32(0, 102, 0, 255));
		}
	}

	private void placeBlockFromInventory() {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.forward,out hit, 5 ))
		{
			if (!Inventory.slotEmpty(Inventory.getCurrentSlot()-1)) {
				EditTerrain.setBlock(hit, bh.findBlock(Inventory.getSlotID(Inventory.getCurrentSlot() - 1)), true);
				Inventory.removeFromInventory(Inventory.getSlotID(Inventory.getCurrentSlot() - 1));
			}
		}
	}

	private void moveCameraWithMouseAction () {
		rot= new Vector2(
			rot.x + Input.GetAxis("Mouse X") * 3,
			rot.y + Input.GetAxis("Mouse Y") * 3);
		
		transform.localRotation = Quaternion.AngleAxis(rot.x, Vector3.up);
		transform.localRotation *= Quaternion.AngleAxis(rot.y, Vector3.left);
	}

	void OnGUI () {
		float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
		float yMin = (Screen.height / 2) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}
}