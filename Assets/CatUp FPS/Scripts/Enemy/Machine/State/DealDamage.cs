using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatUp
{
    public class DealDamage : State
    {
        private float distance = 4;

        public DealDamage(MachineData machineData) : base(machineData) { }

        public override void OnStateEnter()
        {
            machineData.meshAgent.isStopped = true;
            machineData.animator.SetTrigger("Attack");
        }

        public override void OnStateExit()
        {
            exitCondition = false;
            machineData.meshAgent.isStopped = false;
        }

        public override void Perform()
        {
            float exitTime = machineData.animator.GetCurrentAnimatorStateInfo(0).normalizedTime % machineData.animator.GetCurrentAnimatorClipInfo(0).Length;

            if ((Vector3.Distance(machineData.target.position, machineData.agent.position) > distance) && exitTime > 0.8f)
            {
                exitCondition = true;
            }
        }
    }

}