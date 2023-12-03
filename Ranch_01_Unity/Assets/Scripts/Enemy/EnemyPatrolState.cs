using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System;
public class EnemyPatrolState : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int index;

    float threshhold;

    public bool reverse;


    private void Start()
    {
        threshhold = .05f;
        index = 0;
        StartCoroutine(FollowPath());
    }
    IEnumerator FollowPath()
    {
        while (true)
        {
            foreach (Transform point in patrolPoints)
            {
                yield return StartCoroutine(Move(point));
            }
            if (reverse == true)
            {
                Array.Reverse(patrolPoints);
            }
        }
    }
    IEnumerator Move(Transform point)
    {
       yield return new WaitForSeconds(waitTime);
       while (Vector2.Distance(transform.position, point.position) >= threshhold)
        {
            transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
            Vector2 direction = new Vector2(point.position.x - transform.position.x, point.position.y - transform.position.y);
            transform.up = direction;
            yield return null;

        }

    }

}
