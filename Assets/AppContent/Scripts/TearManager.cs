using UnityEngine;

public class TearManager : MonoBehaviour
{
    public GameObject tear;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

	private int num_tears;
	public GameObject diamond;
	public GameObject basket;
	//public nrt_basket basket;
	//public GameObject clone_tear;
	private bool cry;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
		num_tears = 0;
		cry = true;
    }

	void Update () {
		//Debug.Log ("tear: " + num_tears);
		if (num_tears >= 35) {
			cry = false;
			basket.SetActive (false);
			diamond.SetActive (true);
//			clone_tear = GameObject.Find ("Mask's tear(Clone)");
//			while (clone_tear != null) {
//				Destroy (clone_tear);
//				less_tears ();
//				clone_tear = GameObject.Find ("Mask's tear(Clone)");
//			}
			//basket = GameObject.Find ("basket").GetComponent <nrt_basket> ();
			//basket.stop_cry ();
			//basket.layer = 11;
		}
	}

    void Spawn ()
    {	
		if (cry) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			more_tears ();
			Instantiate (tear, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		}
    }

	public void more_tears(){
		num_tears += 1;
	}

	public void less_tears(){
		num_tears -= 1;
	}
}
