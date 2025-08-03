using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoldenObastacel : MonoBehaviour, IDamageable
{
    private float health = 3;
    private Transform spriteTransform;

    private CancellationTokenSource shakeTokenSource;

    private void Awake()
    {
        spriteTransform = GetComponent<SpriteRenderer>().transform;
    }

    public void GetDamage(float damage)
    {
        health -= damage / 10f;

        StartShake(0.2f, 0.05f);

        if (health <= 0)
        {
            shakeTokenSource?.Cancel();
            Destroy(gameObject);
        }
    }

    private void StartShake(float duration, float amplitude)
    {
        shakeTokenSource?.Cancel();
        shakeTokenSource = new CancellationTokenSource();
        ShakeAsync(duration, amplitude, shakeTokenSource.Token);
    }

    private async void ShakeAsync(float duration, float amplitude, CancellationToken token)
    {
        Vector3 originalPosition = spriteTransform.localPosition;
        float elapsed = 0f;

        try
        {
            while (elapsed < duration)
            {
                token.ThrowIfCancellationRequested();

                float offsetX = Random.Range(-amplitude, amplitude);
                spriteTransform.localPosition = originalPosition + new Vector3(offsetX, 0f, 0f);

                await Task.Yield();
                elapsed += Time.deltaTime;
            }
        }
        catch (System.OperationCanceledException)
        {

        }
        finally
        {
            if (spriteTransform != null)
            {
                spriteTransform.localPosition = originalPosition;
            }
        }
    }
}
