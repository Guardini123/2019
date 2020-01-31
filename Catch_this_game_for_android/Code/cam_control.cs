using UnityEngine;
using UnityEngine.PostProcessing;
using UnityStandardAssets.ImageEffects;

public class cam_control : MonoBehaviour {
    public float speed_cam;
    private GameObject sphere;

	private Vector2 targetPos;
    void Start ()
	{
        if (PlayerPrefs.GetInt("enable_post_proc") == 1)
        {
            this.GetComponent<PostProcessingBehaviour>().enabled = true;
        } else {
            this.GetComponent<PostProcessingBehaviour>().enabled = false;
        }

        if (PlayerPrefs.GetInt("enable_color_correct") == 1)
        {
            this.GetComponent<ColorCorrectionLookup>().enabled = true;
        }
        else
        {
            this.GetComponent<ColorCorrectionLookup>().enabled = false;
        }
        sphere = GameObject.Find("my_sphere_1");
        targetPos.x = transform.position.x;
        targetPos.y = transform.position.y;
	}
	// Update is called once per frame
	void Update () 
	{
        if (sphere != null)
        {
            targetPos.x = sphere.transform.position.x;
            targetPos.y = sphere.transform.position.y + 2;
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPos.x, speed_cam * Time.deltaTime), Mathf.Lerp(transform.position.y, targetPos.y, speed_cam * Time.deltaTime), transform.position.z);
        } else {
            Debug.Log("!!Sphere not detected!!!");
        }
    }
}
