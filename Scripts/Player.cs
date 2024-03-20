using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // tọa đọ Map
    [SerializeField] protected Vector3 targetPosition;
    // tốc độ gốc
    [SerializeField] protected float speed = 1f;
    void FixedUpdate()
    {
        this.GetTarget();
        this.Moving();
        this.LootAtTarget();
    }
    protected virtual void LootAtTarget(){
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
    }
    protected virtual void GetTarget()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);
        transform.parent.position = newPos;

    }
}
