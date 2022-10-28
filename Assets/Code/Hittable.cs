using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Hittable
{
    void Hit(int Damage, Vector2 Direction);
}
