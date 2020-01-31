package com.ggs.rockpaperscissors;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.Display;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class SettingsActivity extends AppCompatActivity {

    public Button bth3Victorys;
    public Button bth6Victorys;

    public Button bthBackToMenu;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings);
        bth3Victorys = findViewById(R.id.buttonThreeVictory);
        bth6Victorys = findViewById(R.id.buttonSixVictory);

        bthBackToMenu = findViewById(R.id.buttonBackToMenuFromSettings);

        bth3Victorys.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        ModelClass.countVictoryOfficial = 3;
                        Intent intent = new Intent(SettingsActivity.this, MainActivity.class);
                        startActivity(intent);
                        finish();
                    }
                }
        );

        bth6Victorys.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        ModelClass.countVictoryOfficial = 6;
                        Intent intent = new Intent(SettingsActivity.this, MainActivity.class);
                        startActivity(intent);
                        finish();
                    }
                }
        );


        bthBackToMenu.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        Intent intent = new Intent(SettingsActivity.this, MainActivity.class);
                        startActivity(intent);
                        finish();
                    }
                }
        );
    }
}
