package com.ggs.webparsing3.model.model;


public class Model {
    public static float res = 0.0f;
    public static float inRubles = 0.0f;
    public static void Calculate(){
        try {
            res = Float.parseFloat(MainActivity.number.getText().toString());
            inRubles = res * Float.parseFloat(MainActivity.currency[MainActivity.input.getSelectedItemPosition()]);
            res = inRubles / Float.parseFloat(MainActivity.currency[MainActivity.output.getSelectedItemPosition()]);
            res = Math.round(res * 100.0f) / 100.0f;
        } catch (Exception e) {
            e.printStackTrace();
        }
        ViewClass.UpdateResult(res);
    }

    public static void UpdateLists() {
        for (int i = 0; i < MainActivity.countValues; i++){
            MainActivity.currency[i] = MainActivity.currency[i].replace(",",".");
            MainActivity.currency[i] = Float.toString( Float.parseFloat(MainActivity.currency[i]) / Float.parseFloat(MainActivity.nominal[i]));
        }
    }
}


