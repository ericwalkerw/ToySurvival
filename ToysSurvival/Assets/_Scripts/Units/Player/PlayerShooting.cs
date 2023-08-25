using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShooting : MonoBehaviour
{
    public GameDamageTarget DealDamage;
    public Transform ShootingPoint;
    public Transform ParticleHolder;
    public LineRenderer lineRenderer;
    public ParticleSystem muzzleFlash;
    public ParticleSystem explode;

    public float fireCooldown = 0.2f;

    private GameInput _gameInput;
    private float lastShotTime;
    private ObjectPool<ParticleSystem> explodePool;

    private void Start()
    {
        Init();
        _gameInput = GameInput.instance;
        lastShotTime = -fireCooldown;
    }

    public void Init()
    {
        explodePool = new ObjectPool<ParticleSystem>(
            () => Instantiate(explode, ParticleHolder),
            particleSystem => particleSystem.gameObject.SetActive(true),
            particleSystem => particleSystem.gameObject.SetActive(false),
            particleSystem => Destroy(particleSystem.gameObject)
        );
    }

    private void Update()
    {
        if (_gameInput.FireInput && CanShoot())
        {
            GameAudio.instance.PlaySfxPlayer(DealDamage.stat, "Shoot");
            Shoot();
        }
    }

    private bool CanShoot() => Time.time - lastShotTime >= fireCooldown;

    private void Shoot()
    {
        lastShotTime = Time.time;
        Ray ray = new Ray(ShootingPoint.position, ShootingPoint.forward);
        Vector3 targetPosition = ray.GetPoint(100f);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            targetPosition = hit.point;

            if (hit.collider.CompareTag("Enemy"))
            {
                DealDamage.DamgeTarget(hit.collider);
                CreateExplosion(hit.point, hit.normal);
            }
        }

        lineRenderer.enabled = true;
        lineRenderer.SetPositions(new Vector3[] { ShootingPoint.position, targetPosition });

        muzzleFlash.Play();

        StartCoroutine(ResetLineRenderer());
    }

    private void CreateExplosion(Vector3 position, Vector3 normal)
    {
        ParticleSystem explosion = explodePool.Get();
        explosion.transform.position = position;
        explosion.transform.rotation = Quaternion.LookRotation(normal);
        explosion.Play();
        StartCoroutine(ReleaseExplosion(explosion));
    }

    private IEnumerator ReleaseExplosion(ParticleSystem explosion)
    {
        yield return new WaitForSeconds(explosion.main.duration);
        explodePool.Release(explosion);
    }

    private IEnumerator ResetLineRenderer()
    {
        yield return new WaitForSeconds(0.02f);
        lineRenderer.enabled = false;
    }
}
