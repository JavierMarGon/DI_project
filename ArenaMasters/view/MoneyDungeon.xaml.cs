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
using System.Windows.Threading;
using System.Xml.Linq;
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
        bool endDungeon=false;
        private ImageBrush personajeLeft;
        private ImageBrush personajeRight;
        private ImageBrush personajeStatic;
        //Clase con los datos de movimiento del pj
        PlayableDungeonMovement pj;
        private DispatcherTimer timer;
        private MusicController controller =  new MusicController();
        private List<Units> unitsSelected = new List<Units>();
        //Instancia de rectangulo para generar el pj
        public System.Windows.Shapes.Rectangle image = new System.Windows.Shapes.Rectangle();

        public MoneyDungeon(int level, Game _game, List<Units> _unitsSelected)
        {
            InitializeComponent();
            chargeGame(level,_game, _unitsSelected);

        }
        public MoneyDungeon(int level, Game _game, List<Units> _unitsSelected, MusicController mc)
        {
            InitializeComponent();
            chargeGame(level, _game, _unitsSelected);
            controller=mc;  

        }
        private void chargeGame(int level, Game _game, List<Units> _unitsSelected)
        {
            unitsSelected = _unitsSelected;
            personajeLeft = new ImageBrush();
            personajeRight = new ImageBrush();
            if(level<6) 
            {
                lvl = level;
            }
            else
            {
                endDungeon = true;
                lvl = 1;
            }
            
            pj = new PlayableDungeonMovement(lvl);
            paintImage();
            profit = Rewards(lvl);
            game = _game;
            AgregarRectangulos(lvl);
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(390);
            timer.Tick += Timer_Tick;
        }

        private void exitClick(object sender, RoutedEventArgs e)
        {
            CautionMessage.Visibility = Visibility.Visible;
        }

        private void gameExitTrue(object sender, RoutedEventArgs e)
        {
            controller.stop();
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
            timer.Stop();
            timer.Start();
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

                    if (rectangulo.Name == "bedCollision1")
                    {
                        if (jugadorRect.IntersectsWith(mapaRect))
                        {
                            MessageBox.Show("Has recuperado vida");
                            ChangeImageBed(1);
                        }
                    }
                    else if (rectangulo.Name == "bedCollision2")
                    {
                        if (jugadorRect.IntersectsWith(mapaRect))
                        {
                            MessageBox.Show("Has recuperado vida");
                            ChangeImageBed(2);
                        }
                    }
                    else if (rectangulo.Name == "finallyLvl")
                    {
                        if (jugadorRect.IntersectsWith(mapaRect))
                        {
                            CheckFinally();
                        }
                    }else if(rectangulo.Name == "enemigoColl1")
                    {
                        if (jugadorRect.IntersectsWith(mapaRect))
                        {
                            int enemy = 1;
                            CheckEnemy(/*lvl,*/ enemy);
                        }
                    }


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
                if (data.Name == "bedImg1" || data.Name == "bedImg2")
                {
                    AgregarImagenCama(data.Name, data.Width, data.Height, data.Left, data.Top, data.Rotation);
                }
                else if (data.Name == "enemigoImg1")
                {
                    AgregarImagenEnemy(data.Name, data.Width, data.Height, data.Left, data.Top, data.Path);
                }
                else
                {
                    AgregarRectangulo(data.Name, data.Height, data.Width, data.Left, data.Top);
                }
            }
        }
        private Dictionary<string, List<ColisionMapa>> ObtenerMapas()
        {
            // Implementación para obtener o crear el diccionario de mapas
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
            else if (lvl == 5)
            {
                backgroundImage.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/map5.png", UriKind.Absolute));
            }
            else if (lvl == 6)
            {
                backgroundImage.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/map6.png", UriKind.Absolute));
            }
            // Establecer un color sólido como fondo
            personajeStatic = new ImageBrush();
            personajeStatic.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/PlayerStatic.png", UriKind.Absolute));

            personajeLeft = new ImageBrush();
            personajeLeft.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/PlayerMovementLeft.png", UriKind.Absolute));

            personajeRight = new ImageBrush();
            personajeRight.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/PlayerMovementRight.png", UriKind.Absolute));
            image.Fill = personajeStatic; // Color de relleno del rectángulo
            image.Name = "player";

            Canvas.SetLeft(image, pj.MarginLeft); // Posición izquierda de la imagen
            Canvas.SetTop(image, pj.MarginTop); // Posición superior de la imagen

            // Agregar la imagen al Canvas
            container_pj.Children.Add(image);
        }

        private void CheckFinally()
        {
            MessageBoxResult result = MessageBox.Show("¿Quieres continuar?", "Confirmación", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                // logica para avanzar al siguiente nivel
                if (endDungeon)
                {
                    MoneyDungeon newMoneyD = new MoneyDungeon(lvl + 1, game, unitsSelected, controller);
                    newMoneyD.Show();
                    this.Close();
                }
                else
                {
                    controller.stop();
                    GameMenu gameMenu = new GameMenu(game,profit);
                    gameMenu.Show();
                    this.Close();

                }


            }
            else
            {
                
            }
        }

        private void CheckEnemy(/*int lvl, */int enemy)
        {
            this.IsEnabled = false;
            this.Visibility = Visibility.Hidden;
            controller.switchMoneyDungeonBattle();
            Fight f = new Fight(1, game, unitsSelected);
            f.ShowDialog();

            // La ventana actual vuelve a ser interactiva después de que la ventana modal se cierra

            // Hay que hacer una lógica para saber si ha conseguido derrotar al enemigo o no y así hacer que se eliminen los rectangulos o no.
            this.IsEnabled = true;
            controller.switchMoneyDungeonMap();
            this.Visibility = Visibility.Visible;
            MessageBox.Show("Enemigo derrotado");

            string collEnemy = $"enemigoColl{enemy}";
            
            List<UIElement> elementosAEliminar = new List<UIElement>();

            foreach (UIElement element in container_pj.Children)
            {
                if (element is Rectangle rectangle && rectangle.Name == collEnemy)
                {
                    elementosAEliminar.Add(rectangle);
                }
            }

            foreach (UIElement elementoEliminar in elementosAEliminar)
            {
                container_pj.Children.Remove(elementoEliminar);
            }

        }

        private void AgregarImagenCama(string name, double height, double width, double left, double top, int rotation)
        {
            Image camaImage = new Image();
            camaImage.Name = name;
            camaImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/images/bedUnused.png", UriKind.Absolute));
            camaImage.Width = width;
            camaImage.Height = height;

            Canvas.SetLeft(camaImage, left);
            Canvas.SetTop(camaImage, top);
            RotateTransform rotateTransform = new RotateTransform(rotation);
            camaImage.RenderTransform = rotateTransform;
            container_pj.Children.Add(camaImage);
        }
        private void AgregarImagenEnemy(string name, double height, double width, double left, double top, string path)
        {
            Image camaImage = new Image();
            camaImage.Name = name;
            string imagePath = $"pack://application:,,,{path}";
            camaImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
            camaImage.Width = width;
            camaImage.Height = height;

            Canvas.SetLeft(camaImage, left);
            Canvas.SetTop(camaImage, top);
            container_pj.Children.Add(camaImage);
        }

        private void ChangeImageBed(int cama)
        {
            string camaCollisionName = $"bedCollision{cama}";
            string camaUsedName = $"bedUsed{cama}";
            string camaImgName = $"bedImg{cama}";

            foreach (UIElement element in container_pj.Children)
            {
                if (element is Rectangle rectangle && rectangle.Name == camaCollisionName)
                {
                    rectangle.Name = camaUsedName;
                }
                else if (element is Image image && image.Name == camaImgName)
                {
                    if (image.Source != null)
                    {
                        image.Source = new BitmapImage(new Uri(@"pack://application:,,,/images/bedUsed.png", UriKind.Absolute));
                    }
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Se ejecutará cada vez que transcurra 1 segundo sin presionar ninguna tecla
            image.Fill = personajeStatic; // Cambia la imagen del jugador a la estática
            timer.Stop(); // Detiene el temporizador
        }

        private int Rewards(int lvl)
        {
            if (lvl == 1)
            {
                return 500;
            }
            else if (lvl == 2)
            {
                return 1500;
            }
            else if (lvl == 3)
            {
                return 2750;
            }
            else if (lvl == 4)
            {
                return 4000;
            }
            else
            {
                return 10000;
            }
        }
    

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (controller.playing==false)
            {
                controller.playMoneyDungeonMap();
            }
            
        }
    }
}
