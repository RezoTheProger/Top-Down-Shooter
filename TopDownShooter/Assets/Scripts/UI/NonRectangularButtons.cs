using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
public class NonRectangularButtons : MonoBehaviour
{
    private float alphathreshold = .1f;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = alphathreshold;
    }


    
}
