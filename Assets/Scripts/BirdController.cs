using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public delegate void BirdDie();
    public static BirdDie onBirdDie;

    [SerializeField] private float _velocity = 0f;
    [SerializeField] private float _gravity;
    [SerializeField] private float _gravityScaleFactor = 1f;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _jumpForce = 5;

    bool moving;

    // Start is called before the first frame update
    void Start()
    {
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && moving)
        {
            Flap(_jumpForce);
        }

        if (moving)
        {
            //ApplyGravity(_gravity);
            Move();
        }

        if (this.transform.position.y <= -7f) this.transform.position = new Vector3(transform.position.x, 8f, transform.position.z); //onBirdDie?.Invoke();
    }

    void ApplyGravity(float gravity)
    {
        if(_velocity < 0)
        {
            _acceleration -= gravity * _gravityScaleFactor;
            Debug.Log("Going down, scaling gravity");
        }
        else if (_velocity >= 0)
        {
            _acceleration -= gravity;
            Debug.Log("Going up, not scaling gravity");
        }
    }

    void Move()
    {
        if(_velocity < 0)
            _velocity += _acceleration * _gravityScaleFactor * Time.deltaTime;
        else if(_velocity >= 0)
        {
            _velocity += _acceleration * Time.deltaTime;
        }

        transform.position += new Vector3(0, _velocity, 0) * Time.deltaTime;
    }

    void Flap(float amount)
    {
        if (_velocity < 0)
        {
            _velocity = 0;
            //_acceleration = 0;
            _velocity += amount;
        }
        else if (_velocity >= 0)
        {
            _velocity += amount;
        }
    }

    void Die()
    {
        moving = false;
        EventOnBirdDie();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    void EventOnBirdDie()
    {
        onBirdDie?.Invoke();
    }
}