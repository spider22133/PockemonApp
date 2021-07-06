using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using PokeAPI;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pockemon
{
    public static class PokeApiGUI
    {
        private static int _countPokeID = 0;
       
        private static string _baseUrl = @"https://pokeapi.co/api/v2/pokemon/";

        // get the current WORKING directory (i.e. \bin\Debug)
        public static string workingDirectory = Environment.CurrentDirectory;
        // get the current PROJECT directory
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;


        public static async Task<Pokemon> GetPokemonByUri(Uri url)
        {
            return await DataFetcher.GetApiObject<Pokemon>(url);
        }
        public static async Task<Pokemon> GetPokemonByUriID(Uri url, string id)
        {
            return await DataFetcher.GetApiObject<Pokemon>(new Uri(url.ToString() + id));
        }

        public static async Task<SortedList<string, Uri>> PokesToSortedList(ResourceList<NamedApiResource<Pokemon>, Pokemon> pokes)
        {
            SortedList<string, Uri> pSortedList = new SortedList<string, Uri>();
           
            foreach (var item in pokes)
            {
                pSortedList.Add(item.Name, item.Url);
            }
            
            return pSortedList;
        }

        public static List<string> CreateIdsList(SortedList<string, Uri> pokemons)
        {
            List<string> pIDList = new List<string>();
            foreach (KeyValuePair<string, Uri> item in pokemons)
            {
                Uri uri = new Uri(item.Value.ToString());
                string[] uriArray = (uri.AbsolutePath).Trim('/').Split('/');

                // Add all IDs
                pIDList.Add(uriArray[uriArray.Length - 1]);
            }
            return pIDList;
        }

        public static Uri NextPoke(int index, SortedList<string, Uri> pSortedList)
        {

            if (index >= pSortedList.Count - 1)
            {
                return pSortedList.Values[pSortedList.Count - 1 - index];
            }

            return pSortedList.Values[index + 1];
        }
        public static Uri PrevPoke(int index, SortedList<string, Uri> pSortedList)
        {
            if (index <= 0)
            {
                return pSortedList.Values[pSortedList.Count - 1];
            }
            return pSortedList.Values[index - 1];

        }

        public static int GetPokeID()
        {
            return _countPokeID;
        }
        public static int SetPokeID(int id)
        {
            return _countPokeID = id;
        }
        public static string GetBaseUrl()
        {
            return _baseUrl;
        }
    

    }
}
