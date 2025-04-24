using TMPro;
using UnityEngine;

public class Carta : MonoBehaviour
{
    [SerializeField]
    private EjemploScriptableObject _datos;

    [SerializeField]
    private TMP_Text _texto1; 

    [SerializeField]
    private TMP_Text _texto2; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _texto1.text = _datos.valor + "";
        _texto2.text = _datos.figura;

        //
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
