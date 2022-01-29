using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody _rb;
    public float speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMovement = transform.forward * (speed * Time.fixedDeltaTime);
        _rb.MovePosition(_rb.position + forwardMovement);
    }
}
