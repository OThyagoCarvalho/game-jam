using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PapaBot_Movement : MonoBehaviour {
   
GameObject player;
GameObject pinto;
NavMeshAgent agent;
[SerializeField] LayerMask whatIsGround, whatIsPlayer, whatIsPinto;
[SerializeField] float patrolingSpeed;

//run away from player
[SerializeField]int multiplier = 1;
[SerializeField]Transform Player;
[SerializeField]Transform Pinto;
[SerializeField]float range = 30;

//patroling
Vector3 destinationPoint;
bool hasDestination;
bool isPatroling;
[SerializeField] float patrolingRadius;

void Start(){
    agent = GetComponent<NavMeshAgent>();
    player = GameObject.Find("Player");
    pinto = GameObject.Find("Pinto");
    isPatroling = true;
}

void Update(){
  Patrol();  
}

void Patrol(){
    //run towards pinto
    Vector3 runTo = transform.position - ((transform.position - Pinto.position) * multiplier);
    float distance = Vector3.Distance(transform.position, Player.position);
    agent.SetDestination(runTo);
    agent.speed = patrolingSpeed;
    
    
       
}

void GetDestinationPoint(){
    float randomZ = Random.Range(-patrolingRadius, patrolingRadius);
    float randomX = Random.Range(-patrolingRadius, patrolingRadius);    
    destinationPoint = new Vector3(agent.transform.position.x + randomX, transform.position.y, agent.transform.position.z + randomZ);
    if (Physics.Raycast(destinationPoint, Vector3.down, whatIsGround)) hasDestination = true;
    }
}