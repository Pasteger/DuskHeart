using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuskHeart.Scripts.Data
{
	public class WorldLoader : MonoBehaviour
	{
		public IEnumerator Load()
		{
			yield return SceneManager.LoadSceneAsync("OverworldScene", LoadSceneMode.Single);
		}
	}
}
