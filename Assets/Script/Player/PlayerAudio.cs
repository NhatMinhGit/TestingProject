using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource walk;
    public AudioSource attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Walk()
    {
        walk.Play();
    }
    void StopWalk()
    {
        walk.Pause();
    }
    void PlayerAttack()
    {
        attack.Play();
    }
    void PlayerStopAttack()
    {
        attack.Pause();
    }
}
