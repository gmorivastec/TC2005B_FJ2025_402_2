using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// tipos genéricos
// mecanismo que nos permite parametrizar un tipo dentro de una clase
// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics

// constraints / límite en tipos 
// https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters

public class PoolManager<T> : MonoBehaviour where T : MonoBehaviour
{

    public static PoolManager<T> Instance {
        get;
        protected set;
    }

    [SerializeField]
    protected GameObject _original;

    [SerializeField]
    protected int _poolSize;

    protected Queue<T> _poolQueue;

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
        _poolQueue = new Queue<T>();

        // si obligamos a tener un componente T necesitamos verificar
        // que el original lo tenga
        if(_original.GetComponent<T>() == null)
        {
            print("ORIGINAL EN POOL MANAGER NO CORRESPONDE AL TIPO QUE SE ESPERA");
            Destroy(gameObject);
            return;
        }

        for(int i = 0; i < _poolSize; i++) 
        {
            // instanciar objeto
            GameObject nuevoObjeto = Instantiate(_original);
            nuevoObjeto.SetActive(false);
            _poolQueue.Enqueue(nuevoObjeto.GetComponent<T>());
        }
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation) 
    {

        if(_poolQueue.Count == 0)
            return null;

        GameObject objeto = _poolQueue.Dequeue().gameObject;
        objeto.SetActive(true);
        objeto.transform.position = position;
        objeto.transform.rotation = rotation;
        return objeto;
    }

    public void ReturnObject(T objeto) 
    {
        objeto.gameObject.SetActive(false);
        _poolQueue.Enqueue(objeto);
    }
}
