using System;
using System.Collections;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public float range;
    public float angle;
    public Transform target;
    public LayerMask enemyLayer;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        var Ray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(Ray, out hit, 150, enemyLayer))
        {
            target = hit.transform.GetComponent<Transform>();
            Debug.Log("enemy se acerca");
        }
        if (IsInSight(target))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        _playerMovement.wolfAnim.SetBool("Attacking",true);
        _playerMovement.isAttacking = true;
        target.GetComponent<EnemyMovement>().isBeingAttacked = true;
        target.GetComponent<EnemyAttack>().anim.SetTrigger("die");
        Destroy(target.gameObject,3.7f);
        yield return new WaitForSeconds(3.6f);
        _playerMovement.isAttacking = false;
        _playerMovement.wolfAnim.SetBool("Attacking", false);

    }
    public bool IsInSight(Transform target)
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(target.position, transform.position);
            if (distanceToTarget > range) return false;
            //float angleToTarget = Vector3.Angle(-transform.forward, (target.position - transform.position));
            //if (angleToTarget > angle/2) return false;
            Vector3 direction = target.position - transform.position;
            if (Physics.Raycast(transform.position, direction, distanceToTarget, enemyLayer)) return true;
        }
        return false;
    }
    
    /*private void OnDrawGizmos()
    {
        if (IsInSight(target)) Gizmos.color = Color.green;
        else Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        //Gizmos.DrawRay(transform.position, Quaternion.Euler(0, angle/2, 0) * -transform.forward * range);
        //Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -angle/2, 0) * -transform.forward * range);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, (target.position - transform.position).normalized* range);
    }*/
}
