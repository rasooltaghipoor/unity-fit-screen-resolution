using UnityEngine;

public class ScaleToFitScreen : MonoBehaviour
{
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // world height is always camera's orthographicSize * 2
        float worldScreenHeight = Camera.main.orthographicSize * 2;

        // world width is calculated by diving world height with screen heigh
        // then multiplying it with screen width
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        float bWidth, bHeight;
        bWidth = worldScreenWidth;
        bHeight = sr.sprite.bounds.size.y * bWidth / sr.sprite.bounds.size.x;
        if (bHeight < worldScreenHeight)
        {
            bHeight = worldScreenHeight;
            bWidth = sr.sprite.bounds.size.x * bHeight / sr.sprite.bounds.size.y;
        }

        // to scale the game object we divide the world screen width with the
        // size x of the sprite, and we divide the world screen height with the
        // size y of the sprite
        transform.localScale = new Vector3(
            bWidth / sr.sprite.bounds.size.x,
            bHeight / sr.sprite.bounds.size.y, 1);
    }
} // class
