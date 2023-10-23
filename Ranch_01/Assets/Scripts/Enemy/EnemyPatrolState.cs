using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPatrolState : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;

    float threshhold;

    public bool reverse;


    private void Start()
    {
        threshhold = .05f;
        currentPointIndex = 0;
    }

    private void Update()
    {

        StartCoroutine(Wait());
        //Debug.Log(Vector3.Distance(transform.position, patrolPoints[currentPointIndex].position));
        //if (Vector3.Distance(transform.position, patrolPoints[currentPointIndex].position) <= threshhold)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        //    Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        //    Vector2 direction = new Vector2(patrolPoints[currentPointIndex].position.x - currentPos.x, patrolPoints[currentPointIndex].position.y - currentPos.y);
        //    transform.up = direction;
        //}
        //else
        //{
        //   // Debug.Log("Arrived");
        //    if (once == false)
        //    {
        //        once = true;
        //        StartCoroutine(Wait());
        //    }
        //}
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        //yield return null;
        //Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
        //Vector2 direction = new Vector2(patrolPoints[currentPointIndex].position.x - currentPos.x, patrolPoints[currentPointIndex].position.y - currentPos.y);
        //transform.up = direction;

        if (Vector2.Distance(transform.position, patrolPoints[currentPointIndex].position) <= threshhold) {



                if (currentPointIndex + 1 < patrolPoints.Length)
                {
                    currentPointIndex++;
                }
                else
                {
                    if (reverse)
                    {
                        patrolPoints.Reverse();
                    }
                    currentPointIndex = 0;
                }
        }
        yield return null;
        
    }

}
