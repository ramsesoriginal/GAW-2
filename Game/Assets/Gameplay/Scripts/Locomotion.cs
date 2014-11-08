using UnityEngine;
using System.Collections;

public class Locomotion : MonoBehaviour {

	public float Speed;
	public bool Kneel;
	public bool Jump;

	private Animator ani;
	private Animator Animation {
		get {
			if (ani==null) 
				ani = GetComponent<Animator>();
			return ani;
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
		Kneel = Input.GetButton ("Kneel");
		Jump = Input.GetButton ("Jump");
		Animation.SetBool (KneelId,Kneel);
		Animation.SetBool (JumplId,Jump);
		Animation.SetFloat (SpeedId,Speed);
	}
}
