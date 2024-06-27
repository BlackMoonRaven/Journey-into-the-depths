using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private int _speed = 6;

    private SpriteRenderer[] _spritesCharacter; // Масив для спрайтів персонажа
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spritesCharacter = GetComponentsInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(MoveX(_speed), MoveY(_speed));
        _animator.SetBool("isMoving", (Mathf.Abs(MoveX(_speed)) + Mathf.Abs(MoveY(_speed))) >= 1);

        if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetTrigger("attack");
        }
        
    }

    // Рух гравця по горизонталі
    private float MoveX(float speed)
    {
        if (Input.GetKey(KeyCode.D))
        {
            Flip(true);
            return speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Flip(false);
            return -speed;
        }
        else
        {
            return 0;
        }
    }

    // Рух гравця по пертикалі
    private float MoveY(float speed)
    {
        if (Input.GetKey(KeyCode.W))
        {
            return speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            return -speed;
        }
        else
        {
            return 0;
        }
    }

    // Метод для повороту спрайта
    private void Flip(bool flip)
    {
        for (int i = 0; i < _spritesCharacter.Length; i++)
        {
            _spritesCharacter[i].flipX = flip;
        }
    }
}
