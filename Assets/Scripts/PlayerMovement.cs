using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody _rb;
    public bool canMoveRight;
    public bool canMoveLeft;
    public LayerMask rayMask;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMovement = transform.forward * (speed * Time.fixedDeltaTime);
        _rb.MovePosition(_rb.position + forwardMovement);
    }

    private void Update()
    {
        
        var rightRay = new Ray(transform.position,transform.right);
        var leftRay = new Ray(transform.position,-transform.right);
        RaycastHit hit;
        if (Physics.Raycast(rightRay, out hit, 3, rayMask))
        {
            canMoveRight = false;
        }
        else canMoveRight = true;

        if ( Physics.Raycast(leftRay, out hit, 3, rayMask))
        {
            canMoveLeft = false;
        }else canMoveLeft = true;

        if (Input.GetKeyDown(KeyCode.A) && canMoveLeft)
        {
            transform.position += Vector3.left*2;
        }if (Input.GetKeyDown(KeyCode.D) && canMoveRight)
        {
            transform.position += Vector3.right*2;
        }
    }

}
