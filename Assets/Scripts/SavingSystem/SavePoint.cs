﻿using UnityEngine;
using System.Collections;

public class SavePoint : MonoBehaviour {

	private bool usable = true;
	string id;
	void Start () {
		id = GetComponent<GUIText> ().text;

		//if the saving point is already in the dict
		if (SavingPoints.pointsDict.ContainsKey (id)) {
			usable = SavingPoints.pointsDict [id];
		} else {
			//add the saving point to the dict
			SavingPoints.pointsDict.Add (id, true);
		} 

		setColor ();
		Debug.Log ("Pensi di stampare qualcosa a schermo o no: " + SavingPoints.pointsDict [id]);

	}

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.CompareTag ("Player") && usable) {

			SavingPoints.pointsDict[id] = false;
			setColor();
			SavingPoints.Save ();
			SaveLoad.SaveGame ();
			Debug.Log ("salvando");
		}		
	}

	void setColor () {
		SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer> ();

		if (usable) {
			renderer.color = new Color (0f, 1f, 0f, 1f);
		} else {
			renderer.color = new Color (1f, 0f, 0f, 1f);
		}
	}
}
