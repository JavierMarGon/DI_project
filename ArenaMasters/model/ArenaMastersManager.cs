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
    ObservableCollection<Units> _unitList;

    //Propiedades (campos publicos)
    public ObservableCollection<Units> UnitList
    {
        get { return _unitList; }
    }




    //Constructor(es)
    public ArenaMastersManager()
    {
        _unitList = new ObservableCollection<Units>();
    }
    //Metodos (de Negocio)
    public int Login(string usuario, string pass)
    {
        //Comprobaciones previas

        if (_ad.PA_Login(usuario, pass)>0)
        {
            MessageBox.Show("Bienvenid@ ", usuario);
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
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
}
