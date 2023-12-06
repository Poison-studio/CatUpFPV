using UnityEngine;

namespace CatUp
{
    public class TargetFPS : MonoBehaviour
    {
        void Start() => Application.targetFrameRate = 60;
    }
}
