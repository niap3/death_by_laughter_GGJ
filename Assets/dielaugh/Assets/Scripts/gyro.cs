using UnityEngine;

public class Gyro : MonoBehaviour
{
    public Vector3 endpos = new(0f, 10f, -20f);
    private Vector3 startpos;
    private float dur = 2f;
    private float elapsedtime;
    private bool gyroenabled;
    private Gyroscope gyro;
    private GameObject cameracontainer;
    private Quaternion rot;

    private void Start()
    {
        cameracontainer = new GameObject("Camera Container");
        cameracontainer.transform.position = transform.position;
        transform.SetParent(cameracontainer.transform);
        startpos = cameracontainer.transform.position;
        gyroenabled = EnableGyro();
    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            cameracontainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;

    }
    private void Update()
    {
        if (gyroenabled)
        {
            transform.localRotation = gyro.attitude * rot;
        }
        elapsedtime += Time.deltaTime;
        float percentcomp = elapsedtime / dur;
        transform.position = Vector3.Lerp(startpos, endpos, percentcomp);
    }
}
