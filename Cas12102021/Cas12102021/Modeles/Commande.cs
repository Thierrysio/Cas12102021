using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Cas12102021.Modeles
{
    [Table("Commande")]
    public class Commande
    {
        #region Attributs

        private int _id;
        private DateTime _dateCommande;
        private ObservableCollection<Commander> _lesLignesCommandes;
        private int _clientId;

        #endregion

        #region Constructeurs

        public Commande()
        {
            _lesLignesCommandes = new ObservableCollection<Commander>();
        }


        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public int ID { get => _id; set => _id = value; }
        public DateTime DateCommande { get => _dateCommande; set => _dateCommande = value; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Commander> LesLignesCommandes { get => _lesLignesCommandes; set => _lesLignesCommandes = value; }
        [ForeignKey(typeof(Client))]     // Specify the foreign key
        public int ClientId { get => _clientId; set => _clientId = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
