using UnityEngine;

public class PlayerMovement : MonoBehaviour {
   
   

    // This is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;

	public float forwardForce = 2000f;	// Variable that determines the forward force
	public float sidewaysForce = 500f;  // Variable that determines the sideways force
    public float jumpVelocity = 4000f;
    private int numJumps = 0;

    public AudioClip musicClip;
    public AudioSource musicSource;
    // We marked this as "Fixed"Update because we
    // are using it to mess with physics.
    void Start()
    {
        musicSource.clip = musicClip;
    }
    void FixedUpdate ()
	{
		// Add a forward force
		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d"))	// If the player is pressing the "d" key
		{
			// Add a force to the right
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a"))  // If the player is pressing the "a" key
		{
			// Add a force to the left
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
        if (Input.GetKey(KeyCode.Space) && rb.position.y<1.86f && rb.position.y>.95f &&
           rb.position.x<15/2 && rb.position.x>-15/2){
            float force = jumpVelocity;
            if (rb.velocity.y>1f){//we are coming up from bouncing
                force += rb.velocity.y * 1500f;
            }
            rb.AddForce(0, force*Time.deltaTime, 0);

            if(force > 20000){
                musicSource.volume = 1f;
            }
            else{
                musicSource.volume = (force) / 20000;
            }
            Debug.Log(force + "");
            musicSource.Play();

        }

        if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}



