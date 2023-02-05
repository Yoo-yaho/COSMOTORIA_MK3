using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisileScript : MonoBehaviour
{
    [SerializeField]
    private Transform[] transforms = new Transform[3];

    [SerializeField]
    private Transform playerObject;

    // Start is called before the first frame update
    void Awake()
    {
        playerObject = transform.GetComponentInParent<Transform>();
        transforms[0] = playerObject.transform;
    }

    public Vector2 bazier(float t)
    {
        Vector2 bazierLine = new Vector2(Mathf.Pow(1 - t, 2) * transforms[0].position.x +
                                         2 * t * (1 - t) * transforms[1].position.x +
                                         Mathf.Pow(t, 2) * transforms[2].position.x,
                                         Mathf.Pow(1 - t, 2) * transforms[0].position.y +
                                         2 * t * (1 - t) * transforms[1].position.y +
                                         Mathf.Pow(t, 2) * transforms[2].position.y);
        return bazierLine;
    }
    
}
