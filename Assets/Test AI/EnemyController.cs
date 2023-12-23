using System.Collections.Generic;
using UnityEngine;
using UnityHFSM;

namespace CatUp
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Transform[] pathPoints;

        private StateMachine machine;

        public List<Node> nodes;

        // Start is called before the first frame update
        void Start()
        {
            machine = new StateMachine();

            nodes = new List<Node>
            {
                new Patrol(GetComponent<PathPoints>().GetPathPoints()),
                new Idle()
            };

            machine.AddState("Patrol", onLogic: state => nodes[0].Perform(),
                onEnter: state => nodes[0].OnStateEnter(),
                onExit: state => nodes[0].OnStateExit());

            machine.AddState("Idle", onLogic: state => nodes[1].Perform(),
                onEnter: state => nodes[1].OnStateEnter(),
                onExit: state => nodes[1].OnStateExit());

            machine.SetStartState("Idle");

            machine.AddTwoWayTransition("Idle", "Patrol", transition => nodes[0].exitCondition);

            machine.Init();

        }

        public void AddTriggerTransition(string triggetName, string fromTransition, string toTransition)
        {
            machine.AddTriggerTransition(triggetName, fromTransition, toTransition);
        }

        public void TriggerTransition(string triggetName)
        {
            machine.Trigger(triggetName);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                nodes[0].exitCondition = !nodes[0].exitCondition;
            }

            machine.OnLogic();
        }
    }

}