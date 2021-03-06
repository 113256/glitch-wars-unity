﻿using UnityEngine;
using System.Collections;

public class RepairBot : Defender {

	private GameObject defenderParent;
	public ParticleSystem healParticle;


	public override void Start(){
		base.Start ();
		defenderParent = GameObject.Find("Defender");
	}

	public override void Update () {
		base.Update ();
	}
	
	private void Repair(){
		Heal ();
	}

	void Heal(){
		//method1
		//cant do Defender child as Defender cant be used in foreach loop
		/*foreach (Transform child in defenderParent.transform) {
			//we need to access Defender methods so we have to get the defender component of each child 
			Defender defender = child.gameObject.GetComponent<Defender>();

			if(defender) {
				print (defender.getHealth() + 20f);
				defender.setHealth(defender.getHealth() + 20f);
				GameObject particle = Instantiate(healParticle, defender.transform.position, Quaternion.identity) as GameObject;
				//

			};
		}*/

		//method 2
		Defender[] defenders = defenderParent.GetComponentsInChildren<Defender> ();
		foreach(Defender defender in defenders){
			defender.addHealth(20f);
			GameObject particle = Instantiate(healParticle, defender.transform.position, Quaternion.identity) as GameObject;

		}
	}

}
