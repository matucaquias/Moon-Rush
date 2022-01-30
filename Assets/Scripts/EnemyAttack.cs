using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject proyectile;
    public bool canAttack;
    public Transform weaponEnd;
    public float counterAttack;
    public float attackTime;
    public float force;

    public Transform player;
    public LayerMask enemyMask;
    public int type;
    public Animator anim;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        attackTime = Random.Range(3, 10);

    }

    // Update is called once per frame
    void Update()
    {
        counterAttack += Time.deltaTime;
        if (counterAttack >= attackTime)
        {
            CheckEnemyInFront();
            if (canAttack && !gm.canTransform)
            {
                anim.SetInteger("type", type);
                anim.SetTrigger("attack");
                
                counterAttack = 0;
                attackTime = Random.Range(3, 10);
            }
                        
        }
    }
    public void CheckEnemyInFront()
    {
        var frontRay = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(frontRay, out hit, 100, enemyMask))
        {
            canAttack = false;
        }
        else canAttack = true;

        counterAttack = 0;
    } 
    public void Attack()
    {
        GameObject bulletInst = Instantiate(proyectile, weaponEnd.position, Quaternion.Euler(proyectile.transform.eulerAngles.x, proyectile.transform.eulerAngles.y, proyectile.transform.eulerAngles.z));
        bulletInst.transform.forward = transform.forward;
    }
}
