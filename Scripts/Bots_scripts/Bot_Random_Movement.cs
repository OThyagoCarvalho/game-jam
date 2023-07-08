using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Bot_Random_Movement : MonoBehaviour {
   
GameObject player;
NavMeshAgent agent;
[SerializeField] LayerMask whatIsGround, whatIsPlayer;

//patroling
Vector3 destinationPoint;
bool hasDestination;
bool isPatroling;
[SerializeField] float patrolingRadius;

void Start(){
    agent = GetComponent<NavMeshAgent>();
    player = GameObject.Find("Player");
    isPatroling = true;
}

void Update(){
  Patrol();  

}

void Patrol(){
    if (!hasDestination) GetDestinationPoint();
    if (hasDestination) agent.SetDestination(destinationPoint);
    if (Vector3.Distance(transform.position, destinationPoint) < 10) hasDestination = false;
}

void GetDestinationPoint(){
    float randomZ = Random.Range(-patrolingRadius, patrolingRadius);
    float randomX = Random.Range(-patrolingRadius, patrolingRadius);    
    destinationPoint = new Vector3(agent.transform.position.x + randomX, transform.position.y, agent.transform.position.z + randomZ);
    if (Physics.Raycast(destinationPoint, Vector3.down, whatIsGround)) hasDestination = true;
    }


}