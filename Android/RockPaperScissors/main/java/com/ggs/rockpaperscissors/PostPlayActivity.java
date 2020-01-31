package com.ggs.rockpaperscissors;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.TextView;

public class PostPlayActivity extends AppCompatActivity {

    public TextView result;

    public TextView androidVictoriesPostPlay;
    public TextView userVictoriesPostPlay;

    public Button buttonToMenu;
    public Button buttonNewRaund;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_post_play);

        result = findViewById(R.id.textViewResult);

        androidVictoriesPostPlay = findViewById(R.id.textViewAndroidVictoriesPostPlay);
        userVictoriesPostPlay = findViewById(R.id.textViewUserVictoriesPostPlay);

        buttonToMenu = findViewById(R.id.buttonBackToMenuPostPlay);
        buttonNewRaund = findViewById(R.id.buttonNewRaund);

        buttonToMenu.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        Intent intent = new Intent(PostPlayActivity.this, MainActivity.class);
                        startActivity(intent);
                        finish();
                    }
                }
        );

        buttonNewRaund.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        ModelClass.NewGame();
                        Intent intent = new Intent(PostPlayActivity.this, PlayActivity.class);
                        startActivity(intent);
                        finish();
                    }
                }
        );

        UpdateViewOnStart();
        result.startAnimation(AnimationUtils.loadAnimation(this, R.anim.animresulttext));
    }

    public void UpdateViewOnStart(){
        ViewClass.UpdateTextViewVictories(ModelClass.countVictoryCurrentUser, userVictoriesPostPlay);
        ViewClass.UpdateTextViewVictories(ModelClass.countVictoryCurrentAndroid, androidVictoriesPostPlay);
        ViewClass.UpdateTextViewResult(ModelClass.GetResult(),result);
    }
}
