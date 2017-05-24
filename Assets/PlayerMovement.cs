using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float _speed;
    private float _axisValue;

    private void Start()
    {

    }

    private void Update()
    {
        _axisValue = Input.GetAxis("Horizontal");
        if (_axisValue > 0)
        {
            transform.Translate(new Vector3(_axisValue, 0f, 0f) * Time.deltaTime * _speed);
        }
        else if(_axisValue < 0)
        {
            transform.Translate(new Vector3(_axisValue, 0f, 0f) * Time.deltaTime * _speed);
        }
    }

    private void FlipPlayer()
    {

    }
}
