using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launcherAudio;
    [SerializeField] private AudioClip launchClip;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        if (activeMissile != null) return null;

        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();
        if (homing != null)
        {
            homing.SetTarget(target);
        }

        if (launcherAudio != null && launchClip != null)
        {
            launcherAudio.PlayOneShot(launchClip);
        }

        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}