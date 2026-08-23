namespace Opgave05.model;

// Almindelig klasse: == sammenligner REFERENCER (hukommelsesadresser) og IKKE værdier. 
// To instanser med identiske værdier er derfor IKKE ens (equal). 
public class GeoPointClass
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
