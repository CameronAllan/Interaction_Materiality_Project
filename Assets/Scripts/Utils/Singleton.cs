using UnityEngine;

/// <summary>
/// Singleton type to be inherited where needed
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public bool dontDestroyOnLoad = false;
    private bool toBeDestroyed = false;
    public bool allowDuplicates = false;
    
    public static T Instance {
        get {
            if (instance == null)
            {
                instance = (T)FindFirstObjectByType(typeof(T));
                if (instance == null)
                {
                    return null;
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            toBeDestroyed = false;
            instance = Instance;
            
        }
        if (instance != null && instance != this && !allowDuplicates)
        {
            toBeDestroyed = true;
            Destroy(gameObject);
            return;
        }
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public virtual void OnEnable()
    {
        if (toBeDestroyed)
        {
            return;
        }
    }

    public virtual void OnDestroy()
    {
        instance = null;
    }
}
