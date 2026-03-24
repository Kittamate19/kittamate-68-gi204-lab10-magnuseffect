using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusEffect : MonoBehaviour
{
    public float kickForce = 1.0f;
    public float spinAmount = 1.0f; // ��Ѻ��ȷҧ��ѧ������� ����/���
    public float magnusStrength = 0.5f;
    private Rigidbody _rb;
    private bool _isShoot = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !_isShoot)
        {
            // ��Ѻ��ȷҧ�͹�� x, y, z
            _rb.AddForce(0, 4f, kickForce, ForceMode.Impulse);
            // ����١�����ع��������͹���
            _rb.AddRelativeTorque(Vector3.up * spinAmount);
            _isShoot = true;
        }
    }
    void FixedUpdate()
    {
        if (!_isShoot) return;
        Vector3 velocity = _rb.linearVelocity;
        Vector3 spin = _rb.angularVelocity;
        // Cross Product �ҷ�ȷҧ�������������͹����
        Vector3 magnusForce = Vector3.Cross(spin, velocity);
        magnusForce *= magnusStrength;
        _rb.AddForce(magnusForce);
    }
}
