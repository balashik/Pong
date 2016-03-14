using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    #region Editor exposed members
    [SerializeField] private float _minVelocity = 5;
    #endregion

    #region Events
    public event Action<EndZone.EndZoneType> EnteredEndZone;
    #endregion
    private Rigidbody r;

    void Start() {
        r = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// Gives the ball a completely random velocity (50%/50% left/right + 50%/50% up/down) with the minimum velocity
    /// </summary>
    public void GiveRandomVelocity()
    {
        // TODO: Give our rigidbody a random velocity, 50%/50% left/right + 50%/50% up/down - must be at least at _minVelocity
        
        int state = Random.Range(0, 3); //up left 0, up right 1 ,bottom left 2, bottom right 3
        
        switch (state) {
            case 0: {
                    r.velocity = new Vector3(_minVelocity, -_minVelocity);
                    
                    break;
                }
            case 1: {

                    r.velocity = new Vector3(-_minVelocity, _minVelocity);
                    break;
                }
            case 2: {

                    r.velocity = new Vector3(-_minVelocity, -_minVelocity);
                    break;
                }
            case 3: {

                    r.velocity = new Vector3(_minVelocity, _minVelocity);
                    break;
                }
        }
    }


    
    /// <summary>
    /// Resets the ball (position and velocity)
    /// </summary>
    public void Reset()
    {
        // TODO: Reset our ball's position and velocity
        Transform t = GetComponent<Transform>();
        t.position = Vector3.zero;
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Make sure if the ball lost velocity that we're never below the minimum
        if (r.velocity.magnitude < _minVelocity) {

            float ratio = _minVelocity / r.velocity.magnitude;
            r.velocity =r.velocity * ratio;
        }
       
    }

    private void OnTriggerEnter(Collider collider)
    {
        Rigidbody r = GetComponent<Rigidbody>();
        // TODO: Handle trigger collisions for endzones

        
        switch (collider.name) {
            case "Left End Zone": {
                    EnteredEndZone(EndZone.EndZoneType.Right);
                    break;
                }
            case "Right End Zone": {
                    EnteredEndZone(EndZone.EndZoneType.Left);
                    break;
                }

        }
        
        
        // TODO: Make sure we collided with an endzone
        // TODO: Raise the EnteredEndZone event if we did

        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    
}