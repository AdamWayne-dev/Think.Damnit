using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodMemoryMediumVariant : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    SpriteRenderer currentSprite;
    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        currentSprite.sprite = sprites[Random.Range(0, sprites.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
