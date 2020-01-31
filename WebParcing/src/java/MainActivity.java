package com.ggs.webparsing3.model.model;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.pm.ActivityInfo;
import android.icu.util.RangeValueIterator;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.ggs.webparsing3.R;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;
import java.util.ArrayList;

public class MainActivity extends Activity {

    Button translate;
    @SuppressLint("StaticFieldLeak")
    public static Spinner input;
    @SuppressLint("StaticFieldLeak")
    public static Spinner output;
    @SuppressLint("StaticFieldLeak")
    public static EditText number;
    @SuppressLint("StaticFieldLeak")
    public static TextView result;

    public static int countValues = 0;
    public static String[] nominal = new String[100];
    public static ArrayList<String> name = new ArrayList();
    public static String[] currency = new String[100];
    public static ArrayAdapter<String> adapterName;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
        translate = (Button) findViewById(R.id.buttonConvert);
        number = (EditText) findViewById(R.id.editTextNumber);
        result = (TextView) findViewById(R.id.textViewResult);
        input = (Spinner) findViewById(R.id.input);
        output = (Spinner) findViewById(R.id.output);

        new NewThread().execute();

        adapterName = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, name);

        translate.setOnClickListener(
                new View.OnClickListener(){
                    public void onClick(View view){
                        Model.Calculate();
                    }
                }
        );
    }

    public static class NewThread extends AsyncTask<String,Void,String> {
        @Override
        protected String doInBackground(String... arg) {
            Document doc;
            try {
                doc = Jsoup.connect("https://cbr.ru/currency_base/daily/").get();
                Elements title = doc.select(".data");
                name.clear();
                Elements table = title.get(0).children().get(0).children();
                table.remove(0);
                nominal[0] = "1";
                name.add("Российский рубль");
                currency[0] = "1,0";
                countValues++;
                for (Element element : table) {
                    name.add(element.children().get(3).textNodes().get(0).toString());
                    countValues++;
                }
                for (int i = 1; i < countValues; i++){
                    nominal[i] = table.get(i-1).children().get(2).textNodes().get(0).toString();
                    currency[i] = table.get(i-1).children().get(4).textNodes().get(0).toString();
                }
            } catch (IOException e) {
                e.printStackTrace();
            }

            return null;
        }

        @Override
        protected void onPostExecute(String result) {
            Model.UpdateLists();
            input.setAdapter(adapterName);
            output.setAdapter(adapterName);
        }
    }
}
