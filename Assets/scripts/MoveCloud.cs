using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    public float speed = 4.5f;
    public float acceptDistance = 1.0f;

    public float DestroyPosition = -30.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < DestroyPosition)
        {
            Destroy(gameObject);
            return;
        }

    }
}
