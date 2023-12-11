using Cinemachine;
using Hertzole.GoldPlayer;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    //Rotation
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    //Recoil
    [SerializeField] private float recoilX;
    [SerializeField] private float recoilY;
    [SerializeField] private float recoilZ;

    //Settings
    [SerializeField] private float snappines;
    [SerializeField] private float returnSpeed;


    void Start()
    {
        
    }

    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation,Vector3.zero,returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation,targetRotation,snappines * Time.fixedDeltaTime);
        //cam.ApplyRecoil(1f, 0.1f);
        //cam.ApplyRecoil(1,1);// = Quaternion.Euler(currentRotation);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }


    public void RecoilFire()
    {
        //targetRotation += new Vector3(recoilX,Random.Range(-recoilY,recoilY),Random.Range(-recoilZ,recoilZ));
        targetRotation += new Vector3(Random.Range(-recoilX, recoilX), Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
        //FindObjectOfType<GoldPlayerController>().Camera.ApplyRecoil(1f, 2f);
        //cam.CameraShake(1,1,1);

        Debug.Log("recoil set 1");
    }
}
