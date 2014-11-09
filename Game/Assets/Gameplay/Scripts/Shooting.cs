using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	
	public bool Shoot;

	public Locomotion player;
	
	private Animator ani;
	private Animator Animation {
		get {
			if (ani==null) 
				ani = GetComponent<Animator>();
			return ani;
		}
	}
	
	private int ShootId {
		get {
			return Animator.StringToHash ("Shoot");
		}
	}
	void Update () {
		if ((player.Grounded && player.Speed  > 0.1f) || player.Kneel) {
			Shoot = Input.GetButton ("Fire");
			GetComponent<SpriteRenderer>().enabled = true;
		} else {
			Shoot = false;
			GetComponent<SpriteRenderer>().enabled = false;
		}
		Animation.SetBool (ShootId, Shoot);
	}
	
	void FixedUpdate () {
		//Shoot = Input.GetButton ("Fire");
	}
}
