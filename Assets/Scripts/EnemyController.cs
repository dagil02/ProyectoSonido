using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Soldier_feet feet = null;
    public Transform Bullet;
    public Transform Casing;
    public Transform bullet_spawn;

    [SerializeField]
    private float time_running = 12.0f;
    [SerializeField]
    private float time_shooting = 3.0f;
    [SerializeField]
    private float time_shouting = 4.0f;
    [SerializeField]
    private float cadencia = 1.0f;

    float time2change;
    float timer = 0;
    Animator anim;

    NavMeshAgent agent;

    WanderingAI wander;

    private enum states { run, shout, shoot };
    private states currentState = states.run;

    public float bulletForce = 400.0f;
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
                CancelInvoke();
                feet.ismoving = true;
                feet.isshooting = false;
                feet.isshouting = false;

                currentState = states.run;
                anim.Play("Run", 0, 0);
                time2change = time_running + Random.Range(-2.5f, 2.5f); ;
                agent.enabled = true;
                wander.setActive(true);
                break;

            case 1:
                CancelInvoke();
                feet.ismoving = false;
                feet.isshooting = false;
                feet.isshouting = true;

                currentState = states.shout;
                anim.Play("Idle", 0, 0);
                time2change = time_shouting;
                agent.enabled = false;
                wander.setActive(false);
                Shout();
                break;

            case 2:
                feet.ismoving = false;
                feet.isshooting = true;
                feet.isshouting = false;

                currentState = states.shoot;
                anim.Play("shoot", 0, 0);
                time2change = time_shooting + Random.Range(-1.5f, 1.5f);
                agent.enabled = false;
                wander.setActive(false);
                InvokeRepeating("Shoot", 0, cadencia);
                break;

            default:
                break;
        }                         
    }
    private void Shout ()
    {
        FMOD.Studio.EventInstance shot = FMODUnity.RuntimeManager.CreateInstance("event:/Voices/Voicelines");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(shot, this.transform);
        shot.start();
        shot.release();
    }
    private void Shoot()
    {
        FMOD.Studio.EventInstance shot = FMODUnity.RuntimeManager.CreateInstance("event:/others/Shoot_1");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(shot, this.transform);
        var bullet = (Transform)Instantiate(
                    Bullet,
                    bullet_spawn.position,
                    transform.rotation);

        //Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity =
            bullet.transform.forward * bulletForce;

        //Spawn casing prefab at spawnpoint
        Instantiate(Casing,
            bullet_spawn.position,
            transform.rotation);

        shot.start();
        shot.release();
    }
}
