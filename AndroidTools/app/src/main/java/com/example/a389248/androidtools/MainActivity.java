package com.example.a389248.androidtools;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import com.example.tools.Utility;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        final Utility utiltyInstance =Utility.Create(getApplicationContext());

        Button HelloWorldButton = findViewById(R.id.HelloWorldButton);

        HelloWorldButton.setOnClickListener(new View.OnClickListener(){
            public void onClick(View v){
                Utility.HelloWorldStatic();
            }
        });

        Button showToastButton = findViewById(R.id.showToastButton);
        showToastButton.setOnClickListener(new View.OnClickListener() {

            public void onClick(View v) {
                utiltyInstance.ShowToastMessage("This is my toast");
            }
        });
            }

        }


