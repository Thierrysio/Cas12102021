using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cas12102021.Modeles
{
    public class Commander
    {
        #region Attributs

        private int _id;
        private int _quantite;
        //private Produit _leProduit;
        private int _commandeId;
        #endregion

        #region Constructeurs

        public Commander()
        {
        }


        #endregion


        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public int ID { get => _id; set => _id = value; }
        public int Quantite { get => _quantite; set => _quantite = value; }
        //public Produit LeProduit { get => _leProduit; set => _leProduit = value; }
        [ForeignKey(typeof(Commande))]     // Specify the foreign key
        public int CommandeId { get => _commandeId; set => _commandeId = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
