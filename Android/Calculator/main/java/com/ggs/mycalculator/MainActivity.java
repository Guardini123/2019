package com.ggs.mycalculator;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public  void onButtonClick (View v) {
        EditText el1 = (EditText) findViewById(R.id.Num1);
        EditText el2 = (EditText) findViewById(R.id.Num2);
        TextView resText = (TextView) findViewById(R.id.Result);

        if(el1.getText().toString().length() != 0 && el2.getText().toString().length() != 0) {
        int num1 = Integer.parseInt(el1.getText().toString());
        int num2 = Integer.parseInt(el2.getText().toString());
            int res = num1 + num2;
            resText.setText(Integer.toString(res));
        } else {
            resText.setText("НЕПОЛНЫЕ ДАННЫЕ!");
        }
    }
}
