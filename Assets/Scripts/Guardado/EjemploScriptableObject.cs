using UnityEngine;


// Scriptable Object! 
// una clase que define un objeto contenedor de datos 
// tiene un ciclo de vida que se puede utilizar
// el caso de uso más común es contener información
[CreateAssetMenu(fileName = "EjemploScriptableObject", menuName = "Ejemplito/EjemploScriptableObject")]
public class EjemploScriptableObject : ScriptableObject
{
    // normalmente lo que tenemos aquí son datos
    public int valor;
    public string figura;

    

}
