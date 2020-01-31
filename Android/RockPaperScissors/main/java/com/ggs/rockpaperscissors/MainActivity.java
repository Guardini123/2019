package com.ggs.rockpaperscissors;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.view.Window;

import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

public class MainActivity extends Activity {

    public Button settings;
    public Button play;
    public Button exit;

    public TextView logo;
    public TextView victoryCount;

    public ImageView rockImage;
    public ImageView paperImage;
    public ImageView scissorsImage;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        setContentView(R.layout.activity_main);

        Handler handler = new Handler();
        settings = findViewById(R.id.buttonSettings);
        play = findViewById(R.id.buttonPlay);
        exit = findViewById(R.id.buttonExit);

        logo = findViewById(R.id.textViewLogo);
        victoryCount = findViewById(R.id.textViewCountVictory);

        rockImage = findViewById(R.id.imageViewRock);
        paperImage = findViewById(R.id.imageViewPaper);
        scissorsImage = findViewById(R.id.imageViewScissors);

        rockImage.startAnimation(AnimationUtils.loadAnimation(this, R.anim.myanimoncreateimage));
        paperImage.startAnimation(AnimationUtils.loadAnimation(this,R.anim.animonstartpaper));
        scissorsImage.startAnimation(AnimationUtils.loadAnimation(this,R.anim.animscissorsonstart));

        logo.startAnimation(AnimationUtils.loadAnimation(this, R.anim.myanimoncreateimage));
        victoryCount.startAnimation(AnimationUtils.loadAnimation(this, R.anim.myalpha));

        settings.startAnimation(AnimationUtils.loadAnimation(this, R.anim.myalpha));
        play.startAnimation(AnimationUtils.loadAnimation(this, R.anim.myalpha));
        exit.startAnimation(AnimationUtils.loadAnimation(this, R.anim.myalpha));

        settings.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        Intent intent = new Intent(MainActivity.this, SettingsActivity.class);
                        startActivity(intent);
                        finish();
                    }
                }
        );

        play.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        ModelClass.NewGame();
                        Intent intent = new Intent(MainActivity.this, PlayActivity.class);
                        startActivity(intent);
                        finish();
                    }
                }
        );

        exit.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        finish();
                    }
                }
        );

        ViewClass.UpdateTextViewCountVictoryes(ModelClass.countVictoryOfficial, victoryCount);
    }
}
