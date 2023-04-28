using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringBehaviour : MonoBehaviour
{
    [SerializeField] private float _waitingTime;
    [SerializeField] private float _recoloringDuration;

    private float _currentTime;
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;
    private bool _isWaiting;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }
    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (!_isWaiting)
        {
            var progress = _currentTime / _recoloringDuration; 
            var currentColor = Color.Lerp(_startColor, _nextColor, progress);
            _renderer.material.color = currentColor;
            if (!(_currentTime >= _recoloringDuration)) return;
            Debug.Log("Recolored");
            _currentTime = 0f;
            _isWaiting = true;
            GenerateNextColor();
        }
        else
        {
            if (!(_currentTime >= _waitingTime)) return;
            Debug.Log("Waited");
            _currentTime = 0f;
            _isWaiting = false;
        }
    }
}
