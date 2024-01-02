using UnityEngine;
using UnityEngine.AI;

namespace CatUp
{
    public class FollowTarget : State
    {
        private NavMeshAgent agent;
        private float distance = 3;

        public FollowTarget(MachineData data, NavMeshAgent agent) : base(data)
        {
            this.agent = agent;
        }

        public override void OnStateEnter()
        {
            agent.isStopped = false;
            data.animator.SetTrigger("Run");
        }

        public override void OnStateExit()
        {
            agent.isStopped = true;
            exitCondition[0] = false;
            exitCondition[1] = false;
            data.animator.ResetTrigger("Run");
        }

        public override void Perform()
        {
            if (Vector3.Distance(data.target.position, data.agent.position) < distance)
            {
                exitCondition[0] = true;
            }

            NavMeshPath navMeshPath = new NavMeshPath();
            NavMesh.CalculatePath(agent.transform.position,data.target.position,Physics.DefaultRaycastLayers,navMeshPath);

            if (navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                agent.SetPath(navMeshPath);
            }
            else if(navMeshPath.status == NavMeshPathStatus.PathPartial)
            {
                exitCondition[1] = true;
            }
        }
    }

}