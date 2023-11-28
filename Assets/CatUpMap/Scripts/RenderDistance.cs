using UnityEngine;

public class RenderDistance : MonoBehaviour
{
    [SerializeField]
    private float NearObjectsDrawDistance;
    [SerializeField]
    private float StandartObjectsDrawDistance;
    [SerializeField]
    private float CheckpointDrawDistance;
    [SerializeField]
    private float DestroyingPlatformDrawDistance;

    void Start()
    {
        Camera camera = GetComponent<Camera>();
        float[] distances = new float[32];
        distances[0] = StandartObjectsDrawDistance;
        distances[6] = NearObjectsDrawDistance;
        distances[8] = CheckpointDrawDistance;
        distances[9] = DestroyingPlatformDrawDistance;
        camera.layerCullDistances = distances;
    }
}
