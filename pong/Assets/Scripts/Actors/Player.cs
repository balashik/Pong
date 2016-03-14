using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Player identifier enum
    /// </summary>
    public enum PlayerType
    {
        Left,
        Right
    }

    #region Editor exposed members
    [SerializeField] private PlayerType _playerType;
    [SerializeField] private float _movementSpeed = 5;
    #endregion

    #region Private members
    private Transform _transform;
    private float _halfHeight;
    #endregion

    private void Start()
    {
        // Store highly used variables in advance for performance
        _transform = transform;
        _halfHeight = GetComponent<Collider>().bounds.extents.y;

        
    }

    private void Update()
    {
        // TODO: Get movement input (Make sure left/right player)
        // TODO: Move player
        // TODO: Make sure player doesn't leave screen bounds (ScreenUtil.ScreenPhysicalBounds will help you out)
        if (_playerType == PlayerType.Left) {
            if (Input.GetKey(KeyCode.W)) {
                MoveUp();
            }

            if (Input.GetKey(KeyCode.S)) {

                MoveDown();
            }
        }
        if (_playerType == PlayerType.Right) {

            if (Input.GetKey(KeyCode.UpArrow)) {
                MoveUp();
            }

            if (Input.GetKey(KeyCode.DownArrow)) {

                MoveDown();
            }


        }

    }


    void MoveUp() {
        if (_transform.localPosition.y < ScreenUtil.ScreenPhysicalBounds.yMax - _transform.localScale.y) {

            _transform.localPosition = new Vector3(_transform.localPosition.x, _transform.localPosition.y + 1);
        }
    }
    void MoveDown() {
        if (_transform.localPosition.y > ScreenUtil.ScreenPhysicalBounds.yMin + _transform.localScale.y) {

            _transform.localPosition = new Vector3(_transform.localPosition.x, _transform.localPosition.y - 1);
        }

    }

}