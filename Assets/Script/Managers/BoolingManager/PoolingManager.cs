using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingID
{
    public const int BaseBullet = 1;
}
public class PoolingManager : MonoSingleton<PoolingManager>
{
    [SerializeField] private List<PoolObjectContainer> _listPoolObjects;
    public Dictionary<int, PoolObjectContainer> _dicObjectHandlers;

    private void Start()
    {
        //Giúp obj này không bị destroy và mang qua scene khác
        DontDestroyOnLoad(this);
        InitPooling();
    }
    public void ClickLoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
    }
    public void InitPooling()
    {
        _dicObjectHandlers = new Dictionary<int, PoolObjectContainer>();
        foreach (PoolObjectContainer p in this._listPoolObjects)
        {
            if (!_dicObjectHandlers.ContainsKey(p._id))
                _dicObjectHandlers.Add(p._id, p);

            p.Init();
        }
    }


    private PoolObjectHandler GetPoolHanler(int id)
    {
        if (_dicObjectHandlers == null) return null;
        if (_dicObjectHandlers.ContainsKey(id))
            return _dicObjectHandlers[id].poolHandler;

        return null;
    }
    public void ReturnObject(PoolObjectHandler pool, GameObject o)
    {
        if (pool != null)
            pool.ReturnObject(o);
    }
    public void ReturnObject(int id, GameObject o)
    {
        PoolObjectHandler pool = GetPoolHanler(id);
        if (pool != null)
            pool.ReturnObject(o);
    }
    public T RequestObject<T>(int id) where T : MonoBehaviour
    {
        PoolObjectHandler pool = GetPoolHanler(id);
        if (pool != null)
            return pool.RequestObject() as T;

        return null;
    }
    public GameObject RequestObject(int id)
    {
        PoolObjectHandler pool = GetPoolHanler(id);
        if (pool != null)
            return pool.RequestObject();

        return null;
    }
}



