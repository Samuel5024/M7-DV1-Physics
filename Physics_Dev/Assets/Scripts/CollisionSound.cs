using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private AudioSource hitSoundEffect;
    
    private void Start()
    {
        hitSoundEffect = GetComponent<AudioSource>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitSoundEffect.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
