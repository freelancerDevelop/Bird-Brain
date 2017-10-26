﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ShittyWizard.Controller.Game
{
	public class GUIController : MonoBehaviour
	{

		public Image currentHealthBar;

		public Image currentEXPbar;
		public float currentEXP = 0f;
		public float maxEXP = 100f;
		public int level = 1;
		public Text levelText;
		public Text floorText;
		public RawImage minimap;
		public RectTransform minimapRectTransform;
		public RectTransform minimapPlayerTracker;

		private GameObject playerGO;
		private EntityPlayer player;

		public WorldController worldController;

		// Use this for initialization
		void Start ()
		{
			currentEXP = 0f;
			playerGO = GameObject.FindGameObjectWithTag ("Player");
			player = playerGO.GetComponent<EntityPlayer> ();
			UpdateHealthBar ();
		}

		public void UpdateForNewLevel(string floor) {
			minimap.texture = worldController.ActiveLevel.GenerateMinimap ();

			floorText.text = "Floor " + floor;
		}

		public void UpdateMinimap() {
			float x = (playerGO.transform.position.x / minimap.texture.width) * minimapRectTransform.rect.width;
			float z = (playerGO.transform.position.z / minimap.texture.height) * minimapRectTransform.rect.height;

			minimapPlayerTracker.localPosition = new Vector3 (x, z, 0.0f);
		}

		// Update is called once per frame
		void Update ()
		{

			UpdateHealthBar ();

			float EXPratio = currentEXP / maxEXP;
			currentEXPbar.rectTransform.sizeDelta = new Vector2 (EXPratio * 250f, 20f);


			if (currentEXP >= maxEXP) {
				level = level + 1;
				levelText.text = "Level " + level;
				float tempXP = currentEXP;
				currentEXP = tempXP - maxEXP;
			}

			UpdateMinimap ();
		}

		public void UpdateHealthBar ()
		{

			float ratio = player.health / player.maxHealth;
			if (player.maxHealth <= 0) {
				ratio = 1;
			}
			currentHealthBar.rectTransform.sizeDelta = new Vector2 (ratio * 250f, 20f);

		}

		public void GiveEXP (float EXP)
		{
			currentEXP += EXP;
		}
	}
}