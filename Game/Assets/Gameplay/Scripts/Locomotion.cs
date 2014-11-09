using UnityEngine;
using System.Collections;

public class Locomotion : MonoBehaviour {
	
	public float SpeedMultiplier;
	public float JumpMultiplier;
	public float Speed;
	public bool Kneel;
	public bool Jump;
	public bool Grounded;
	private bool leftCollision;

	private Animator ani;
	private Animator Animation {
		get {
			if (ani==null) 
				ani = GetComponent<Animator>();
			return ani;
		}
	}

	private Rigidbody2D rb;
	public Rigidbody2D Rigid {
		get {
			if (rb==null)
				rb = GetComponent<Rigidbody2D>();
			return rb;
		}
	}

	private int SpeedId {
		get {
			return Animator.StringToHash("Speed");
		}
	}
	
	private int KneelId {
		get {
			return Animator.StringToHash("Kneel");
		}
	}
	
	private int JumplId {
		get {
			return Animator.StringToHash("Jump");
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Speed = Input.GetAxis ("Horizontal") * 2;
		if (Grounded) {
			Kneel = Input.GetButton ("Kneel");
			Jump = Input.GetButton ("Jump");
		} else {
			Kneel = false;
			Jump = false;
		}
		Animation.SetBool (KneelId,Kneel);
		Animation.SetBool (JumplId,!Grounded);
		Animation.SetFloat (SpeedId,Speed);
		//Animation.SetBool (ShootId,Input.GetButton ("Fire"));
	}

	void FixedUpdate() {
		if (!Kneel) {
			Rigid.velocity = new Vector2 (Speed * SpeedMultiplier, Rigid.velocity.y);
		}
		if (Jump) {
				Rigid.AddForce (Vector2.up * JumpMultiplier, ForceMode2D.Force);
		}
		if (leftCollision) {
			Grounded = false;
			leftCollision = false;
		}
	}

	IEnumerator OnCollisionStay2D(Collision2D  collisionInfo) {
		yield return new WaitForFixedUpdate ();
		if (collisionInfo.gameObject.tag == "Ground" &&
		    collisionInfo.transform.position.y < (transform.position.y))
		{
			Grounded = true;
		}
	}

	void OnCollisionExit2D() {
		leftCollision = true;
	}
}
