using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;


public class EnemyController : MonoBehaviour , Activate , DeActivate
{
    [SerializeField] private float speed = 10f;
    [SerializeField] Transform originPos;

    private Transform playerPos;
    private NavMeshAgent nav;

    private void Start() 
    {
        nav = GetComponent<NavMeshAgent>();     
    }

    public void Activate()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Debug.Log("Ac");
        moveToPlayer();
    }

    public void DeActivate()
    {
        playerPos = null;
        StartCoroutine(_MoveToOrigin());
        Debug.Log("De");
    }

    private void moveToPlayer()
    {
        Debug.Log("Find Enemy");
        movement(playerPos.position,speed);
    }

    private void moveToOrigin()
    {
        float speeds = speed /2;
        movement(originPos.position,speeds);
    }

    IEnumerator _MoveToOrigin()
    {
        moveToOrigin();

        while(nav.remainingDistance <= 0.1f)
        {
            moveToOrigin();
            yield return null;
        }
    }

    private void movement(Vector3 target , float speed)
    {
        nav.speed = speed;
        nav.SetDestination(target);
        //use animation here
    }
}
