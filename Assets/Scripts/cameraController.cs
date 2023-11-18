using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveCamera(int pos)
    {
        if(pos == 1){
            transform.position = new Vector3(-1, 4, -20);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(pos == 2){
            transform.position = new Vector3(0, -22, 0);
            transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
        else if(pos == 3){
            transform.position = new Vector3(18, 15, 18);
            transform.rotation = Quaternion.Euler(30, 225, 0);
        }
    }
}
