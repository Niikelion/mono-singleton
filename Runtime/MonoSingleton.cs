using JetBrains.Annotations;
using UnityEngine;

namespace Singletons
{
    [PublicAPI]
    public class MonoSingleton<T>: MonoBehaviour where T: MonoBehaviour
    {
        private T thisT;
        
        /// <summary>
        /// Single instance of type <typeparamref name="T"></typeparamref>
        /// <remarks>Can be null when no object is available</remarks>
        /// </summary>
        [CanBeNull] public static T Instance { get; private set; }

        /// <summary>
        /// Method called from duplicate object when it is registering
        /// </summary>
        /// <param name="previous">previous instance</param>
        /// <returns><b>false</b> if duplicate should delete itself, <b>true</b> otherwise</returns>
        protected virtual bool OnDuplicate([CanBeNull] T previous) => false;
        
        /// <summary>
        /// Registers instance
        /// <remarks>Remember to call it from inheriting class when overriding <b>Awake</b></remarks>
        /// </summary>
        protected virtual void Awake()
        {
            thisT = this as T;
            
            if (Instance != null)
            {
                if (!OnDuplicate(Instance))
                    Object.Destroy(thisT);
                
                return;
            }

            Instance = thisT;
        }
    }
}