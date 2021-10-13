using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Cas12102021.Modeles
{
    [Table("Produit")]

    public class Produit
    {
        #region Attributs
        private int _id;
        private string _nom;
        private string _photo;
        private double _prix;
        private double _total;
        private ObservableCollection<Commander> _lesLignesCommande;
        #endregion

        #region Constructeurs

        public Produit()
        {
            _lesLignesCommande = new ObservableCollection<Commander>();
        }

        #endregion

        #region Getters/Setters
        [PrimaryKey, AutoIncrement]
        public int ID { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public double Prix { get => _prix; set => _prix = value; }
        public double Total { get => _total; set => _total = value; }

        [OneToMany]      // One to many relationship with Valuation
        public ObservableCollection<Commander> LesLignesCommande { get => _lesLignesCommande; set => _lesLignesCommande = value; }


        #endregion
        public double GetTarif()
        {
            double resultat = 0;

            resultat = this._prix * 10;

            return resultat;
        }
        #region Methodes



        #endregion
    }
}
