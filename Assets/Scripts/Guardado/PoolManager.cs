using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public static PoolManager Instance {
        get;
        private set;
    }

    [SerializeField]
    private GameObject _original;

    [SerializeField]
    private int _poolSize;

    private Queue<GameObject> _poolQueue;

    void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _poolQueue = new Queue<GameObject>();

        for(int i = 0; i < _poolSize; i++) 
        {
            // instanciar objeto
            GameObject nuevoObjeto = Instantiate(_original);
            nuevoObjeto.SetActive(false);
            _poolQueue.Enqueue(nuevoObjeto);
        }
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation) 
    {
        GameObject objeto = _poolQueue.Dequeue();
        objeto.SetActive(true);
        objeto.transform.position = position;
        objeto.transform.rotation = rotation;
        return objeto;
    }
}
