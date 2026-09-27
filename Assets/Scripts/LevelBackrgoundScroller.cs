using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LevelBackrgoundScroller : MonoBehaviour
{
    public Transform parentTransform;
    public float scrollScale = 1f;
    private SpriteRenderer spriteRenderer;

    private Vector3 lastParentPos;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float xDiff = parentTransform.position.x - lastParentPos.x;

        if (xDiff != 0)
        {
            float scrollAmount = spriteRenderer.material.GetFloat("_ScrollAmount");
            scrollAmount += xDiff * scrollScale;
            spriteRenderer.material.SetFloat("_ScrollAmount", scrollAmount);

            lastParentPos = parentTransform.position;
        }
    }
}
