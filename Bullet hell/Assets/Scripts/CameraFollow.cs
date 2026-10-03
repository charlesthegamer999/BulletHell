using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //set up variables
    //target
    //transition time, how snappy is the camera
    //camera offset, how far away is the camera
    GameObject target;
    //fixed update to move the camera once per frame
    [SerializeField] float transitionTime;
    Vector3 offset = new Vector3(0f, 0f, -20f);


    private void FixedUpdate()
    {
        if(target != null)
        {
            //move the camera to the target position with offset
            Vector3 smoothPosition = Vector3.Lerp(transform.position, target.transform.position + offset, transitionTime * Time.deltaTime);
            transform.position = smoothPosition;
        }
    }

    public void AquireTarget(GameObject newTarget)
    {
        target = newTarget;
        transform.position = target.transform.position;
    }
}
