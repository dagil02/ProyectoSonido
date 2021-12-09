using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Soldier_feet feet = null;

    [SerializeField]
    private float time_running = 10.0f;
    [SerializeField]
    private float time_shooting = 3.0f;
    [SerializeField]
    private float time_shouting = 5.0f;

    float time2change;
    float timer = 0;
    Animator anim;

    NavMeshAgent agent;

    WanderingAI wander;

    private enum states { run, shout, shoot };
    private states currentState = states.run;

    void Awake()
    {
        //Set the animator component
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        wander = GetComponent<WanderingAI>();
        anim.Play("Run", 0, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        feet = this.transform.Find("Soldier_Feet").GetComponent<Soldier_feet>();
        time2change = time_running;
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
        int next = Random.Range(0, 3);

        if (currentState == states.run)
        {
            if (next == 0) next++;
        }
        else if (currentState == states.shout)
        {
            if (next == 1) next++;
        }
        else
        {
            next = 0;
        }

        switch (next)
        {
            case 0:
                feet.ismoving = true;
                feet.isshooting = false;
                feet.isshouting = false;

                currentState = states.run;
                anim.Play("Run", 0, 0);
                time2change = time_running + Random.Range(0.5f, 2.0f); ;
                agent.enabled = true;
                wander.setActive(true);
                break;

            case 1:
                feet.ismoving = false;
                feet.isshooting = false;
                feet.isshouting = true;

                currentState = states.shout;
                anim.Play("Idle", 0, 0);
                time2change = time_shouting + Random.Range(0.5f, 2.0f);
                agent.enabled = false;
                wander.setActive(false);
                break;

            case 2:
                feet.ismoving = false;
                feet.isshooting = true;
                feet.isshouting = false;

                currentState = states.shoot;
                anim.Play("shoot", 0, 0);
                time2change = time_shooting + Random.Range(0.5f, 2.0f);
                agent.enabled = false;
                wander.setActive(false);
                break;

            default:
                break;
        }                         
    }
}
