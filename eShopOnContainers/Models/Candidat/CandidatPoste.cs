namespace SentynelAndroidClient.Models.Candidat;

public class CandidatPoste
{
    public int Id { get; set; }
    public string Poste { get; set; }

    public override string ToString()
    {
        return Poste;
    }
}