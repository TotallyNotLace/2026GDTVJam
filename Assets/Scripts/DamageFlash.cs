using System.Collections;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    private Material normal;
    [SerializeField] private Material redflash;
    [SerializeField] private MeshRenderer meshRenderer;

    private void Start()
    {
        normal = meshRenderer.material;
    }

    public void OnTakeDamage()
    {
        StartCoroutine(FlashCycle());
    }

    private IEnumerator FlashCycle()
    {
        meshRenderer.material = redflash;
        yield return new WaitForSeconds(.5f);
        meshRenderer.material = normal;
    }
}
