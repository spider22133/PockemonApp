using PokeAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pockemon
{
    public partial class PockemonOverview : Form
    {
        private ResourceList<NamedApiResource<Pokemon>, Pokemon> pokemons;
        private Pokemon pokemon = new Pokemon();
        private int _amount;

        private SortedList<string, Uri> pSortedList;
        private List<string> pIDList;
        // Windows
        PockemonForms pf;

        public PockemonOverview()
        {
            InitializeComponent();
           
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _amount = (await DataFetcher.GetResourceList<NamedApiResource<Pokemon>, Pokemon>()).Count;
            pokemons = await DataFetcher.GetResourceList<NamedApiResource<Pokemon>, Pokemon>(_amount);
           
            pSortedList = await PokeApiGUI.PokesToSortedList(pokemons);
          
            pIDList = PokeApiGUI.CreateIdsList(pSortedList);
            Random rnd = new Random();

            pf = new PockemonForms(pokemons, pokemon);
            ShowPoke(pSortedList.Values[rnd.Next(0, _amount)]);

            AutoCompleteStringCollection result = new AutoCompleteStringCollection();

            foreach (KeyValuePair<string, Uri> item in pSortedList)
            {
                // Add all Names
                result.Add(item.Key);
            }

            foreach (var id in pIDList)
            {
                // Add all IDs
                result.Add(id);
            }

            // Create and initialize the text box.
            search_box.AutoCompleteCustomSource = result;
            search_box.AutoCompleteMode = AutoCompleteMode.Suggest;
            search_box.AutoCompleteSource = AutoCompleteSource.CustomSource;
            search_box.Visible = true;
        }

        private async void ShowPoke(Uri url, string id = null)
        {

            if (string.IsNullOrEmpty(id))
            {
                pokemon = await PokeApiGUI.GetPokemonByUri(url);
            }
            else
            {
                pokemon = await PokeApiGUI.GetPokemonByUriID(url, id);
            }

            pictureBox1.ImageLocation = "";
            string imgUrl = pokemon.Sprites.Other.OfficialArtwork.FrontDefault;

            if (imgUrl == null)
            {
                pictureBox1.ImageLocation = PokeApiGUI.projectDirectory + @"\img\no-image-found.jpg";
                Console.WriteLine(PokeApiGUI.projectDirectory + @"\img\no-image-found.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBox1.ImageLocation = imgUrl;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            p_name.Text = pokemon.Name;
           
            //listBox1.Items.Add($"Name: {pokemon.Name}");
            listBox1.Items.Add($"ID: {pokemon.ID}");
            listBox1.Items.Add($"Height: {pokemon.Height}");
            listBox1.Items.Add($"Mass: {pokemon.Mass}");
            listBox1.Items.Add($"BaseExperience: {pokemon.BaseExperience}");
            listBox1.Items.Add($"Ability:");
            foreach (var ability in pokemon.Abilities)
            {
                listBox1.Items.Add($"      ‣ {ability.Ability.Name}");
            }
            listBox1.Items.Add($"Type:");
            foreach (var types in pokemon.Types)
            {
                listBox1.Items.Add($"      ‣ {types.Type.Name}");
            }
        }

       

        private int PokeIndex(Pokemon poke, SortedList<string, Uri> pokemons)
        {
            return pokemons.IndexOfKey(poke.Name);
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ShowPoke(PokeApiGUI.NextPoke(PokeIndex(pokemon, pSortedList), pSortedList));
        }

        private void prev_btn_Click(object sender, EventArgs e)

        {
            listBox1.Items.Clear();
            ShowPoke(PokeApiGUI.PrevPoke(PokeIndex(pokemon, pSortedList), pSortedList));
        }

        private void next_btn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                listBox1.Items.Clear();
                ShowPoke(PokeApiGUI.NextPoke(PokeIndex(pokemon, pSortedList), pSortedList));
            }

        }

        private void prev_btn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ShowPoke(PokeApiGUI.PrevPoke(PokeIndex(pokemon, pSortedList), pSortedList));
            }

        }

        private void search_box_KeyUp(object sender, KeyEventArgs e)
        {
            int value = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(search_box.Text))
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Start entering Pokemons name.");
                }
                else if (!pSortedList.ContainsKey(search_box.Text) && !pIDList.Contains(search_box.Text))
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add("No such Pokemon exists.");
                }
                else
                {
                    listBox1.Items.Clear();
                    ShowPoke(new Uri(PokeApiGUI.GetBaseUrl()), search_box.Text);
                }


            }
        }

        private void show_variations_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pf.Equals(null))   
                {
                    pf = new PockemonForms(pokemons,pokemon);
                }
                pf.ShowDialog();
            }
            catch (Exception i)
            {
                throw new Exception(i.ToString());
            }

        }
    }
}
