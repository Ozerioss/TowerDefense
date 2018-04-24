using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool moveCamera = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5000f;
    public float minimumY = 10f;
    public float maximumY = 80f;

    void Update()
    {

        if(Input.GetKey(KeyCode.Escape))
        {
            moveCamera = !moveCamera; //toggles camera movement
        }

        if(!moveCamera)
        {
            return;
        }

        if(Input.GetKey("z") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World); // (0,0,1)*30 Space.World takes the global axis instead of local ones
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("q") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); 
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position; //get current position

        pos.y -= scroll * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minimumY, maximumY); // to avoid zooming through the ground or too high up 

        transform.position = pos;
    }

}
