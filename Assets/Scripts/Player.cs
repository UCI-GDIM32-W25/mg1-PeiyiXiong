using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _numSeedsLeft = _numSeeds;
    }

    private void Update()
    {
       float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, vertical, 0f).normalized;
        _playerTransform.Translate(moveDirection * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlantSeed();
        }
    }

    public void PlantSeed ()
    {
        if (_numSeedsLeft > 0 && _plantPrefab != null && _plantCountUI != null)
        {
            Instantiate(_plantPrefab, _playerTransform.position, Quaternion.identity);
            _numSeedsLeft--;
            _numSeedsPlanted++;
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
        }
    }
}