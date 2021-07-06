using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokeAPI;

namespace Pockemon
{
    public partial class PockemonForms : Form
    {

        ResourceList<NamedApiResource<Pokemon>, Pokemon> pokemons;
        private Pokemon pokemon;
        List<Pokemon> pokeEvo = new List<Pokemon>();
        List<Uri> urls = new List<Uri>();

        public PockemonForms(ResourceList<NamedApiResource<Pokemon>, Pokemon> pokemons, Pokemon poke)
        {
            InitializeComponent();
            this.pokemons = pokemons;
            this.pokemon = poke;
        }

        private async void PockemonForms_Load(object sender, EventArgs e)
        {
            Uri SpesiesUri = null;
            PokemonSpecies getSpecies = new PokemonSpecies();
            if (pokemon.Species.Url != null) {
                getSpecies = await GetSpecies(pokemon.Species.Url);
            }

            if(getSpecies.EvolutionChain != null)
            {
                SpesiesUri = new Uri($"{getSpecies.EvolutionChain.Url}");

                EvolutionChain getEvolutionChain = await DataFetcher.GetApiObject<EvolutionChain>(SpesiesUri);

                List<Uri> urlsEvo = GetEvoUrl(getEvolutionChain.Chain, urls);

                GetEvoPokemons(urlsEvo);
            } 
            else
            {
               
                Label label = new Label();
                label.Location = new Point(12, 12);
                label.Size = new Size(400, 100);
                label.Margin = new Padding(12);
                label.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                label.Text = "No EvoPokes exist!";

                Controls.Add(label);
            }


            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        }
        private void PockemonForms_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            //GC.SuppressFinalize(this);
        }
       
        private async void GetEvoPokemons(List<Uri> urlsEvo)
        {

            int posX = 12;
            int posY = 12;
            List<string> pIDList = new List<string>();

            foreach (var item in urlsEvo)
            {
                string[] uriArray = (item.AbsolutePath).Trim('/').Split('/');

                // Add all IDs
                pIDList.Add(uriArray[uriArray.Length - 1]);
            }

            foreach (var item in pIDList)
            {
                Pokemon pokem = await PokeApiGUI.GetPokemonByUriID(new Uri(PokeApiGUI.GetBaseUrl()), item);
                pokeEvo.Add(pokem);
            }

            for (int i = 0; i < pokeEvo.Count; i++)
            {
                PictureBox box = new PictureBox();
                box.ImageLocation = pokeEvo[i].Sprites.Other.OfficialArtwork.FrontDefault;
                box.SizeMode = PictureBoxSizeMode.Zoom;
                box.Location = new Point(posX, 12);
                box.Size = new Size(250, 300);
                box.Margin = new Padding(12);
                Controls.Add(box);

                ListBox listBox = new ListBox();
                listBox.Location = new Point(posX, 312);
                listBox.Size = new Size(250, 100);
                listBox.Margin = new Padding(12);

                listBox.Items.Add($"Name: {pokeEvo[i].Name}");
                listBox.Items.Add($"ID: {pokeEvo[i].ID}");
                listBox.Items.Add($"Height: {pokeEvo[i].Height}");
                listBox.Items.Add($"Mass: {pokeEvo[i].Mass}");

                Controls.Add(listBox);

                posX += 262;
                posY += 312;

            }
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            urlsEvo.Clear();
        }

        private async Task<PokemonSpecies> GetSpecies(Uri Url)
        {
            return await DataFetcher.GetApiObject<PokemonSpecies>(Url);
        }

        private static List<Uri> GetEvoUrl(ChainLink getEvolutionChain, List<Uri> urls)
        {
            
            urls.Add(getEvolutionChain.Species.Url);
            foreach (var item in getEvolutionChain.EvolvesTo)
            {
                GetEvoUrl(item, urls);
            }

            return urls;
        }

    }
}
