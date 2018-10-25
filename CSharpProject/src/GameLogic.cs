
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;
static class GameLogic
{
	public static void Main()
	{
		//Opens a new Graphics Window
		SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

		//Load Resources
		GameResources.LoadResources();

		 SwinGame.PlayMusic(GameResources.GameMusic("Background"));
     		 bool mute = false;
       		 //Game Loop
       		 do
    	    	 {
          	 	GameController.HandleUserInput();
       			GameController.DrawScreen();

            		if (SwinGame.KeyTyped(KeyCode.MKey))
            		{
               			if (mute)
                		{
                    			SwinGame.ResumeMusic();
                   			 mute = true;
                		}
                		else
                		{
                    			SwinGame.PauseMusic();
                    			mute = false;
                		}
            	}
        } while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));
		SwinGame.StopMusic();

		//Free Resources and Close Audio, to end the program.
		GameResources.FreeResources();
	}
}
