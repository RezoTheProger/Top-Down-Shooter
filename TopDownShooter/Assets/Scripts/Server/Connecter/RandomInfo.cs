
using UnityEngine;
using TMPro;
using System.Collections;
public class RandomInfo : MonoBehaviour
{
    public TMP_Text RandText;
    public string[] RandomText;
    // Start is called before the first frame update
    void Start()
    {
        Randomator();
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        Randomator();
    }
    private void Randomator()
    {
        int i = Random.Range(0, RandomText.Length);
        RandText.text = RandomText[i];
        
    }
}
