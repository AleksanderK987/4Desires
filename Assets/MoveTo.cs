using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;


    public GameObject target;
    public List<GameObject> targets;

    public float stopDistance = 1f;
    public int counter = 0;
    public float maxSpeed = 2f;
    public Bars bary;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        target = targets[counter];
        Neutral();

    }

    // Update is called once per frame
    void Update()
    {
        Hunger();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }



    void Neutral()
    {
        ClearAnimation();
        counter = 0;
        target = targets[counter];
        if (Vector3.Distance(target.transform.position, _agent.transform.position) > stopDistance)
        {
            _agent.SetDestination(target.transform.position);
            _agent.isStopped = false;
            ClearAnimation();
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _agent.isStopped = true;
            _animator.SetBool("isWalking", false);
        }
    }

    void Hunger()
    {
        if (bary.HungerSlider.value <= 20)
        {
            ClearAnimation();
            counter = 3;
            target = targets[counter];
            if (Vector3.Distance(target.transform.position, _agent.transform.position) > stopDistance)
            {
                _agent.SetDestination(target.transform.position);
                _agent.isStopped = false;
                ClearAnimation();
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _agent.isStopped = true;
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isEating", true);
            }
        }
        else
        {
            _animator.GetBool("isEating");
            if (_animator.GetBool("isEating") == true)
            {
                if (bary.HungerSlider.value >= 100)
                {
                    ClearAnimation();
                    _animator.SetBool("isEating", false);
                    Mood();
                }
            }
            else
            {
                Mood();
            }
        }

    }

    void Mood()
    {
        if (bary.MoodSlider.value <= 20)
        {
            ClearAnimation();
            counter = 2;
            target = targets[counter];
            if (Vector3.Distance(target.transform.position, _agent.transform.position) > stopDistance)
            {
                _agent.SetDestination(target.transform.position);
                _agent.isStopped = false;
                ClearAnimation();
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _agent.isStopped = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isWatching", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (_animator.GetBool("isWatching") == true)
            {
                if (bary.MoodSlider.value >= 100)
                {
                    ClearAnimation();
                    _animator.SetBool("isWatching", false);
                    Toilet();
                }
            }
            else
            {
                Toilet();
            }
        }

    }

    void Toilet()
    {
        if (bary.ToiletSlider.value <= 20)
        {
            ClearAnimation();
            counter = 1;
            target = targets[counter];
            if (Vector3.Distance(target.transform.position, _agent.transform.position) > stopDistance)
            {
                _agent.SetDestination(target.transform.position);
                _agent.isStopped = false;
                ClearAnimation();
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _agent.isStopped = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isSitting", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (_animator.GetBool("isSitting") == true)
            {
                if (bary.ToiletSlider.value >= 100)
                {
                    ClearAnimation();
                    _animator.SetBool("isSitting", false);
                    Sleep();
                }
            }
            else
            {
                Sleep();
            }
        }
    }

    void Sleep()
    {
        if (bary.SleepSlider.value <= 20)
        {
            ClearAnimation();
            counter = 4;
            target = targets[counter];
            if (Vector3.Distance(target.transform.position, _agent.transform.position) > stopDistance)
            {
                _agent.SetDestination(target.transform.position);
                _agent.isStopped = false;
                ClearAnimation();
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _agent.isStopped = true;
                transform.rotation = Quaternion.Euler(0, -90, 0);
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isSleeping", true);
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        else
        {
            if (_animator.GetBool("isSleeping") == true)
            {
                if (bary.SleepSlider.value >= 100)
                {
                    ClearAnimation();
                    _animator.SetBool("isSleeping", false);
                    Neutral();
                }
            }
            else
            {
                Neutral();
            }
        }
    }

    void ClearAnimation()
    {
        _animator.SetBool("isEating", false);
        _animator.SetBool("isSitting", false);
        _animator.SetBool("isSleeping", false );
        _animator.SetBool("isWatching", false);
    }
}
