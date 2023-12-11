using Hertzole.GoldPlayer;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private NavMeshAgent meshAgent;

    // Start is called before the first frame update
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<GoldPlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //meshAgent.SetDestination(target.position);
    }

    public void OnCollisionEnter(Collision collision)
    {
        //GetComponent<Rigidbody>().enabled = false;
        Destroy(GetComponent<Rigidbody>());
        meshAgent.enabled = true;
        meshAgent.SetDestination(target.position);
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    //meshAgent.SetDestination(target.position);
    //}
}
