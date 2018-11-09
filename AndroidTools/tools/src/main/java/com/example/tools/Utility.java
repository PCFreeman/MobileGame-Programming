package com.example.tools;
import android.content.Context;
import android.util.Log;
import android.widget.Toast;

public class Utility {

    private Utility(){}

    private static Utility instance = null;

    public static Utility Create(Context applicationContext)
    {
        instance = new Utility();
        instance.applicationContext = applicationContext;
        return instance;
    }

    private Context applicationContext = null;

    public static void HelloWorldStatic()
    {
        Log.d("Unity","Hello World");
    }
    public void ShowToastMessage( String message )
    {
        Toast.makeText(applicationContext,message,Toast.LENGTH_SHORT).show();
    }

}
