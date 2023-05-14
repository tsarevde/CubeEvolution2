using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    private Vector3 _startSize;
    private Vector3 _maxSize;
    private Vector3 _addSize;
    public float t = 0;

    public void Touch()
    {
        StartCoroutine(ScaleUp());
    }

    private void Start()
    {
        _startSize = transform.localScale;
        _maxSize = transform.localScale + new Vector3(.2f, .2f, .2f);
        _addSize = new Vector3(.05f, .05f, .05f);
    }

    private IEnumerator ScaleUp()
    {
        bool t = true;

        while (t)
        {
            if (transform.localScale != _maxSize)
                transform.localScale += _addSize;
            else t = false;

            yield return new WaitForSeconds(.01f);
        }

        StartCoroutine(ScaleDown());
    }
    private IEnumerator ScaleDown()
    {
        bool t = true;

        while (t)
        {            
            if (transform.localScale != _startSize)
                transform.localScale -= _addSize;
            else t = false;

            yield return new WaitForSeconds(.01f);
        }
    }
}
