using UnityEngine;
using System.Collections;

namespace ramses {
	namespace GameManager {

		public enum Level {
			Menu
		};

		[RequireComponent (typeof (GameModel))]
		public class Loader : MonoBehaviour {
			
			public Level initialLevel;

			public Level CurrentLevel {
				get {
					return StringToLevel(Application.loadedLevelName);
				}
			}

			public Level StringToLevel(string name) {
				return (Level)System.Enum.Parse (typeof(Level), name);
			}
			
			public void LoadLevel(Level level, bool reload = false) {
				if (reload || CurrentLevel != level)
					Application.LoadLevel (level.ToString ("G"));
			}

			public void InitialInit() {
				LoadLevel (initialLevel);
			}
		}
	}
}