using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityHFSM;

namespace CatUp
{
    public class SkeletonMachine : Machine
    {
        private Patrol patrolState;
        private Idle endGameIdle;
        private Idle patrolIdle;
        private FollowTarget followTargetState;
        private DealDamage dealDamageState;

        protected void Start()
        {
            machine = new StateMachine();

            machineData = new MachineData();
            machineData.agent = transform;
            machineData.animator = GetComponent<Animator>();
            machineData.meshAgent = GetComponent<NavMeshAgent>();
            machineData.audioPlayer = GetComponent<AudioPlayer>();

            patrolState = new Patrol(machineData, GetComponent<Path>().Points);
            endGameIdle = new Idle(machineData, false);
            patrolIdle = new Idle(machineData, true);
            followTargetState = new FollowTarget(machineData, GetComponent<NavMeshAgent>());
            dealDamageState = new DealDamage(machineData);

            statesToInitialize = new List<State>
            {
                patrolState,
                endGameIdle,
                followTargetState,
                dealDamageState,
                patrolIdle
            };

            InitializeStates();

            if(GetComponent<Path>().Points.Length == 0)
            {
                machine.SetStartState(endGameIdle);
            }
            else
            {
                machine.SetStartState(patrolIdle);
            }

            machine.AddTransition(patrolIdle, patrolState, transition => patrolIdle.exitCondition);
            machine.AddTransition(patrolState, patrolIdle, transition => patrolState.exitCondition);

            machine.AddTransition(followTargetState, dealDamageState, transition => followTargetState.exitCondition);
            machine.AddTransition(dealDamageState, followTargetState, transition => dealDamageState.exitCondition);

            machine.AddTriggerTransition("TargetDetected", patrolIdle, followTargetState);
            machine.AddTriggerTransition("TargetDetected", patrolState, followTargetState);
            machine.AddTriggerTransition("TargetDetected", endGameIdle, followTargetState);

            machine.AddTriggerTransition("Idle", dealDamageState, endGameIdle);

            machine.Init();
        }
    }

}