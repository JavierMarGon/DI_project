using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArenaMasters.model
{

    class ArenaMastersManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    

        private DataAccess _ad = new DataAccess();
    //Campos privados
    private int _numeroPeliculas;
    ObservableCollection<Units> _unitList;
    private int _sumador;
    private int _resX;
    private int _resY;

    //Propiedades (campos publicos)
    public int NumeroPeliculas
    {
        get { return _numeroPeliculas; }
        set
        {
            _numeroPeliculas = value;
            OnPropertyChanged("NumeroPeliculas");
        }
    }
    public ObservableCollection<Units> UnitList
    {
        get { return _unitList; }
    }




    //Constructor(es)
    public ArenaMastersManager()
    {
        _numeroPeliculas = 0;
        _unitList = new ObservableCollection<Units>();
        _sumador = 0;
        _resX = 1024;
        _resY = 768;
    }
    //Metodos (de Negocio)
    public int Login(string usuario, string pass)
    {
        //Comprobaciones previas

        if (_ad.PA_Login(usuario, pass)>0)
        {
            MessageBox.Show("Bienvenid@");
            return _ad.PA_Login(usuario, pass);
        }
        else
        {
            MessageBox.Show("Error de Login");
            return -1;
        }
    }
    public int Register(string nombre,  string pass)
    {
        //Comprobaciones previas

        if (_ad.PA_Register(nombre, pass) == 1)
        {
            MessageBox.Show("Bienvenid@");
            return 1;
        }
        else
        {
            MessageBox.Show("Error de Login");
            return -1;
        }


    }

    //public void AbrirCatalogo()
    //{
    //    _catalogo = new ObservableCollection<Units>();

    //    DataSet datosCatalogo = new DataSet();
    //    datosCatalogo = _ad.PA_LlamarCatalogo();
    //    Pelicula p;

    //    foreach (DataRow dr in datosCatalogo.Tables[0].Rows)
    //    {
    //        p = new Pelicula(dr.ItemArray[0].ToString(),
    //                         dr.ItemArray[1].ToString(),
    //                         int.Parse(dr.ItemArray[2].ToString()));
    //        _catalogo.Add(p);
    //    }
    //    OnPropertyChanged("Catalogo");
    //}

    //public void ActualizarNumeroPeliculas()
    //{
    //    NumeroPeliculas = _ad.DameNumeroPeliculas();
    //}

    // Create the OnPropertyChanged method to raise the event
    // The calling member's name will be used as the parameter.
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
}
