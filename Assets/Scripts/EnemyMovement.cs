using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody _rb;
    public float speed;
    public bool isBeingAttacked;
    private PlayerMovement _player;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = FindObjectOfType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (!isBeingAttacked)
        {
            Vector3 forwardMovement = _player.transform.forward * (speed * Time.fixedDeltaTime);
            if (!_player.isWolf)
            {
                _rb.MovePosition(_rb.position + forwardMovement);
            }

        }
    }
}
