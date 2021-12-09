using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Soldier_feet feet = null;

    public float change;
    float time2change;
    float timer = 0;
    Animator anim;

    NavMeshAgent agent;

    WanderingAI wander;

    private enum states {shoot, run};
    private states currentState = states.run;

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
        feet = this.transform.Find("Soldier_Feet").GetComponent<Soldier_feet>();
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
        if (currentState != states.run)
        {
            feet.ismoving = true;
            feet.isshooting = false;
            feet.isshouting = false;

            currentState = states.run;
            anim.Play("Run", 0, 1000);
            time2change = change + Random.Range(0.5f, 5.0f); ;
            agent.enabled = true;
            wander.setActive(true);
        }
        else
        {
            feet.ismoving = false;
            feet.isshooting = true;
            feet.isshouting = false;

            currentState = states.shoot;
            anim.Play("shoot", 0, 3);
            time2change = 5 + Random.Range(0.5f, 2.0f);
            agent.enabled = false;
            wander.setActive(false);
        }
    }
}
