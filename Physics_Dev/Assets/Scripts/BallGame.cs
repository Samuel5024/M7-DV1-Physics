using UnityEngine;

public class BallGame : MonoBehaviour
{
    public Transform dropPoint;
    public float interval = 3f;

    private float nextBallTime = 0f;
    private ObjectPooler objectPooler;
    private AudioSource soundEffect;
    
    private void Start()
    {
        objectPooler = GetComponent<ObjectPooler>();
        soundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Time.time > nextBallTime)
        {
            NewBall(dropPoint.position);
            nextBallTime = Time.time + interval;
        }        
    }

    private void NewBall(Vector3 position)
    {
        //Instantiate(ballPrefab, position, Quaternion.identity);
        GameObject ball = objectPooler.GetPooledObject();
        if(ball != null)
        {
            ball.transform.position = position;
            ball.transform.rotation = Quaternion.identity;
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            ball.SetActive(true);
            soundEffect.Play();
        }
    }
}
