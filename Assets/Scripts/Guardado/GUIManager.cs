using TMPro;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    
    [SerializeField]
    private TMP_Text _textito;
    
    public void Balazo()
    {
        _textito.text = "BALAZO!";
    }

    public void CambioDeVidaConArg(int vida)
    {
        _textito.text = "VIDA: " + vida;
    }

    public void CambioDeVidaSinArg()
    {
        _textito.text = "CAMBIO LA VIDA!";
    }
}
