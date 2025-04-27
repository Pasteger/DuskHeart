using System.Collections;
using DuskHeart.Scripts.EntryPoints.ScenesEntryPoints;
using UnityEngine;

namespace DuskHeart.Scripts.EntryPoints
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private EntryPointSceneEntryPoint entryPointSceneEntryPoint;

        private IEnumerator Start()
        {
            yield return Instantiate(entryPointSceneEntryPoint);
        }
    }
}