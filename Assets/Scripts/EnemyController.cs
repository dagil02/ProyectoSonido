using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float change;
    float time2change;
    float timer = 0;
    Animator anim;

    NavMeshAgent agent;

    WanderingAI wander;

    private enum states {move, shoot, granade, run};
    private states currentState = states.move;

    void Awake()
    {

        //Set the animator component
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        wander = GetComponent<WanderingAI>();
        anim.Play("Run", 0,1000);
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
        if (currentState != states.move)
        {
            currentState = states.move;
            anim.Play("Run", 0, 1000);
            time2change = change + Random.Range(0.5f, 5.0f); ;
            agent.enabled = true;
            wander.setActive(true);
        }
        else
        {
            currentState = states.shoot;
            anim.Play("shoot", 0, 3);
            time2change = 1 + Random.Range(0.5f, 2.0f);
            agent.enabled = false;
            wander.setActive(false);
        }
    }
}
