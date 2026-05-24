using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BadEnd : MonoBehaviour
{
    public string[] _lines;
    public float _speedText;
    public Text _badEnd;

    private int _index;

    private void Start()
    {
        _badEnd.text = string.Empty;
        StartEnd();
    }
    IEnumerator TypeLine()
    {
        foreach (char c in _lines[_index].ToCharArray())
        {
            _badEnd.text += c;
            yield return new WaitForSeconds(_speedText);
        }
    }
    public void SkipEnd()
    {
        if (_badEnd.text == _lines[_index])
        {
            Nextline();
        }
        else
        {
            StopAllCoroutines();
            _badEnd.text = _lines[_index];
        }
    }
    private void StartEnd()
    {
        _index = 0;
        StartCoroutine(TypeLine());
    }
    private void Nextline()
    {
        if (_index < _lines.Length - 1)
        {
            _index++;
            _badEnd.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }



}