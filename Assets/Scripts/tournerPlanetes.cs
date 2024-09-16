using UnityEngine;

public class tournerPlanetes : MonoBehaviour
{
    [SerializeField]
    private GameObject centre;

    [SerializeField]
    private float tempsRotation;

    [SerializeField]
    private ControleurTemps temps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(centre.transform.position, Vector3.up, (365 / tempsRotation) * (360 * Time.deltaTime) * temps.RatioTemps);
    }
}
