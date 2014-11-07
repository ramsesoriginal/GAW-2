using UnityEngine;
using System.Collections;

namespace ramses {
	namespace GameManager {

		[RequireComponent (typeof (Loader))]
		public class GameModel : MonoBehaviour {

			private static GameModel current;
			public static GameModel Current {
				get {
					return GameModel.current;
				}
			}

			public Loader loader {
				get {
					return GetComponent<Loader>();
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
	}
}