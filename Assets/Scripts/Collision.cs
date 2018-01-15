using UnityEngine;
using System.Collections;
using Entitas.Unity;

public class Collision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameEntity entity = gameObject.GetEntityLink().entity as GameEntity;
        if (!entity.hasCollision)
        {
            entity.AddCollision(other);
        }
    }
}
