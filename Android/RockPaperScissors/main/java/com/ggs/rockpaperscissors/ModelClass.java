package com.ggs.rockpaperscissors;

import java.util.Random;

public class ModelClass {
    public static int countVictoryOfficial = 3;
    public static int countVictoryCurrentUser = 0;
    public static int countVictoryCurrentAndroid = 0;
    public static int currentState = 0;
    public static String androidDecission = "";
    /*
        0 - "Make decission!"
        1 - "You win!"
        2 - "You lose!"
        3 - "Draw!"
     */

    public static void AnalizeDecission(String userDecission){
        int result = UserMakeDecission(userDecission);
        currentState = result;
        if(result == 1){
            countVictoryCurrentUser++;
        }
        if(result == 2){
            countVictoryCurrentAndroid++;
        }
    }

    public static int UserMakeDecission(String userDecission){
        final Random random = new Random();

        int rand = random.nextInt(3);
        if(rand == 0){
            androidDecission = "Rock";
        } else if (rand == 1) {
            androidDecission = "Paper";
        } else {
            androidDecission = "Scissors";
        }
        if(userDecission.equals(androidDecission)){
            return 3;
        } else if (userDecission.equals("Rock") && androidDecission.equals("Paper")) {
            return 2;
        } else if (userDecission.equals("Rock") && androidDecission.equals("Scissors")) {
            return 1;
        } else if (userDecission.equals("Paper") && androidDecission.equals("Rock")) {
            return 1;
        } else if (userDecission.equals("Paper") && androidDecission.equals("Scissors")) {
            return 2;
        } else if (userDecission.equals("Scissors") && androidDecission.equals("Rock")) {
            return 2;
        } else if (userDecission.equals("Scissors") && androidDecission.equals("Paper")) {
            return 1;
        } else {
            return 0;
        }
    }

    public static int GetResult(){

        if(countVictoryCurrentUser > countVictoryCurrentAndroid){
            return 1;
        } else if (countVictoryCurrentUser < countVictoryCurrentAndroid){
            return 2;
        } else {
            return 3;
        }
    }

    public static void NewGame(){
        countVictoryCurrentUser = 0;
        countVictoryCurrentAndroid = 0;
        currentState = 0;
        androidDecission = "";
    }

    public static void NewDecission(){
        currentState = 0;
        androidDecission = "";
    }

    public static int GetCurrentNumberOfRaund(){
        return countVictoryCurrentAndroid+countVictoryCurrentUser+1;
    }
}
