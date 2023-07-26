    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Mouse : MonoBehaviour
    {
        private SpriteRenderer spr;
        public Sprite normalCursor;
        public Sprite specialCursor;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = false;
            spr = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPos;
            ChangeMouseColor();
        }

        private void ChangeMouseColor()
        {
            if (Input.GetMouseButtonDown(0))
            {
                spr.sprite = specialCursor;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                spr.sprite = normalCursor;
            }
        }
    }
