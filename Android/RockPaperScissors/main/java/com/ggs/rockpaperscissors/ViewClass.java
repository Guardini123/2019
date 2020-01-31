package com.ggs.rockpaperscissors;

import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;
import android.widget.TextView;

public class ViewClass {

    public static void UpdateTextViewCountVictoryes(int arg, TextView textView){
        textView.setText(String.format("%s%s","Current count to victory : " , Integer.toString(arg)));
    }

    public static void UpdateTextViewVictories(int arg, TextView textView){
        textView.setText(String.format("%s", Integer.toString(arg)));
    }

    public static void UpdateCurrentState(int arg, TextView textView){
        String result = "";
        if(arg == 0){
            result = "Make decission!";
        } else if (arg == 1){
            result = "You win!";
        } else if (arg == 2) {
            result = "You lose!";
        } else {
            result = "Draw!";
        }
        textView.setText(result);
    }

    public static void UpdateImageViewAndroidDecission(String androidDecission, ImageView imageView){
        if (androidDecission.equals("")){
            imageView.setImageResource(R.mipmap.ic_launcher_round);
        }
        if(androidDecission.equals("Rock")){
            imageView.setImageResource(R.drawable.rock);
        }
        if(androidDecission.equals("Paper")){
            imageView.setImageResource(R.drawable.paper);
        }
        if(androidDecission.equals("Scissors")){
            imageView.setImageResource(R.drawable.scissors);
        }
    }

    public static void UpdateTextViewResult(int result, TextView textView){
        if(result == 1){
            textView.setText("You win this game!\nCongratulations!!!");
        }
        if(result == 2){
            textView.setText("You lose this game.\nDon't worry, it's just a play!");
        }
        if(result == 3){
            textView.setText("Draw!\nTry again and win this machine!!!");
        }
    }
}
