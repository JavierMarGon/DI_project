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

    public int GetUser(string name)
    {
        int id_user = _ad.PA_GetUser(name);
        if (id_user > 0)
        {
            return id_user;
        }
        else
        {
            MessageBox.Show("Error GetUser");
            return -1;
        }
    }

    public int ContinueGame(int id_user)
    {
        int id_game = _ad.PA_ContinueGame(id_user);
        if (id_game > 0)
        {
            return id_game;
        }
        else
        {
            MessageBox.Show("Error ContinueGame");
            return -1;
        }
    }

    public Game GetGame(string name)
    {
        int id_user = _ad.PA_GetUser(name); //Obtengo el id_user
        int id_game = _ad.PA_ContinueGame(id_user); //Obtengo la última partida
        DataSet ds = _ad.PA_GetGame(id_game);   //Obtengo los datos de la partida
        
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            // Crear una instancia de Game con los valores de la ultima partida
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                    return new Game(
                id_game,                               //ID GAME
                id_user,                               //ID USER
                name,                                  //NAME
                int.Parse(dr.ItemArray[1].ToString()), //ROUND
                int.Parse(dr.ItemArray[0].ToString()), //REFRESH
                int.Parse(dr.ItemArray[2].ToString())  //MONEY
                );
                }
            
        }
        return null;
    }

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
}
