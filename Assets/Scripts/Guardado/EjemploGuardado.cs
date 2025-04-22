using UnityEngine;
using UnityEngine.UIElements;

// librerías de .NET
using System;
using System.IO;

public class EjemploGuardado : MonoBehaviour
{

    string RUTA_ARCHIVO; 

    // Serialización 
    // serializar / deserializar objeto - cambiar su representación entre 
    // string y un objeto del tipo del lenguaje

    [Serializable]
    public class Alumno
    {
        public string _nombre;
        public int _edad;
    }

    [SerializeField]
    private Alumno _alumnoEjemplo;

    [SerializeField]
    private Alumno[] _arreglitoEjemplo;

    private string _jsonObjeto;

    // 2 maneras de guardar datos a disco duro 
    // - para datos fáciles y rápidos - playerprefs
    // - para datos robustos / grandes - guardar archivo 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RUTA_ARCHIVO = Application.persistentDataPath + "/savefile.save";
    }

    // Update is called once per frame
    void Update()
    {
        // PLAYERPREFS
        // preferencias de jugador
        if(Input.GetKeyDown(KeyCode.Q))
        {
            // guardar un dato en playerprefs
            PlayerPrefs.SetString("ejemplo1", "HOLA AMIGUITOS!");
            PlayerPrefs.Save();
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            if(PlayerPrefs.HasKey("ejemplo1"))
                print(PlayerPrefs.GetString("ejemplo1", "NO HAY LLAVE!"));
            else
                print("LA LLAVE NO EXISTE!");
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.DeleteKey("ejemplo1");
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            _jsonObjeto = JsonUtility.ToJson(_alumnoEjemplo);
            print(_jsonObjeto);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            Alumno objeto = JsonUtility.FromJson<Alumno>(_jsonObjeto);
            //print(objeto._nombre);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            // para escribir un archivo necesitamos un path 
            // path? 
            string path = RUTA_ARCHIVO;
            print(path);

            File.WriteAllText(path, _jsonObjeto);
            
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(File.Exists(RUTA_ARCHIVO))
            {
                _jsonObjeto = File.ReadAllText(RUTA_ARCHIVO);
            }
        }
    }
}
