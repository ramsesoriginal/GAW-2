using UnityEngine;
using System.Collections;

namespace ramses {
	namespace GameManager {

		[RequireComponent (typeof (GameController))]
		public class LocalLoader : MonoBehaviour {

			private GameController controller {
				get {
					return GetComponent<GameController>();
				}
			}

			private GameModel data {
				get {
					return controller.data;
				}
			}
			
			private Loader loader {
				get {
					return data.loader;
				}
			}

			public void LoadMenu() {
				LoadLevel (Level.Menu);
			}
			
			public void LoadLevel(Level level) {
				loader.LoadLevel (level);
			}
			
			public void LoadLevel(string level) {
				LoadLevel (loader.StringToLevel(level));
			}
		}
	}
}