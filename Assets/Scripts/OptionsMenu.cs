using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle FullScreenTog, Vsync;

    public ResItme[] Resolutions;

    public int SelectedResolution;

    public Text ResolutionLabel;


    // Start is called before the first frame update
    void Start()
    {
        FullScreenTog.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0)
        {
            Vsync.isOn = false;
        }
        else
        {
            Vsync.isOn = true;
        }

        //search for resolution
        bool foundRes = false;
        for(int i = 0; i < Resolutions.Length; i++)
        {
            if(Screen.width == Resolutions[i].Horizontal && Screen.width == Resolutions[i].Vertical)
            {
                foundRes = true;

                SelectedResolution = i;

                UpdateResLabel();

            }
        }

        if(!foundRes)
        {
            ResolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResLeft()
    {
        SelectedResolution--;
        if(SelectedResolution < 0)
        {
            SelectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        ResolutionLabel.text = Resolutions[SelectedResolution].Horizontal.ToString() + " x " + Resolutions[SelectedResolution].Vertical.ToString();
    }

    public void ResRight()
    {
        SelectedResolution++;
        if(SelectedResolution > Resolutions.Length -1)
        {
           SelectedResolution = Resolutions.Length -1;
        }
        UpdateResLabel();
    }


    public void ApplyGraphics()
    {
        //apply fullscreen
        //Screen.fullScreen = FullScreenTog.isOn;

        //Apply Vsync
        if(Vsync.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        //sets resolution
        Screen.SetResolution(Resolutions[SelectedResolution].Horizontal,Resolutions[SelectedResolution].Vertical, FullScreenTog.isOn);

    }
}

[System.Serializable]
public class ResItme {
    public int Horizontal, Vertical;
}