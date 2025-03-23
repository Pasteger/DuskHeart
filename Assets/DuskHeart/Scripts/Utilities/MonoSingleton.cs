using UnityEngine;

namespace Utilities
{
    public class MonoSingleton<T> : MonoBehaviour where T : class
    {
        public static T Instance { get; private set; }
        protected void Awake()
        {
            InitializeSingleton();
            CustomAwake();
        }

        private void InitializeSingleton()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual void CustomAwake()
        {
        
        }
    }
}
