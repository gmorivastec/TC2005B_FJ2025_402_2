using System.Collections;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    void OnEnable()
    {
        // al igual que con la generación de objetos en el pool necesitamos
        // estrategias de pseudodestrucción (osea, regresar objetos al pool)
        StartCoroutine(RegresarObjeto(3));
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);
    }

    IEnumerator RegresarObjeto(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        BalaPoolManager.Instance.ReturnObject(this);
    }
}
