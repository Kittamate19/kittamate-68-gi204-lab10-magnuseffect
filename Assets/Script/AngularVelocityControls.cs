using UnityEngine;
using UnityEngine.InputSystem;

public class AngularVelocityControls : MonoBehaviour
{
    public float angularSpeed = 1;
    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            _rb.angularVelocity = new Vector3(0, angularSpeed, 0);
        }
        else
        {
            _rb.angularVelocity = Vector3.zero;
        }
    }
}
