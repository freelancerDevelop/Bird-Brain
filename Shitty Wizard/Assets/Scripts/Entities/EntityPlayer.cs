﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EntityPlayer : Entity {

    [Header("Player Settings")]
    public int exp;
    public int expToNextLevel;
	public float currentHealth = 100f;

    protected override void OnStart() {
        base.OnStart();
    }

    protected override void OnUpdate() {
        base.OnUpdate();
    }

    protected override void OnDeath() {
        base.OnDeath();
    }

    protected override void OnDamage() {

        base.OnDamage();
        _ui.UpdateHealthBar();

        if (this.health <= 0) {
            SceneManager.LoadScene("MenuScene");
        }
        MakeInvulnerable(2);

    }

	void OnTriggerEnter(Collider other){
		/*if (other.gameObject.CompareTag ("HEALTH")) {
			currentHealth = currentHealth + 10f;
			Destroy (other.gameObject);
		}*/
	}
}
