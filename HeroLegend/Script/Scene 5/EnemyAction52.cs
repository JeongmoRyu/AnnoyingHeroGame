using System.Collections;
using UnityEngine;

public class EnemyAction52 : MonoBehaviour
{
    public static EnemyAction52 Instance { get; private set; } // ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫

    public AudioSource effectSound;

    Animator anim;

    public GameObject explosionPrefab2;

    private void Awake()
    {
        Instance = this; // ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫

        anim = GetComponent<Animator>();
    }

    public void AttackonTitan()
    {
        StartCoroutine(TriggerHittingAnimation());
    }

    private IEnumerator TriggerHittingAnimation()
    {
        for (int i = 0; i < 3; i++)
        {
            anim.SetTrigger("isHitting");
            effectSound.Play();

            // Instantiate «‘ºˆ∑Œ «¡∏Æ∆’¿ª ª˝º∫
            GameObject explosion = Instantiate(explosionPrefab2, transform.position, Quaternion.identity);
            explosion.transform.localScale *= 15;
            explosion.transform.position += new Vector3(0, 2, 0);

            Renderer renderer = explosion.GetComponent<Renderer>();
            renderer.sortingLayerName = "Default";
            renderer.sortingOrder = int.MaxValue;

            yield return new WaitForSeconds(1f);
        }
    }
    public void TriggerSkilling()
    {
        anim.SetTrigger("isSkilling");
    }
}