using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;


namespace Cas12102021.Services
{
    public class GestionDataBase
    {
        #region Attributs
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        #endregion
        #region Constructeurs
        public GestionDataBase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }
        #endregion
        #region Methodes
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constantes.DatabasePath, Constantes.Flags);
        });
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name ==typeof(NomDeLaClasse).Name))
                 {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(NomDeLaClasse)).ConfigureAwait(false);

                }


                initialized = true;
            }
        }

        public Task<int> SaveItemNomDeLaClasseAsync(NomDeLaClasse item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task MiseAJourRelation(object item)
        {
            return Database.UpdateWithChildrenAsync(item);
        }
        public Task<int> DeleteItemsAsyncNomDeLaClasse()
        {
            return Database.DeleteAllAsync<NomDeLaClasse>();
        }
        public ObservableCollection<NomDeLaClasse> GetItemsNomDeLaClassesAsync()
        {
            ObservableCollection<NomDeLaClasse> resultat = new ObservableCollection<NomDeLaClasse>();
            List<NomDeLaClasse> liste = Database.Table<NomDeLaClasse>().ToListAsync().Result;
            foreach (NomDeLaClasse unObjet in liste)
            {
                resultat.Add(unObjet);
            }
            return resultat;
        }
        public Task<NomDeLaClasse> GetNomDeLaClasseAvecRelations(NomDeLaClasse item)
        {
            return Database.GetWithChildrenAsync<NomDeLaClasse>(item.ID);
        }
        public Task<NomDeLaClasse> GetItemAsync(int id)
        {
            return Database.Table<NomDeLaClasse>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        #endregion
    }
}
