
using UnityEngine;

public abstract class MakeSingleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject gobj = new GameObject();
                    gobj.name = typeof(T).Name;
                    _instance = gobj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }



    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}