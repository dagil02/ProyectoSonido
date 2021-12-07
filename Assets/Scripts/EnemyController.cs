using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float change;
    float time2change;
    float timer = 0;
    Animator anim;
    
    private enum states {move, shoot, granade, run};
    private states currentState = states.move;

    void Awake()
    {

        //Set the animator component
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        time2change = change;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time2change) {
            timer = 0;
            changeState();
        }
    }

    private void changeState()
    {
        if (currentState != states.move) currentState = states.move;
        else {

        }
    }
}
