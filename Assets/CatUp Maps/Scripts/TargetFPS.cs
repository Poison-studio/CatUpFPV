using UnityEngine;

namespace CatUp
{
    public class TargetFPS : MonoBehaviour
    {
        [SerializeField]
        private int targetFPS;

        void Start() => Application.targetFrameRate = targetFPS;
    }
}
