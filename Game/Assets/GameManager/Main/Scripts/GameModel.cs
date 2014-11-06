using UnityEngine;
using System.Collections;

public class GameModel : MonoBehaviour {

	private static GameModel current;
	public static GameModel Current {
		get {
			return GameModel.current;
		}
	}

	public void InitialInit() {
		DontDestroyOnLoad (gameObject);
		current = this;
	}

	public void CurrentSceneInit() {
	}

	// Update is called once per frame
	void Update () {
	
	}
}
