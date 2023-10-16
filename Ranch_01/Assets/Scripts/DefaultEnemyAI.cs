using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

public class DefaultEnemyAI : MonoBehaviour
{

    public float speed;
    public float wonderingCircleRadius;
    public float wonderingTargetLocationBufferMinVal;
    public float wonderingTargetLocationBufferMaxVal;

    private String currentState;

    private Vector2 startPosition;
    private Vector2 targetPosition;

    private float threshold;
    private float timer;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = GetRandomPointOnCircle(startPosition, wonderingCircleRadius);

        threshold = 1f;
    }

    void Update()
    {
        currentState = "Wondering";

        if (currentState == "Wondering")
        {
            stateWondering();
        }

    }

    private Vector3 GetRandomPointOnCircle(Vector2 center, float radius)
    {
        Vector2 randomPoint =  UnityEngine.Random.insideUnitCircle.normalized;
        return center + new Vector2(randomPoint.x, randomPoint.y) * radius;
    }

    private void stateWondering()
    {
        timer -= Time.deltaTime;
        float distance = Vector2.Distance(transform.position, targetPosition);

        if (timer <= 0f)
        {
            if (distance < threshold)
            {
                targetPosition = GetRandomPointOnCircle(startPosition, wonderingCircleRadius);
                Debug.Log(targetPosition);
                timer = UnityEngine.Random.Range(wonderingTargetLocationBufferMinVal, wonderingTargetLocationBufferMaxVal);
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    



}
