package com.ggs.photoshop;

import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {

    public static Button start;
    public static Button exit;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        setContentView(R.layout.activity_main);

        Window w = getWindow();
        w.setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);

        start = (Button) findViewById(R.id.start_btn);
        exit = (Button) findViewById(R.id.exit_btn);
    }
    public void goToEditor(View view){
        Intent intent = new Intent(this, editor.class);
        startActivity(intent);
        finish();
    }

    public void exit(View view){
        data.BitmapMy.MakeNull();
        finish();
    }
}
