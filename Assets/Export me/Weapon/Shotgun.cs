using Hertzole.GoldPlayer;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private ParticleSystem[] shootEffect;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject[] shells;

    private int remainbullets;

    [SerializeField]
    private float shootDelay;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = shootDelay;
        remainbullets = 4;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && timer < 0)
        {
            timer = shootDelay;
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            animator.SetTrigger("reload");
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("HideWeapon");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetTrigger("ShowWeapon");
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if(hit.collider.gameObject.tag == "skeleton")
            {
                hit.collider.gameObject.GetComponent<DestroyMe>().DestroyMeP();
            }
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

        remainbullets--;
        if(remainbullets < 0)
        {
            //animator.gameObject.SetActive(true);
            animator.SetTrigger("reload");
            remainbullets = 4;
            foreach(GameObject go in shells)
            {
                go.SetActive(true);
            }
        }
        else
        {
            shells[remainbullets].SetActive(false);
        }

        FindObjectOfType<GoldPlayerController>().Camera.CameraShake(2,2,1);
        FindObjectOfType<GoldPlayerController>().Camera.ApplyRecoil(3f, 1f);
        FindObjectOfType<Recoil>().RecoilFire();
        //FindAnyObjectByType<GoldPlayerController>().Movement.AddForce(-transform.forward,.1f);

        foreach (ParticleSystem picked in shootEffect)
        {
            picked.Emit(100);
        }
    }
}
