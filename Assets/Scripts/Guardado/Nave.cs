using UnityEngine;

public class Nave : MonoBehaviour
{

    [SerializeField]
    private float _speed = 5;
    

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
            PoolManager.Instance.GetObject(transform.position, transform.rotation);
        }
    }
}
