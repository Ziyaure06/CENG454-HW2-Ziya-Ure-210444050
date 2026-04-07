using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab; // Füze Prefab'ýný buraya sürükle
    [SerializeField] private Transform launchPoint;   
  

    private GameObject activeMissile; // Havada olan aktif füze

    public GameObject Launch(Transform target)
    {
        
        if (activeMissile != null) return null;

        
        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

     
        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();
        if (homing != null)
        {
            homing.SetTarget(target);
        }

        Debug.Log("Fýrlatýcý: Füze ateþlendi!");
       
        return activeMissile;
    }

    
    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
            Debug.Log("Fýrlatýcý: Uçak kaçtý, füze imha edildi!");
        }
    }
}