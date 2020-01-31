package com.ggs.rockpaperscissors;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

public class PlayActivity extends AppCompatActivity {

    public Button backToMainFromPlay;

    public TextView userVictories;
    public TextView androidVictories;

    public TextView currentState;

    public Button buttonRock;
    public Button buttonPaper;
    public Button buttonScissors;

    public ImageView imageViewAndroidDecission;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_play);
        backToMainFromPlay = findViewById(R.id.buttonBackToMainFromPlay);

        buttonRock = findViewById(R.id.buttonRock);
        buttonPaper = findViewById(R.id.buttonPaper);
        buttonScissors = findViewById(R.id.buttonScissors);

        userVictories = findViewById(R.id.textViewUserVictoriesPostPlay);
        androidVictories = findViewById(R.id.textViewAndroidVictoriesPostPlay);

        currentState = findViewById(R.id.textViewResult);

        imageViewAndroidDecission = findViewById(R.id.imageViewAndroidDecission);

        backToMainFromPlay.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        Intent intent = new Intent(PlayActivity.this, MainActivity.class);
                        startActivity(intent);
                        finish();
                    }
                }
        );

        buttonRock.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        ModelClass.AnalizeDecission("Rock");
                        CheckIfEnd();
                        UpdateView();
                    }
                }
        );

        buttonPaper.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        ModelClass.AnalizeDecission("Paper");
                        CheckIfEnd();
                        UpdateView();
                    }
                }
        );

        buttonScissors.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        ModelClass.AnalizeDecission("Scissors");
                        CheckIfEnd();
                        UpdateView();
                    }
                }
        );

        UpdateView();
    }

    public void UpdateView(){
        ViewClass.UpdateTextViewVictories(ModelClass.countVictoryCurrentUser, userVictories);
        ViewClass.UpdateTextViewVictories(ModelClass.countVictoryCurrentAndroid, androidVictories);
        ViewClass.UpdateCurrentState(ModelClass.currentState, currentState);
        ViewClass.UpdateImageViewAndroidDecission(ModelClass.androidDecission,imageViewAndroidDecission);
        imageViewAndroidDecission.startAnimation(AnimationUtils.loadAnimation(this, R.anim.myanimoncreateimage));
        //задержка
        if (/*(ModelClass.GetCurrentNumberOfRaund() != 1) || (*/!ModelClass.androidDecission.equals("")/*)*/) {
            Handler handler = new Handler();
            handler.postDelayed(visualizeMakeNewDecission, 1500);
            buttonRock.setClickable(false);
            buttonPaper.setClickable(false);
            buttonScissors.setClickable(false);
        }
    }

    public void UpdateViewAfterHandler(){
        ViewClass.UpdateCurrentState(ModelClass.currentState, currentState);
        ViewClass.UpdateImageViewAndroidDecission(ModelClass.androidDecission,imageViewAndroidDecission);
        imageViewAndroidDecission.startAnimation(AnimationUtils.loadAnimation(this, R.anim.myanimoncreateimage));
    }

    public void CheckIfEnd(){
        if(ModelClass.countVictoryCurrentAndroid + ModelClass.countVictoryCurrentUser == ModelClass.countVictoryOfficial){
            Intent intent = new Intent(PlayActivity.this, PostPlayActivity.class);
            startActivity(intent);
            finish();
        }
    }

    Runnable visualizeMakeNewDecission = new Runnable() {
        @Override
        public void run() {
            ModelClass.NewDecission();
            UpdateViewAfterHandler();
            buttonRock.setClickable(true);
            buttonPaper.setClickable(true);
            buttonScissors.setClickable(true);
        }
    };
}
