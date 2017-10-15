﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 0.4f;

	Rigidbody m_Rigidbody;
	Transform m_SpriteTransform;

    private Plane groundPlane;

    private int currentSpell;
    private List<Spell> spells;

	// Use this for initialization
	void Start () {

		m_Rigidbody = GetComponent<Rigidbody> ();
        groundPlane = new Plane(new Vector3(-1, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0));

        // Gather spells
        spells = new List<Spell>();
        Transform spellsTransform = this.transform.Find("Spells");
        foreach (Spell s in spellsTransform.GetComponentsInChildren<Spell>()) {
            spells.Add(s);
        }

	}
	
	// Update is called once per frame
	void Update () {
		// switching weapons
        if (Input.GetKeyDown(KeyCode.E)) {
            currentSpell++;
            if (currentSpell >= spells.Count) {
                currentSpell -= spells.Count;
            }
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            currentSpell--;
            if (currentSpell < 0) {
                currentSpell += spells.Count;
            }
        }

		if(Input.GetKey(KeyCode.Alpha1)){
            currentSpell = 0;
		}
		else if(Input.GetKey(KeyCode.Alpha2)){
            currentSpell = 1;
        }
		else if(Input.GetKey(KeyCode.Alpha3)){
            currentSpell = 2;
        }
		else if(Input.GetKey(KeyCode.Alpha4)){
            currentSpell = 3;
        }

        // Shooting
        if (Input.GetMouseButton(0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			float rayDistance;
			if (groundPlane.Raycast (ray, out rayDistance)) {

				Vector3 projectileDirection = ray.origin + ray.direction * rayDistance - this.transform.position;
				projectileDirection.y = 0;
				projectileDirection = projectileDirection.normalized;

                spells[currentSpell].RequestCast(projectileDirection);

            }

        }
    }

	void FixedUpdate() {

		float verticalInput = 0.0f; // = Input.GetAxis ("Vertical");
		float horizontalInput = 0.0f; // = Input.GetAxis ("Horizontal");

		if (Input.GetKey (KeyCode.W)) {
			verticalInput = 1.0f;
		}
		if (Input.GetKey (KeyCode.S)) {
			verticalInput = -1.0f;
		}
		if (Input.GetKey (KeyCode.A)) {
			horizontalInput = -1.0f;
		}
		if (Input.GetKey (KeyCode.D)) {
			horizontalInput = 1.0f;
		}

		m_Rigidbody.velocity = new Vector3 (horizontalInput * speed, 0.0f, verticalInput * speed);
		transform.position = new Vector3 (transform.position.x, 0.0f, transform.position.z);

    }
}