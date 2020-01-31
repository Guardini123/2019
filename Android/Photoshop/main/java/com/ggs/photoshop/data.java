package com.ggs.photoshop;

import android.graphics.Bitmap;


public class data {
    public static class BitmapMy {

        public static Bitmap bitmap_late;

        public static void SetBitmapToSave(Bitmap in) {
            bitmap_late = in;
        }

        public static Bitmap GetBitmapFromSave() {
            if (bitmap_late != null) {
                return bitmap_late;
            } else {
                return null;
            }
        }

        public static void MakeNull(){
            bitmap_late = null;
        }
    }


}
