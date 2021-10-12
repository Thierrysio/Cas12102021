using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Cas12102021.Modeles
{
    [Table("Client")]
    public class Client
    {
        #region Attributs

        private int _id;
        private string _nom;
        private string _prenom;
        private string _photo;
        private ObservableCollection<Commande> _lesCommandes;

        #endregion

        #region Constructeurs

        public Client()
        {
        }

        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public int ID{ get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public string Photo { get => _photo; set => _photo = value; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Commande> LesCommandes { get => _lesCommandes; set => _lesCommandes = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
