using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    public Animator _animator;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private Rigidbody rb;

    public GameObject net;
    public Transform netAnimPos;
    public Transform netStartPos;

    public Collider walkingArea;
    private bool isWalking = false;

    private Rigidbody _rigidbody;

    private Vector3 _moveVector;

    public Quaternion targetRotation;
    public Quaternion xRotation;

    public static PlayerMovement Instance { get; private set; }



    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();


    }

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.z = _joystick.Vertical * _moveSpeed * Time.deltaTime;

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
            targetRotation = Quaternion.LookRotation(direction);
            #region Vector3.RotateTowards
            //bir vektörün başka bir vektöre doğru döndürülmesini sağlayan bir yöntemdir. Bu fonksiyon, bir başlangıç vektörünü hedef vektöre yaklaştıracak şekilde yeni bir vektör döndürür.
            #endregion

            //  x rotasyonunu sabit bir değere ayarlamak istediğimiz için,
            // Quaternion.Euler fonksiyonunu kullandık.


            xRotation = Quaternion.Euler(-23f, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);
            transform.rotation = xRotation;




            if (!SandAnimController.walk)
            {
                _animator.SetBool("iSwimming", true);
                net.transform.position = Vector3.Lerp(net.transform.position, netAnimPos.position, 5f * Time.deltaTime);
            }

        }

        else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {

            _animator.SetBool("iSwimming", false);
            net.transform.position = Vector3.Lerp(net.transform.position, netStartPos.position, 5f * Time.deltaTime);
        }

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            Debug.Log("Duvar");

        }


    }
}


