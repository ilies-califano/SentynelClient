namespace SentynelAndroidClient.Models.Candidat;

public class CandidatEtat
{
    public int Id { get; set; }
    public string Etat { get; set; }

    public override string ToString()
    {
        return Etat;
    }
}