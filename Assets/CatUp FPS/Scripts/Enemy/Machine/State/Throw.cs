using UnityEngine;
using UnityEngine.AI;

namespace CatUp
{
    public class Throw : State
    {
        private float exitDistance = 25f;
        private float exitTimer;
        private float exitTime = 3f;

        public Throw(MachineData data) : base(data)
        {

        }

        public override void OnStateEnter()
        {
            data.animator.SetBool("Throw", true);
            exitTimer = 0f;
            data.meshAgent.isStopped = true;
        }

        public override void OnStateExit()
        {
            data.animator.SetBool("Throw", false);
            exitCondition[0] = false;
            exitCondition[1] = false;
            data.meshAgent.isStopped = false;
        }

        public override void Perform()
        {
            
            data.agent.transform.LookAt(data.target);

            //Debug.Log(Vector3.Distance(data.target.position, data.agent.position));

            if (Vector3.Distance(data.target.position, data.agent.position) > exitDistance)
            {
                exitCondition[0] = true;
            }

            NavMeshPath navMeshPath = new NavMeshPath();
            NavMesh.CalculatePath(data.agent.position, data.target.position, Physics.DefaultRaycastLayers, navMeshPath);


            if (navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                exitCondition[1] = true;
            }

            RaycastHit hit;

            Debug.DrawLine(data.agent.position + data.agent.transform.up * 2, data.target.position + data.agent.transform.up * 2, Color.red, 1f);
            if (Physics.Linecast(data.agent.position + data.agent.transform.up * 2, data.target.position + data.agent.transform.up * 2, out hit, LayerMask.GetMask("Default")))
            {
                exitTimer += Time.deltaTime;
                if (exitTimer >= exitTime)
                {
                    exitCondition[0] = true;
                }
                //Debug.Log(hit.collider.gameObject.name);
                //exitCondition[0] = true;

                //Debug.DrawRay(data.agent.position, data.target.position - data.agent.position,Color.red, 1f);
            }
            else
            {
                exitTimer = 0f;
            }
        }
    }

}