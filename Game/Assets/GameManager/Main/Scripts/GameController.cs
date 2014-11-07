using UnityEngine;
using System.Collections;

namespace ramses {
	namespace GameManager {

		[RequireComponent (typeof (LocalLoader))]
		public class GameController : MonoBehaviour {

			public GameObject gameModel;

			private GameObject Data;
			public GameModel data {
				get {
					return Data.GetComponent<GameModel>();
				}
			}

			// Use this for initialization
			void Start () {
				Data = GameObject.FindGameObjectWithTag ("GameModel");
				if (Data == null) {
					Data = (GameObject) Instantiate(gameModel,transform.position, transform.rotation);
					Data.name = gameModel.name;
					data.InitialInit();
				}
				data.CurrentSceneInit ();
			}

		}
	}
}