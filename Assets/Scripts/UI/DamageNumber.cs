using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public Sprite[] nums;
    public Sprite[] nums_crit;
    public Sprite[] nums_large;

    public Rigidbody2D _rb;
    public SpriteRenderer _renderer;

    public int damage = 0;

    private void Start()
    {
        _rb.velocity = Vector2.up;
        StartCoroutine(Fade());
        _renderer.sprite = nums[damage];
    }

    private IEnumerator Fade()
    {
        Color c = _renderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.05f)
        {
            c.a = alpha;
            _renderer.material.color = c;
            yield return null;
        }
        Destroy(gameObject);
    }
}
