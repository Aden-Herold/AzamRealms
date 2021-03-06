﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fleshgolem_AI : MonoBehaviour {

	//Enemy Object Variables
	private GameObject player;
	private CharacterController character;
	private Transform tr;
	private Vector3 chaseDir;
	public fleshgolem_Spawner golemSpawner;
	private gameObjectNamer golemSpawnerRef;

	//Enemy Health System
	private int maxHealth = 100;
	private int curHealth = 100;
	private float healthBarHeight = 0.2f;
	public Image healthBar;

	public GameObject enemyDamaged;
	public GameObject enemyKilled;
	public GameObject hitBox;

	//Enemy Movement System
	private bool jumping = false;
	private float vSpeed = 0f;
	private bool jump = false;
	public float speed = 14f;
	public float jumpSpeed = 10f;
	public float gravity = 10;

	//Enemy Attack System
	private bool attackReady = true;
	private bool scentReady = true;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Main Camera");
		character = GetComponent<CharacterController>();
		tr = transform;
	}
	
	void Update ()
	{    
		if (this.transform.position.y < -65) {
			golemSpawner.removeGolem(golemSpawnerRef);
			Instantiate(enemyKilled, hitBox.transform.position, enemyKilled.transform.rotation);
			Destroy (this.gameObject);
		}

		// find the vector enemy -> player
		chaseDir = player.transform.position - tr.position;
		chaseDir.y = 0; // let only the horizontal direction
		float distance = chaseDir.magnitude;  // get the distance

		if (distance <= 0.3) {
			if (attackReady){
				player.GetComponent<Player>().takeDamage(5);
				attackReady = false;
				StartCoroutine(attackCooldown());
			}
		} 
		else if (distance <= 30) {    // get the player direction
			Quaternion rot = Quaternion.LookRotation (chaseDir);

			// rotate to his direction
			tr.rotation = Quaternion.Slerp (tr.rotation, rot, Time.deltaTime * 4);
			checkForJump();

		} 
		else {

			if (!scentReady) {

				int randomX = Random.Range (-10, 10);
				int randomZ = Random.Range (-10, 10);

				chaseDir = new Vector3(this.transform.position.x + randomX,
				                       0,
				                       this.transform.position.z + randomZ);
			}
			else {

				StartCoroutine(followingPlayerScent());
			}


			Quaternion rot = Quaternion.LookRotation (chaseDir);
			
			// rotate to his direction
			tr.rotation = Quaternion.Slerp (tr.rotation, rot, Time.deltaTime * 4);
			checkForJump();
		}

		// apply gravity
		vSpeed -= gravity * Time.deltaTime; 
		
		// calculate horizontal velocity vector
		chaseDir = chaseDir.normalized * speed;
		chaseDir.y += vSpeed; // include vertical speed
		
		// and move the enemy
		character.Move (chaseDir * Time.deltaTime);
	}

	// if collided with some wall or block, jump
	void OnControllerColliderHit(ControllerColliderHit hit){

			// We dont want to push objects below us
			if (hit.moveDirection.y < -0.2) {
				return;
			} else {
				if (!jumping){
				jumping = true;
				chaseDir.y += jumpSpeed;
				character.Move (chaseDir * Time.deltaTime);
				jump = true;
			}
		}
	}

	private void checkForJump () {

		if (character.isGrounded) { // if is grounded...
			vSpeed = 0;  // vertical speed  is zero
			if (jump) {    // if should jump...
				vSpeed = jumpSpeed; 
				//jump = false;
				int random = Random.Range (0, 1);
				
				//Double Jump
				if (random == 1) {
					vSpeed = jumpSpeed / 2; 
					jump = false;
				}
				//Jump Once
				else {
					jump = false; // only jump once!
				}
				jumping = false;
			}
		} 
	}

	private void updateHealthBar () {
		healthBar.rectTransform.sizeDelta = new Vector2 (curHealth * 0.02f, healthBarHeight);
	}

	public void takeDamage (int damageAmount) {
		if (damageAmount < 0)
			damageAmount *= -1;

		if ((curHealth - damageAmount) <= 0) {
			curHealth = 0;
			golemSpawner.removeGolem(golemSpawnerRef);

			Instantiate(enemyKilled, hitBox.transform.position, enemyKilled.transform.rotation);
			Destroy (this.gameObject);
		} 
		else {
			Instantiate(enemyDamaged, hitBox.transform.position, enemyKilled.transform.rotation);
			curHealth = curHealth - damageAmount;
		}
		updateHealthBar ();
	}
	
	public void addHealth (int healAmount) {
		if (healAmount < 0) {
			healAmount *= -1;
		}

		if ((curHealth + healAmount) > 100) {
			curHealth = 100;
		} else {
			curHealth = curHealth + healAmount;
		}
	}

	public void setCurHealth (int health) {
		if (health < 0) {
			health *= -1;
		}

		curHealth = health;
	}

	public int getCurHealth () {
		return curHealth;
	}

	public void setGolemSpawnerRef (gameObjectNamer golem) {
		golemSpawnerRef = golem;
	}

	IEnumerator attackCooldown() {
		yield return new WaitForSeconds (2f);
		attackReady = true;
	}

	IEnumerator catchPlayerScentCooldown() {
		yield return new WaitForSeconds (3f);
		scentReady = true;
	}

	IEnumerator followingPlayerScent() {
		yield return new WaitForSeconds (3f);
		scentReady = false;
		StartCoroutine (catchPlayerScentCooldown ());
	}
}