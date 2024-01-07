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
        private Throw throwState;

        [SerializeField]
        public Path path;

        protected void Start()
        {
            machine = new StateMachine();

            data = new MachineData();
            data.agent = transform;
            data.animator = GetComponent<Animator>();
            data.meshAgent = GetComponent<NavMeshAgent>();
            data.audioPlayer = GetComponent<AudioPlayer>();


            patrolState = new Patrol(data, path.Points);


            endGameIdle = new Idle(data, false);
            patrolIdle = new Idle(data, true);
            followTargetState = new FollowTarget(data, GetComponent<NavMeshAgent>());
            dealDamageState = new DealDamage(data);
            throwState = new Throw(data);

            statesToInitialize = new List<State>
            {
                patrolState,
                endGameIdle,
                followTargetState,
                dealDamageState,
                patrolIdle,
                throwState
            };

            InitializeStates();

            if (path.Points.Length <= 1)
            {
                machine.SetStartState(endGameIdle);
            }
            else
            {
                machine.SetStartState(patrolIdle);
            }

            machine.AddTransition(patrolIdle, patrolState, transition => patrolIdle.exitCondition[0]);
            machine.AddTransition(patrolState, patrolIdle, transition => patrolState.exitCondition[0]);

            machine.AddTransition(followTargetState, dealDamageState, transition => followTargetState.exitCondition[0]);
            machine.AddTransition(dealDamageState, followTargetState, transition => dealDamageState.exitCondition[0]);

            machine.AddTransition(followTargetState, throwState, transition => followTargetState.exitCondition[1]);
            machine.AddTransition(throwState, endGameIdle, transition => throwState.exitCondition[0]);
            machine.AddTransition(throwState, followTargetState, transition => throwState.exitCondition[1]);


            machine.AddTriggerTransition("TargetDetected", patrolIdle, followTargetState);
            machine.AddTriggerTransition("TargetDetected", patrolState, followTargetState);
            machine.AddTriggerTransition("TargetDetected", endGameIdle, followTargetState);

            machine.AddTriggerTransition("Idle", dealDamageState, endGameIdle);


            machine.Init();
        }
    }

}