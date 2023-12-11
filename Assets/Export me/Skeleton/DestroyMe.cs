using Hertzole.GoldPlayer;
using UnityEngine;
using UnityEngine.AI;

public class DestroyMe : MonoBehaviour
{
    [SerializeField]
    private GameObject[] disableMe;

    [SerializeField]
    private GameObject[] enableMe;

    [SerializeField]
    private AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        AnimatorStateInfo animationState = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        GetComponent<Animator>().Play(animationState.fullPathHash,0,Random.Range(0f,1f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            DestroyMeP();


        }
    }

    public void DestroyMeP()
    {
        deathSound.Play();
        GetComponent<Animator>().StopPlayback();
        GetComponent<Animator>().enabled = false;
        GetComponent<NavMeshAgent>().isStopped = true;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<FollowPlayer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        //foreach(GameObject part in disableMe)
        //{
        //    part.AddComponent<Rigidbody>();
        //}

        foreach (GameObject go in disableMe)
        {
            go.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }

        foreach (GameObject go in enableMe)
        {
            go.GetComponent<MeshRenderer>().enabled = true;
            go.AddComponent<Rigidbody>();
            go.GetComponent<Rigidbody>().AddForce((transform.position - FindObjectOfType<GoldPlayerController>().gameObject.transform.position) * 100);
        }
    }
}
