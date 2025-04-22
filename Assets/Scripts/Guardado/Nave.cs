using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// UnityEvents - eventos de Unity 
// que se apegan al patrón de diseño observer
// https://en.wikipedia.org/wiki/Observer_pattern
// puedes pensar en callbacks de javascript

[Serializable]
public class EventoCon1Arg : UnityEvent<int> {}

public class Nave : MonoBehaviour
{

    [SerializeField]
    private float _speed = 5;

    [SerializeField]
    private UnityEvent _eventoSinArgs;

    [SerializeField]
    private EventoCon1Arg _eventoCon1Arg;

    [SerializeField]
    private int _vida = 100;

    void Start()
    {
        _eventoCon1Arg.Invoke(_vida);
    }

    // para escuchar un evento hay que suscribirse
    // 2 maneras - 
    // 1. por medio del editor
    // 2. programaticamente - _eventoSinArgs.AddListener(funcionACorrer);

    // una vez tengamos elementos suscritos podemos avisarles que el evento 
    // ocurrió

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(
            horizontal * _speed * Time.deltaTime,
            vertical * _speed * Time.deltaTime,
            0
        );

        if(Input.GetButtonDown("Jump"))
        {
            // esta línea le avisa a todos los suscritos 
            // que el evento occurió
            _eventoSinArgs.Invoke();
            BalaPoolManager.Instance.GetObject(transform.position, transform.rotation);

            // aguas! verifica que el objeto no sea nulo si vas a hacer una operación en el
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
        

        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            _vida -= 10;
            _eventoCon1Arg.Invoke(_vida);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            _vida += 10;
            _eventoCon1Arg.Invoke(_vida);
        }
    }
}
