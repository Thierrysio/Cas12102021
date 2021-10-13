using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cas12102021.Modeles
{
    [Table("Commander")]

    public class Commander
    {
        #region Attributs

        private int _id;
        private int _quantite;
        private int _produitid;
        private int _commandeId;
        private Produit _lesProduits;
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
        [ForeignKey(typeof(Produit))]     // Specify the foreign key
        public int Produitid { get => _produitid; set => _produitid = value; }
        [ForeignKey(typeof(Commande))]     // Specify the foreign key
        public int CommandeId { get => _commandeId; set => _commandeId = value; }
        [ManyToOne]      // Many to one relationship with Produit
        public Produit LesProduits { get => _lesProduits; set => _lesProduits = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
