using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T sharedInstance { get; private set; }
    public virtual void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sharedInstance = this as T;
        }
    }
}
