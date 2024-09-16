using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControleurCamera : MonoBehaviour
{

    [SerializeField]
    private float vitesse;

    [SerializeField]
    private float vitesseInclinaison;

    [SerializeField]
    private float vitesseZoom;

    private float inclinaison;
    private Vector2 deplacement;
    private Vector2 zoom;
    
    public void deplacer(InputAction.CallbackContext context)
    {
        deplacement = context.action.ReadValue<Vector2>();
    }

    public void Inclinaison(InputAction.CallbackContext context)
    {
        inclinaison = context.action.ReadValue<float>();
    }

    public void Zoom(InputAction.CallbackContext context)
    {
        zoom = context.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (deplacement.sqrMagnitude > 0 || zoom.sqrMagnitude > 0)
        {
            Vector3 deplacementEffectif = (deplacement.y * new Vector3(transform.forward.x ,0, transform.forward.z) + deplacement.x * transform.right + zoom.y * transform.forward + zoom.x * transform.right).normalized;
            transform.position += deplacementEffectif * vitesse * Time.deltaTime;


        }
        transform.Rotate(Vector3.right, inclinaison * vitesseInclinaison * Time.deltaTime);


    }
}
