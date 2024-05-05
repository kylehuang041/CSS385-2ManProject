using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float hopDistance = 0.8f;
    private float hopInterval = 0.10f;
    private float lastHopTime;

    void Start()
    {
        lastHopTime = Time.time;
    }

    void Update()
    {
        float currentTime = Time.time;
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            if (currentTime - lastHopTime > hopInterval)
            {
                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                Hop(horizontal, vertical);
                lastHopTime = currentTime;
            }
        }
    }

    void Hop(float horizontal, float vertical)
    {
        Vector3 input = new Vector3(horizontal, vertical, 0f);
        transform.Translate(input * hopDistance);
    }
}
