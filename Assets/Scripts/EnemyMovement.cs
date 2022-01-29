using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody _rb;
    public float speed;
    public bool isBeingAttacked;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isBeingAttacked)
        {
            Vector3 forwardMovement = transform.forward * (speed * Time.fixedDeltaTime);
            _rb.MovePosition(_rb.position + forwardMovement);
        }
    }
}
