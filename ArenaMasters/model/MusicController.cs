﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace ArenaMasters.model
{
    public class MusicController
    {
        MediaPlayer mediaPrincipal = new MediaPlayer();
        MediaPlayer mediaBattle = new MediaPlayer();
        List<string> tracksMap = new List<string>();
        List<string> tracksBattle = new List<string>();
        public bool playing = false;
        public MusicController() {
            tracksMap.Add("music/MoneyDungeonMap.mp3"); 
            tracksMap.Add("music/FinalDungeonMapPhase1.mp3");
            tracksMap.Add("music/FinalDungeonMapPhase2.mp3");
            tracksMap.Add("music/FinalDungeonMapPhase3.mp3");
            tracksBattle.Add("music/MoneyDungeonBattle.mp3");
            tracksBattle.Add("music/FinalDungeonBattlePhase1.mp3");
            tracksBattle.Add("music/FinalDungeonBattlePhase2.mp3");
            tracksBattle.Add("music/FinalDungeonBattlePhase3.mp3");

        }
        private void MediaPrincipal_Ended(object sender, EventArgs e)
        {
            mediaPrincipal.Position = TimeSpan.Zero;
            mediaPrincipal.Play();
        }
        private void MediaBattle_Ended(object sender, EventArgs e)
        {
            mediaBattle.Position = TimeSpan.Zero;
            mediaBattle.Play();
        }
        public void playInicioSesion()
        {
            try
            {
                mediaPrincipal.Open(new Uri("music/InicioSesion.mp3", UriKind.Relative));
                mediaPrincipal.Play();
                mediaPrincipal.MediaEnded += new EventHandler(MediaPrincipal_Ended);
                playing = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void playPrincipal()
        {
            try
            {
                mediaPrincipal.Close();
                mediaPrincipal.Open(new Uri("music/PantallaPrincipal.mp3", UriKind.Relative));
                mediaPrincipal.Play();
                mediaPrincipal.MediaEnded += new EventHandler(MediaPrincipal_Ended);
                playing = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async Task playDungeonMap(int lvl,bool type)
        {
            int index=0;
            try
            {
                if (type)
                {
                    index = 1;
                    if (lvl <= 2)
                    {
                        index = 1;
                    }
                    else if (lvl <= 4)
                    {
                        index = 2;
                    }
                    else if (lvl <= 5)
                    {
                        index = 3;
                    }
                }
                
                mediaBattle.Close();
                mediaBattle.Open(new Uri(tracksBattle[index], UriKind.Relative));
                mediaBattle.Volume = 0;
                mediaBattle.Play();
                mediaPrincipal.Close();
                mediaPrincipal.Open(new Uri(tracksMap[index], UriKind.Relative));
                mediaPrincipal.Volume = 0;
                mediaPrincipal.Play();
                for (float i = 0.01f; i < 0.5; i += 0.01f)
                {
                    await Task.Delay(150);
                    mediaPrincipal.Volume += i;
                }
                mediaPrincipal.MediaEnded += new EventHandler(MediaPrincipal_Ended);
                mediaBattle.MediaEnded += new EventHandler(MediaBattle_Ended);
                playing = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async Task switchDungeonBattle()
        {
            try
            {

                for (float i = 0.01f; i < 0.5; i+=0.01f)
                {
                    await Task.Delay(150);
                    mediaPrincipal.Volume -= i;
                    mediaBattle.Volume += i;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async Task switchDungeonMap()
        {
            try
            {

                for (float i = 0.01f; i < 0.5; i += 0.01f)
                {
                    await Task.Delay(150);
                    mediaPrincipal.Volume += i;
                    mediaBattle.Volume -= i;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void switchVolume()
        {
            try
            {
                mediaPrincipal.Volume= 0.2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void restoreVolume()
        {
            mediaPrincipal.Volume = 0.5;
        }
        public void stop()
        {
            mediaPrincipal.Close();
            mediaBattle.Close();
            playing = false;
        }
    }

}
