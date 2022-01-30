using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3;
    public float humanSpeed;
    public float wolfSpeed;
    private Rigidbody _rb;
    public bool canMoveRight;
    public bool canMoveLeft;
    public LayerMask environmentMask;
    public Transform groundChecker;
    private bool _isGrounded;
    public float jumpForce;
    public bool isAttacking;
    public bool isWolf; // la vamos a usar cuando choca con cosas, para restablecer luego los stats.
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Forward Movement
        if (!isAttacking)
        {
            Vector3 forwardMovement = transform.forward * (speed * Time.fixedDeltaTime);
            _rb.MovePosition(_rb.position + forwardMovement);
        }
        
        GroundChecker();
    }

    private void Update()
    {
        
        CheckingWalls();

        if (!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.D) && canMoveLeft)
            {
                transform.position += Vector3.left*2;
            }if (Input.GetKeyDown(KeyCode.A) && canMoveRight)
            {
                transform.position += Vector3.right*2;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    //Check if is on the ground
    void GroundChecker()
    {
        _isGrounded = false;
        Collider[] colliders = Physics.OverlapSphere(groundChecker.position, .2f, environmentMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                _isGrounded = true;
            }
        }
    }

    //Check if is near to the wall
    void CheckingWalls()
    {
        var rightRay = new Ray(transform.position,transform.right);
        var leftRay = new Ray(transform.position,-transform.right);
        RaycastHit hit;
        if (Physics.Raycast(rightRay, out hit, 3, environmentMask))
        {
            canMoveRight = false;
        }
        else canMoveRight = true;

        if ( Physics.Raycast(leftRay, out hit, 3, environmentMask))
        {
            canMoveLeft = false;
        }else canMoveLeft = true;
    }

    void Jump()
    {
        if (_isGrounded)
        {
            _isGrounded = false;
            _rb.AddForce(new Vector2(0f,jumpForce));
            StartCoroutine(WaitFunc(1));
        }
    }


    IEnumerator WaitFunc(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public void SlowsDown()
    {
        StartCoroutine(SlowDown(1));
    }
    IEnumerator SlowDown(float seconds)
    {
        speed = speed - 1.5f;
        yield return new WaitForSeconds(seconds);
        if (isWolf)
        {
            speed = wolfSpeed;
        }
        else
        {
            speed = humanSpeed;
        }
    }
}
