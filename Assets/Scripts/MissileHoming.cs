using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f; // Füzenin hýzý
    [SerializeField] private float turnSpeed = 5f;  // Füzenin dönüþ (manevra) kabiliyeti
    private Transform target;

    // Hedefi dýþarýdan füzeye tanýtmak için
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            // 1. Hedefe doðru yumuþakça dön (Homing)
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

            // 2. Ýleri doðru uç
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}