namespace SentynelAndroidClient.Models.Candidat
{
    public partial class Lister
    {
        public Colonne[] Colonnes { get; set; }

        public CandidatItem[] Donnees { get; set; }
    }

    public partial class Colonne
    {
        public bool Image { get; set; }

        public bool Clef { get; set; }

        public string Propriete { get; set; }

        public string Nom { get; set; }

        public long Largeur { get; set; }

        public bool Visible { get; set; }

        public string Alignement { get; set; }

        public object Position { get; set; }
    }





}
