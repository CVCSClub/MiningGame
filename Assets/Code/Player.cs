using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Hittable
{
    [Header("Stats")]
    public int Health;

    [Header("Settings")]
    public int MaxHealth;
    public float Speed;

    Rigidbody Body;

    PlayerMain Controls;

    // Start is called before the first frame update
    void Start()
    {
        Controls = new PlayerMain();
        Controls.Enable();
        Controls.Main.Movement.performed += (e) =>
        {
            MoveVector = e.ReadValue<Vector2>();
        };

        Body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 MoveVector;

    void FixedUpdate() {
        Vector2 TargetMoveVector = (Vector2)transform.position + (MoveVector.normalized * Speed * Time.fixedDeltaTime);
        Body.MovePosition(new Vector3(TargetMoveVector.x, 0f, TargetMoveVector.y));
    }

    public void Hit(int Damage, Vector2 Direction) {
        Health -= Damage;
    }
}
