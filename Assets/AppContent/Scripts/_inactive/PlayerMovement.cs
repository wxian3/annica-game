// using UnityEngine;
// using System.Collections;
// using Vuforia;

// public class PlayerMovement : MonoBehaviour, ITrackableEventHandler
// {
// 	AudioSource[] sources;
// 	AudioSource backgroundMusic;      
// 	AudioSource jumpSound;
// 	AudioSource MushroomSound;
// 	AudioSource LostLifeSound;
// 	public AudioClip backgroundClip;      
// 	public AudioClip jumpClip;
// 	public AudioClip MushroomClip;
// 	public AudioClip LostLifeClip;
// 	public float turnSmoothing = 15f;   // A smoothing value for turning the player.
// 	public float speedDampTime = 0.1f;  // The damping for the speed parameter

// 	public float movementSpeed = 5.0f;
// 	public float jumpSpeed = 100.0f;
// 	float distToGround;
// 	public Animation jump;
// 	public Animation run;
// 	public Animation idle;
// 	public Collider ground;

// //	private HashIDs hash;               // Reference to the HashIDs.
// 	Vector3 forward;
// 	float curSpeed;
// 	float speed = 3.0F;
// 	public GameObject imageTarget;
// 	private bool targetFound = false;
// 	private TrackableBehaviour mTrackableBehaviour;
// 	const float START_X = 0.399f;
// 	const float START_Y = 0.62f;
// 	const float START_Z = 0.82f;
// 	void Start ()
// 	{
// 		mTrackableBehaviour = imageTarget.GetComponent<TrackableBehaviour>();
// 		if (mTrackableBehaviour)
// 		{
// 			mTrackableBehaviour.RegisterTrackableEventHandler(this);
// 		}

// 		distToGround = ground.bounds.extents.y;

// 		sources = GetComponents<AudioSource> ();
// 		backgroundMusic = sources[0];
// 		jumpSound = sources[1];
// 		MushroomSound = sources[2];
// 		LostLifeSound = sources[3];
// 		jump = GetComponent<Animation>();
// 		run = GetComponent<Animation>();
// 		idle = GetComponent<Animation>();
// 		transform.position = new Vector3 (START_X, START_Y, START_Z);
// 	}


// 	void FixedUpdate ()
// 	{
// 		if (targetFound) {
// 			if (!backgroundMusic.isPlaying) {
// 				backgroundMusic.clip = backgroundClip;
// 				backgroundMusic.Play ();
// 			}
// 			CharacterController controller = GetComponent<CharacterController> ();
// 			// Cache the inputs.
// 			float h = Input.GetAxis ("Horizontal");
// 			float v = Input.GetAxis ("Vertical");

// 			if ((h != 0f || v != 0f)) { // && !Input.GetButton ("Jump") 
// 				Rotating (h, v);
// 				Moving (h, v);
// 			} else if (Input.GetButton ("Jump") != true && !idle.IsPlaying ("idle") && (h == 0f || v == 0f) && IsGrounded () == true)
// 				//idle.Play ("idle");
			
// 			if (Input.GetButton ("Jump") && IsGrounded () == true) {
// 				jumpSound.clip = jumpClip;
// 				jumpSound.Play ();
// 				if (!jump.IsPlaying ("jump")) {
// 					jump ["jump"].speed = 1.0f;
// 					//jump.Play ("jump");
// 				}
// 				GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);
// 			}
// 		}
// 		if (!targetFound) {
// 			gameObject.transform.localPosition = new Vector3 (START_X, START_Y, START_Z);
// 			if (backgroundMusic.isPlaying) {
// 				backgroundMusic.Stop();
// 			}
// 		}
// 		RaycastHit hit;
// 		Ray ray = new Ray (transform.position, new Vector3 (0, -100, 0));
// 		float y_pos = transform.position.y;
// 		int layerMask = 1 << 8;
// 		if (Physics.Raycast(ray, out hit, 20, layerMask)) {
// 			y_pos = hit.point.y + 1;
// 		}
// 		layerMask = 1 << 9;
// 		if (Physics.Raycast(ray, out hit, 20, layerMask)) {
// 			y_pos = hit.point.y + 1.5f;
// 		}
// 		transform.position = new Vector3(transform.position.x, y_pos, transform.position.z);

// 	}

		
// 	void Rotating (float horizontal, float vertical)
// 	{
// 		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical); // Create a new vector of the horizontal and vertical inputs.
// 		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up); // Create a rotation based on this new vector assuming that up is the global y axis.
// 		Quaternion newRotation = Quaternion.Lerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime); // Create a rotation that is an increment closer to the target rotation from the player's rotation.
// 		GetComponent<Rigidbody>().MoveRotation(newRotation); // Change the players rotation to this new rotation.
// 	}

// 	void Moving(float horizontal, float vertical)
// 	{
// 		if (horizontal < 0) {
// 			transform.Translate (0, 0, horizontal * Time.fixedDeltaTime * speed);
// 		}
// 		if (horizontal > 0) {
// 			transform.Translate (0, 0, -horizontal * Time.fixedDeltaTime * speed);
// 		}
		
// 		if (vertical < 0) {
// 			transform.Translate (0, 0, vertical * Time.fixedDeltaTime * speed);
// 		}
		
// 		if (vertical > 0) {
// 			transform.Translate (0, 0, -vertical * Time.fixedDeltaTime * speed);
// 		}


// 		if (!run.IsPlaying("run") && !jump.IsPlaying ("jump"))
// 			run.Play ("run");

// 	}


// 	bool IsGrounded() {
// 		return Physics.Raycast(transform.position, - Vector3.up, distToGround + 0.1f);
// 	}

// 	void OnCollisionEnter (Collision info){
// 		Debug.Log (info.gameObject.name);
// 		if (info.gameObject.name == "enemy" && !LostLifeSound.isPlaying) {
// 			LostLifeSound.clip = LostLifeClip;
// 			LostLifeSound.Play ();
// 		}
// 		if (info.gameObject.name == "mushroom" && !MushroomSound.isPlaying) {
// 			MushroomSound.clip = MushroomClip;
// 			MushroomSound.Play ();
// 		}

// 	}

// 	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
// 	{
// 		if (newStatus == TrackableBehaviour.Status.DETECTED ||
// 			newStatus == TrackableBehaviour.Status.TRACKED ||
// 			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
// 		{
// 			//when target is found
// 			targetFound = true;
// 		}
// 		else
// 		{
// 			//when target is lost
// 			targetFound = false;
// 		}
// 	}

// }