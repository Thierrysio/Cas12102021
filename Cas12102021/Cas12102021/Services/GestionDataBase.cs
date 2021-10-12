using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cas12102021.Modeles;
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
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Client).Name))
                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Client)).ConfigureAwait(false);

                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Commande).Name))
                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Commande)).ConfigureAwait(false);

                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Commander).Name))
                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Commander)).ConfigureAwait(false);

                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Produit).Name))
                {

                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Produit)).ConfigureAwait(false);

                }
            }
            initialized = true;
        }


        public Task<int> SaveItemClientAsync(Client item)
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
        public Task<int> DeleteItemsAsyncClient()
        {
            return Database.DeleteAllAsync<Client>();
        }
        public ObservableCollection<Client> GetItemsNomDeLaClassesAsync()
        {
            ObservableCollection<Client> resultat = new ObservableCollection<Client>();
            List<Client> liste = Database.Table<Client>().ToListAsync().Result;
            foreach (Client unObjet in liste)
            {
                resultat.Add(unObjet);
            }
            return resultat;
        }
        public Task<Client> GetNomDeLaClasseAvecRelations(Client item)
        {
            return Database.GetWithChildrenAsync<Client>(item.ID);
        }
        public Task<Client> GetItemAsync(int id)
        {
            return Database.Table<Client>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        #endregion
    }
}

