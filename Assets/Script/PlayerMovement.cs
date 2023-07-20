using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    public GameObject net;
    public Transform netAnimPos;
    public Transform netStartPos;

    private Rigidbody _rigidbody;

    private Vector3 _moveVector;



    private void Awake()
    {

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
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            #region Vector3.RotateTowards
            //bir vektörün başka bir vektöre doğru döndürülmesini sağlayan bir yöntemdir. Bu fonksiyon, bir başlangıç vektörünü hedef vektöre yaklaştıracak şekilde yeni bir vektör döndürür.
            #endregion

            //  x rotasyonunu sabit bir değere ayarlamak istediğimiz için,
            // Quaternion.Euler fonksiyonunu kullandık.
            Quaternion xRotation = Quaternion.Euler(-23f, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);
            transform.rotation = xRotation;


            _animator.SetBool("iSwimming", true);
            net.transform.DOMove(netAnimPos.transform.position, 1.5f);

            //net.transform.position = netAnimPos.transform.position;
        }

        else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {

            _animator.SetBool("iSwimming", false);
            net.transform.DOMove(netStartPos.position, 0.25f);
            //net.transform.position = netStartPos.transform.position;

        }

        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }


}