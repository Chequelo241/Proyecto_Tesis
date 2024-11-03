using UnityEngine;
using UnityEngine.UI;

public class OnclickDoors : MonoBehaviour
{
    public GameObject puzzleCanvas; // Asigna el Canvas "Puzzle" en el Inspector
    bool state=false;//se obtiene el componente boton de la imagen

    public void ActivarPuzzleCanvas()
    {
        state = !state;
        if (puzzleCanvas != null)
        {
            puzzleCanvas.SetActive(state);
        }
    }
}
