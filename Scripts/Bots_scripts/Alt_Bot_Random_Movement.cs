using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Alt_Bot_Movement : MonoBehaviour {

GameObject player;
NavMeshAgent agent;
[SerializeField] LayerMask whatIsGround, whatIsPlayer;
[SerializeField] float patrolingSpeed;

//run away from player
[SerializeField]int multiplier = 1;
[SerializeField]Transform Player;
[SerializeField]float range = 30;

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
    //run away from player
    Vector3 runTo = transform.position + ((transform.position - Player.position) * multiplier);
    float distance = Vector3.Distance(transform.position, Player.position);
    if (distance < range) {
     agent.SetDestination(runTo);
     agent.speed = patrolingSpeed;
    }
    //else patrol randomly
    else {
        if (!hasDestination) GetDestinationPoint();
        if (hasDestination) {
            agent.SetDestination(destinationPoint);
            agent.speed = patrolingSpeed;
        }
        if (Vector3.Distance(transform.position, destinationPoint) < 10) hasDestination = false;}
}

void GetDestinationPoint(){

    float randomZ = Random.Range(-patrolingRadius, patrolingRadius);
    float randomX = Random.Range(-patrolingRadius, patrolingRadius);
    destinationPoint = new Vector3(agent.transform.position.x + randomX, transform.position.y, agent.transform.position.z + randomZ);
    if (Physics.Raycast(destinationPoint, Vector3.down, whatIsGround)) hasDestination = true;
    }


}