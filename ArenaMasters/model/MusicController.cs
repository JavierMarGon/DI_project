using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ArenaMasters.model
{
    internal class MusicController
    {
        MediaPlayer mediaPlayer = new MediaPlayer();
        private void Media_Ended(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }
        public void playInicioSesion()
        {
            try
            {
                mediaPlayer.Open(new Uri("music/InicioSesion.mp3", UriKind.Relative));
                mediaPlayer.MediaEnded += new EventHandler(Media_Ended);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void playCementerio()
        {
            try
            {
                mediaPlayer.Close();
                mediaPlayer.Open(new Uri("music/Cementerio.mp3", UriKind.Relative));
                mediaPlayer.MediaEnded += new EventHandler(Media_Ended);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void playTaberna()
        {
            try
            {
                mediaPlayer.Close();
                mediaPlayer.Open(new Uri("music/Taberna.mp3", UriKind.Relative));
                mediaPlayer.MediaEnded += new EventHandler(Media_Ended);

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
                mediaPlayer.Close();
                mediaPlayer.Open(new Uri("music/PantallaPrincipal.mp3", UriKind.Relative));
                mediaPlayer.MediaEnded += new EventHandler(Media_Ended);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void playEncrucijada()
        {
            try
            {
                mediaPlayer.Close();
                mediaPlayer.Open(new Uri("music/Encrucijada.mp3", UriKind.Relative));
                mediaPlayer.Play();
                mediaPlayer.MediaEnded += new EventHandler(Media_Ended);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void stop()
        {
            mediaPlayer.Close();
        }
    }

}
