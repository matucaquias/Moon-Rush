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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counterAttack += Time.deltaTime;
        if (counterAttack >= attackTime)
        {
            CheckEnemyInFront();
            if (canAttack)
            {
                GameObject bulletInst = Instantiate(proyectile, weaponEnd.position, Quaternion.Euler(proyectile.transform.eulerAngles.x, proyectile.transform.eulerAngles.y, proyectile.transform.eulerAngles.z));
                bulletInst.transform.forward = transform.forward;
                counterAttack = 0;
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
}