using UnityEngine;

public class VanishBehaviour : MonoBehaviour
{
    public float visibleDuration = 2f;    // Time the block is visible
    public float invisibleDuration = 2f;  // Time the block is invisible

    private Renderer blockRenderer;
    private Collider blockCollider;
    private float timer;
    private bool isVisible = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blockRenderer = GetComponent<Renderer>();
        blockCollider = GetComponent<Collider>();
        timer = visibleDuration;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (isVisible && timer <= 0f)
        {
            SetVisible(false);
            timer = invisibleDuration;
        }
        else if (!isVisible && timer <= 0f)
        {
            SetVisible(true);
            timer = visibleDuration;
        }
    }

    void SetVisible(bool visible)
    {
        isVisible = visible;
        blockRenderer.enabled = visible;
        blockCollider.enabled = visible;
    }
}
