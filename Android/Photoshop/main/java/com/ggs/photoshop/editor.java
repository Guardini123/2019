package com.ggs.photoshop;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentResolver;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.ColorMatrix;
import android.graphics.ColorMatrixColorFilter;
import android.graphics.Matrix;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.ImageView;

import java.io.IOException;

public class editor extends AppCompatActivity {

    public static Bitmap my_saved_bitmap = null;

    public static Button upload;
    public static Button save;
    public static ImageView image;
    public static Button sepia;
    public static Button bAw;
    public static Button red;
    public static Button green;
    public static Button blue;
    public static String title;
    public static String description;
    public static int conversion = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_editor);
        Window w = getWindow();
        w.setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);

        upload = (Button) findViewById(R.id.upload_btn);
        save = (Button) findViewById(R.id.save_btn);
        image = (ImageView) findViewById(R.id.pic);
        sepia = (Button) findViewById(R.id.sepia_btn);
        bAw = (Button) findViewById(R.id.bAw_btn);
        red = (Button) findViewById(R.id.red_btn);
        green = (Button) findViewById(R.id.green_btn);
        blue = (Button) findViewById(R.id.blue_btn);

        my_saved_bitmap = data.BitmapMy.GetBitmapFromSave();

        if(my_saved_bitmap != null){
            image.setImageBitmap(my_saved_bitmap);
        }

        upload.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent photoPickerIntent = new Intent(Intent.ACTION_PICK);
                photoPickerIntent.setType("image/*");
                startActivityForResult(photoPickerIntent, 1);
            }
        });

        save.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                image.setDrawingCacheEnabled(true);
                Bitmap bm = Bitmap.createBitmap(image.getDrawingCache());
                title+="1";
                description+="1";
                ContentResolver content=getContentResolver();
                image.setDrawingCacheEnabled(false);
                MediaStore.Images.Media.insertImage(content, bm, title , description);
            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent imageReturnedIntent) {
        super.onActivityResult(requestCode, resultCode, imageReturnedIntent);

        Bitmap bitmap = null;

        switch(requestCode) {
            case 1:
                if(resultCode == RESULT_OK){
                    Uri selectedImage = imageReturnedIntent.getData();
                    try {
                        bitmap = MediaStore.Images.Media.getBitmap(getContentResolver(), selectedImage);
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                    image.setImageBitmap(bitmap);
                    data.BitmapMy.SetBitmapToSave(bitmap);
                }
        }
    }

    public void rotateImage(View view){
        BitmapDrawable drawable = (BitmapDrawable) image.getDrawable();
        Bitmap newBitmap = drawable.getBitmap();
        Matrix newMatrix = new Matrix();
        newMatrix.setRotate(90);
        image.setImageBitmap(Bitmap.createBitmap(newBitmap, 0, 0, newBitmap.getWidth(), newBitmap.getHeight(), newMatrix, true));
        switch (conversion){
            case (1): setBlackAndWhite(view); break;
            case (2): setSepia(view); break;
            case (3): setRed(view) ; break;
            case (4): setGreen(view); break;
            case (5): setBlue(view); break;
            default: break;
        }
    }


    public void setBlackAndWhite(View view) {
        final Drawable drawable = image.getDrawable();

        if (drawable == null)
            return;

        final ColorMatrix matrixA = new ColorMatrix();
        matrixA.setSaturation(0);

        final ColorMatrixColorFilter filter = new ColorMatrixColorFilter(matrixA);
        drawable.setColorFilter(filter);
        conversion = 1;
    }

    public void setSepia(View view) {
        final Drawable drawable = image.getDrawable();

        if (drawable == null)
            return;

        final ColorMatrix matrixA = new ColorMatrix();
        matrixA.setSaturation(0);

        final ColorMatrix matrixB = new ColorMatrix();
        matrixB.setScale(1f, .95f, .82f, 1.0f);
        matrixA.setConcat(matrixB, matrixA);

        final ColorMatrixColorFilter filter = new ColorMatrixColorFilter(matrixA);
        drawable.setColorFilter(filter);
        conversion = 2;
    }

    public void setRed(View view) {
        final Drawable drawable = image.getDrawable();

        if (drawable == null)
            return;

        final ColorMatrix matrixA = new ColorMatrix();
        matrixA.setSaturation(0);

        final ColorMatrix matrixB = new ColorMatrix();
        matrixB.setScale(.7f, 0, 0, 1.0f);
        matrixA.setConcat(matrixB, matrixA);

        final ColorMatrixColorFilter filter = new ColorMatrixColorFilter(matrixA);
        drawable.setColorFilter(filter);
        conversion = 3;
    }

    public void setGreen(View view) {
        final Drawable drawable = image.getDrawable();

        if (drawable == null)
            return;

        final ColorMatrix matrixA = new ColorMatrix();
        matrixA.setSaturation(0);

        final ColorMatrix matrixB = new ColorMatrix();
        matrixB.setScale(0, .7f, 0, 1.0f);
        matrixA.setConcat(matrixB, matrixA);

        final ColorMatrixColorFilter filter = new ColorMatrixColorFilter(matrixA);
        drawable.setColorFilter(filter);
        conversion = 4;
    }

    public void setBlue(View view) {
        final Drawable drawable = image.getDrawable();

        if (drawable == null)
            return;

        final ColorMatrix matrixA = new ColorMatrix();
        matrixA.setSaturation(0);

        final ColorMatrix matrixB = new ColorMatrix();
        matrixB.setScale(0, 0, .7f, 1.0f);
        matrixA.setConcat(matrixB, matrixA);

        final ColorMatrixColorFilter filter = new ColorMatrixColorFilter(matrixA);
        drawable.setColorFilter(filter);
        conversion = 5;
    }

    public void getBack(View view){
        Intent back = new Intent(this, MainActivity.class);
        startActivity(back);
        finish();
    }

    public void Reset(View view)
    {
        image.setImageBitmap(data.BitmapMy.GetBitmapFromSave());
    }
}
