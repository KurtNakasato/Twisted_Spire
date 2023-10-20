using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public bool isPlayerVisible;

    Transform playerPosition;

    private void Start()
    {
        viewRadius = 1f;
        viewAngle = 1f;
        isPlayerVisible = false;
        playerPosition = null;
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds (delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        isPlayerVisible = false;
        playerPosition = null;
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);
        for (int i = 0; i< targetsInViewRadius.Length; i++) {
            Transform target = targetsInViewRadius[i].transform;

            Vector2 dirToTarget = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position,dirToTarget,dstToTarget,obstacleMask))
                {
                    isPlayerVisible = true;
                    playerPosition = target.transform;
                }
            }
        }
    }

    public Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        //suposed to account for rotating character. i dont think its y though
        if (!angleIsGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z;
        }
        //Out puts the x and y side lengths of the triangle formed with angle indegrees in the unit circle.
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        //because dirfrom angle shows x and y triangle side length, we need to divide by two to get half. 
        Vector2 viewAngleA = DirFromAngle(-viewAngle / 2, false);
        Vector2 viewAngleB = DirFromAngle(viewAngle / 2, false);

        Debug.Log("A" + viewAngleA);
        Debug.Log("B" + viewAngleB);

        //Add direction + our current position and make direction * radius. Direction can only be 0-1, the radius is 1- something less than 1. so this makes sense.
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x,transform.position.y) + viewAngleA * viewRadius);
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + viewAngleB * viewRadius);

        if (playerPosition != null) {
            Gizmos.DrawLine(transform.position, playerPosition.position);
        }
    }

}
