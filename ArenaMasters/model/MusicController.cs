using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace ArenaMasters.model
{
    public class MusicController
    {
        MediaPlayer mediaPrincipal = new MediaPlayer();
        MediaPlayer mediaBattle = new MediaPlayer();
        public bool playing = false;
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
        public async Task playMoneyDungeonMap()
        {
            try
            {
                mediaBattle.Close();
                mediaBattle.Open(new Uri("music/MoneyDungeonBattle.mp3", UriKind.Relative));
                mediaBattle.Volume = 0;
                mediaBattle.Play();
                mediaPrincipal.Close();
                mediaPrincipal.Open(new Uri("music/MoneyDungeonMap.mp3", UriKind.Relative));
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
        public async Task switchMoneyDungeonBattle()
        {
            try
            {

                for (float i = 0.01f; i < 0.5; i+=0.01f)
                {
                    await Task.Delay(100);
                    mediaPrincipal.Volume -= i;
                    mediaBattle.Volume += i;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async Task switchMoneyDungeonMap()
        {
            try
            {

                for (float i = 0.01f; i < 0.5; i += 0.01f)
                {
                    await Task.Delay(100);
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
