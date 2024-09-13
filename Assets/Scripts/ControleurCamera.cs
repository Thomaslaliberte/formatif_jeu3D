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
    
    public void deplacer(InputAction.CallbackContext context)
    {
        deplacement = context.action.ReadValue<Vector2>();
    }

    public void Inclinaison(InputAction.CallbackContext context)
    {
        inclinaison = context.action.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (deplacement.sqrMagnitude > 0)
        {
            Vector3 deplacementEffectif = (deplacement.y * transform.forward + deplacement.x * transform.right).normalized;
            transform.position += deplacementEffectif * vitesse * Time.deltaTime;


        }
        transform.Rotate(Vector3.up, inclinaison * vitesseInclinaison * Time.deltaTime);


    }
}
