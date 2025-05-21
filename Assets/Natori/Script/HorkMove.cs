using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorkMove : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®”ÍˆÍA")] private Transform _rangeA;
    [SerializeField, Header("ˆÚ“®”ÍˆÍB")] private Transform _rangeB;
    [SerializeField, Header("ˆÚ“®‘¬“x")] private float _moveSpeed;
    [SerializeField, Header("”­ŽËŒû")] private GameObject _muzzle;
    [SerializeField, Header("’e‚ÌŽí—Þ")] private List<GameObject> _bullets;
    [SerializeField, Header("’e‚Ì‘¬“x")] private float _bulletSpeed;
    private Vector2 _enemyPos;
    private Vector2 _vec2;
    private float _vecX;
    private float _vecY;
    private float _moveTime;
    private float _attackTime;
    private bool _attackFlag;
    // Start is called before the first frame update
    void Start()
    {
        _moveTime = 0;
        _attackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _enemyPos = this.transform.position;
        _moveTime -= Time.deltaTime;
        if (_moveTime <= 0.0f)
        {
            _vecX = Random.Range(_rangeA.transform.position.x, _rangeB.transform.position.x);
            _vecY = Random.Range(_rangeA.transform.position.y, _rangeB.transform.position.y);
            var _lastEnemyPos = _enemyPos;
            _vec2 = new Vector2(_vecX, _vecY);
            gameObject.GetComponent<Rigidbody2D>().velocity = (_vec2 - _lastEnemyPos).normalized * _moveSpeed;
            _moveTime = 1.0f;
        }
        if (Mathf.Approximately(_vec2.x,_enemyPos.x)&&Mathf.Approximately(_vec2.y,_enemyPos.y))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (!_attackFlag)
        {
            _attackTime += Time.deltaTime;
        }
        if (_attackTime >= 2.0f)
        {
            _attackFlag = true;
            _attackTime = 0.0f;
            StartCoroutine(Attack());
        }
    }

    private void BulletMove(GameObject bullet)
    {
        Rigidbody2D _bulletRb = bullet.GetComponent<Rigidbody2D>();
        _bulletRb.velocity = -Vector3.up * _bulletSpeed;
    }

    private IEnumerator Attack()
    {
        int _randomBullet = Random.Range(0, 20);
        if (_randomBullet <= 18)
        {
            var _bulletNum = 0;
            var _instantiateBullet = Instantiate(_bullets[_bulletNum], _muzzle.transform.position, Quaternion.identity);
            BulletMove(_instantiateBullet);
        }
        if (_randomBullet == 19)
        {
            var _bulletNum = 1;
            var _instantiateBullet = Instantiate(_bullets[_bulletNum], _muzzle.transform.position, Quaternion.identity);
            BulletMove(_instantiateBullet);
        }
        if (_randomBullet == 20)
        {
            var _bulletNum = 2;
            var _instantiateBullet = Instantiate(_bullets[_bulletNum], _muzzle.transform.position, Quaternion.identity);
            BulletMove(_instantiateBullet);
        }
        yield return new WaitForSeconds(0.2f);
        _attackFlag = false;
    }
}
