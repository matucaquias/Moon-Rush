using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody _rb;
    public float speed;
    public bool isBeingAttacked;
    public LayerMask environmentMask;
    public LayerMask enemyMask;
    public bool canMoveRight;
    public bool canMoveLeft;
    public float changeMovementCounter;
    public float timeToMove;
    private PlayerMovement _player;
    public GameObject enemyMesh;

    private bool _hasPlayedEatSound = false;
    public AudioSource audioSource;
    public AudioClip eat;
    public GameManager gm;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = FindObjectOfType<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        /*
        changeMovementCounter += Time.fixedDeltaTime;
        if (changeMovementCounter > timeToMove)
        {
            int numero = Random.Range(0, 30);
            if(numero <= 10)
            {
                changeMovementCounter = 0;
                CheckingWalls(0);

            }
            if(numero > 10 && numero <= 20)
            {
                changeMovementCounter = 0;
                CheckingWalls(1);
            } 
            if(numero > 20)
            {
                changeMovementCounter = 0;
            }
        }*/
        if (!isBeingAttacked && !gm.canTransform)
        {
            Vector3 forwardMovement = transform.forward * (speed * Time.fixedDeltaTime);
            if (_player.isWolf)
            {
                enemyMesh.transform.eulerAngles = new Vector3(0, 180, 0);
                _rb.MovePosition(_rb.position + forwardMovement);

            }
            else
            {
                enemyMesh.transform.eulerAngles = new Vector3(0, 0, 0);

                _rb.MovePosition(_rb.position + forwardMovement);
            }
        }
        else
        {
            if (!_hasPlayedEatSound)
            {
                audioSource.PlayOneShot(eat);
                _hasPlayedEatSound = true;
            }
        }


    }/*
    void CheckingWalls(int action)
    {
        var rightRay = new Ray(transform.position, transform.right);
        var leftRay = new Ray(transform.position, -transform.right);
        RaycastHit hit;
        if (Physics.Raycast(rightRay, out hit, 4, environmentMask) || Physics.Raycast(rightRay, out hit, 3, enemyMask))
        {
            canMoveRight = false;
        }
        else
        {
            canMoveRight = true;
            if (action == 0)
            {
                transform.position += Vector3.right * 2;
            }
            
        }

        if (Physics.Raycast(leftRay, out hit, 4, environmentMask) || Physics.Raycast(leftRay, out hit, 3, enemyMask))
        {
            canMoveLeft = false;
        }
        else
        {
            if (action == 1)
            {
                transform.position += Vector3.left * 2;

                canMoveLeft = true;
            }

           
        }
        
    }*/
}
