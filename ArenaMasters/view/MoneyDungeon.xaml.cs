using ArenaMasters.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static ArenaMasters.Collisions;

namespace ArenaMasters
{
    /// <summary>
    /// Lógica de interacción para MoneyDungeon.xaml
    /// </summary>
    public partial class MoneyDungeon : Window
    {
        Game game;
        int lvl;
        int profit;
        private ImageBrush personajeLeft;
        private ImageBrush personajeRight;
        //Clase con los datos de movimiento del pj
        PlayableDungeonMovement pj;

        //Instancia de rectangulo para generar el pj
        public System.Windows.Shapes.Rectangle image = new System.Windows.Shapes.Rectangle();

        public MoneyDungeon(int level, int rewards, Game _game)
        {
            InitializeComponent();
            personajeLeft = new ImageBrush();
            personajeRight = new ImageBrush();
            lvl = level;
            pj = new PlayableDungeonMovement(lvl);
            paintImage();
            profit = rewards;
            game = _game;
            AgregarRectangulos(lvl);
            
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            CautionMessage.Visibility = Visibility.Visible;
        }

        private void gameExitTrue(object sender, RoutedEventArgs e)
        {
            GameMenu gameMenu = new GameMenu(game);
            gameMenu.Show();
            this.Close();

        }
        private void gameExitFalse(object sender, RoutedEventArgs e)
        {
            CautionMessage.Visibility = Visibility.Collapsed;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            int stepSize = 10;   // Tamaño del paso para el movimiento del rectángulo

            double originalLeft = pj.MarginLeft;
            double originalTop = pj.MarginTop;

            insertCoord();

            switch (e.Key)
            {
                case Key.Left: // Izquierda
                    pj.MarginLeft -= stepSize;
                    image.Fill = personajeLeft;
                    break;
                case Key.Right: // Derecha
                    pj.MarginLeft += stepSize;
                    image.Fill = personajeRight;
                    break;
                case Key.Down: // Abajo
                    pj.MarginTop += stepSize;
                    break;
                case Key.Up: // Arriba
                    pj.MarginTop -= stepSize;
                    break;
            }
            updateImage();

            if (CheckCollisions())
            {
                // Si hay colisión, retrocede a la posición anterior
                pj.MarginLeft = originalLeft;
                pj.MarginTop = originalTop;
                updateImage();
            }
        }


        private bool CheckCollisions()
        {
            // Obtén el rectángulo del jugador
            Rect jugadorRect = new Rect(Canvas.GetLeft(image), Canvas.GetTop(image), image.Width, image.Height);

            // Itera sobre todos los rectángulos del mapa
            foreach (UIElement element in container_pj.Children)
            {
                if (element is Rectangle && element != image) // Asegúrate de que es un rectángulo
                {
                    Rectangle rectangulo = (Rectangle)element;

                    // Obtén el rectángulo del elemento del mapa
                    Rect mapaRect = new Rect(Canvas.GetLeft(rectangulo), Canvas.GetTop(rectangulo), rectangulo.Width, rectangulo.Height);

                    // Comprueba si hay intersección entre los dos rectángulos
                    if (jugadorRect.IntersectsWith(mapaRect))
                    {
                        // Hay colisión, puedes realizar acciones aquí
                        return true;
                    }
                }
            }
            return false;
        }

        private void AgregarRectangulos(int lvl)
        {
            Collisions collisions = new Collisions();
            List<ColisionMapa> mapaSeleccionado = collisions.ObtenerMapa(lvl);
            //Generamos las colisiones dependiendo del mapa
            foreach (var data in mapaSeleccionado)
            {
                AgregarRectangulo(data.Name, data.Height, data.Width, data.Left, data.Top);
            }
        }
        private Dictionary<string, List<ColisionMapa>> ObtenerMapas()
        {
            // Implementación para obtener o crear el diccionario de mapas
            // Puedes adaptar esto según tus necesidades específicas
            return new Dictionary<string, List<ColisionMapa>>();
        }

        private void AgregarRectangulo(string name, double height, double width, double left, double top)
        {
            Rectangle rectangulo = new Rectangle();
            rectangulo.Name = name;
            rectangulo.Height = height;
            rectangulo.Width = width;
            rectangulo.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));


            // Establece las propiedades Canvas.Left y Canvas.Top
            Canvas.SetLeft(rectangulo, left);
            Canvas.SetTop(rectangulo, top);

            // Agrega el rectángulo al Canvas
            container_pj.Children.Add(rectangulo);
        }

        private void insertCoord()
        {
            double bottomPj = pj.MarginTop + image.Height;
            pj.MarginBottom = bottomPj;     //Insert MarginBottom en la Clase pj

            double rightPj = pj.MarginLeft + image.Width;
            pj.MarginRight = rightPj;     //Insert MarginRight en la Clase pjs
        }
        


        private void updateImage()
        {
            Canvas.SetLeft(image, pj.MarginLeft); 
            Canvas.SetTop(image, pj.MarginTop); 
        }

        public void paintImage()
        {
            image.Width = 60; // Ancho del rectángulo
            image.Height = 60; // Alto del rectángulo

            backgroundImage.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/map1.png", UriKind.Absolute));
            if (lvl == 1)
            {
                backgroundImage.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/map1.png", UriKind.Absolute));
            }
            else if (lvl == 2)
            {
                backgroundImage.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/map2.png", UriKind.Absolute));
            }
            else if (lvl == 3)
            {
                backgroundImage.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/map3.png", UriKind.Absolute));
            }
            else if (lvl == 4)
            {
                backgroundImage.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/map4.png", UriKind.Absolute));
            }

            // Establecer un color sólido como fondo
            personajeLeft = new ImageBrush();
            personajeLeft.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/personajeLeft.png", UriKind.Absolute));

            personajeRight = new ImageBrush();
            personajeRight.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/personajeRight.png", UriKind.Absolute));
            image.Fill = personajeRight; // Color de relleno del rectángulo
            image.Name = "player";

            Canvas.SetLeft(image, pj.MarginLeft); // Posición izquierda de la imagen
            Canvas.SetTop(image, pj.MarginTop); // Posición superior de la imagen

            // Agregar la imagen al Canvas
            container_pj.Children.Add(image);
        }


    }
}
